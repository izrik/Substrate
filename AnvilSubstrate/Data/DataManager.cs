using System;
using System.Collections.Generic;
using Substrate.Nbt;
using System.IO;
using Substrate.Core;

namespace Substrate.Data
{
    /// <summary>
    /// Provides a common interface for managing additional data resources in a world.
    /// </summary>
    public class DataManager : INbtObject<DataManager>
    {
        /// <summary>
        /// Gets or sets the id of the next map to be created.
        /// </summary>
        public int MapId;

        /// <summary>
        /// Gets an <see cref="IMapManager"/> for managing <see cref="Map"/> data resources.
        /// </summary>
        public MapManager Maps { get; protected set; }

        /// <summary>
        /// Saves any metadata required by the world for managing data resources.
        /// </summary>
        /// <returns><c>true</c> on success, or <c>false</c> if data could not be saved.</returns>
        public bool Save ()
        {
            if (_world == null) {
                return false;
            }
            
            try {
                string path = Path.Combine(_world.Path, _world.DataDirectory);
                NBTFile nf = new NBTFile(Path.Combine(path, "idcounts.dat"));
                
                Stream zipstr = nf.GetDataOutputStream(CompressionType.None);
                if (zipstr == null) {
                    NbtIOException nex = new NbtIOException("Failed to initialize uncompressed NBT stream for output");
                    nex.Data["DataManager"] = this;
                    throw nex;
                }
                
                new NbtTree(BuildTree() as TagNodeCompound).WriteTo(zipstr);
                zipstr.Close();
                
                return true;
            }
            catch (Exception ex) {
                Exception lex = new Exception("Could not save idcounts.dat file.", ex);
                lex.Data["DataManager"] = this;
                throw lex;
            }
        }


        private static SchemaNodeCompound _schema = new SchemaNodeCompound()
        {
            new SchemaNodeScaler("map", TagType.TAG_SHORT),
        };

        private TagNodeCompound _source;

        private NbtWorld _world;

        public DataManager (NbtWorld world)
        {
            _world = world;

            Maps = new MapManager(_world);
        }



        #region INBTObject<DataManager>

        public virtual DataManager LoadTree (TagNode tree)
        {
            TagNodeCompound ctree = tree as TagNodeCompound;
            if (ctree == null) {
                return null;
            }

            MapId = ctree["map"].ToTagShort();

            _source = ctree.Copy() as TagNodeCompound;

            return this;
        }

        public virtual DataManager LoadTreeSafe (TagNode tree)
        {
            if (!ValidateTree(tree)) {
                return null;
            }

            return LoadTree(tree);
        }

        public virtual TagNode BuildTree ()
        {
            TagNodeCompound tree = new TagNodeCompound();

            tree["map"] = new TagNodeLong(MapId);

            if (_source != null) {
                tree.MergeFrom(_source);
            }

            return tree;
        }

        public virtual bool ValidateTree (TagNode tree)
        {
            return new NbtVerifier(tree, _schema).Verify();
        }

        #endregion
    }


}
