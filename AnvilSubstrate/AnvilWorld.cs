using System;
using System.Collections.Generic;
using System.IO;
using Substrate.Core;
using Substrate.Nbt;
using Substrate.Data;

//TODO: Exceptions (+ Alpha)

namespace Substrate
{
    using IO = System.IO;

    /// <summary>
    /// Represents an Anvil-compatible (Release 1.2 or higher) Minecraft world.
    /// </summary>
    public class AnvilWorld
    {
        private const string _REGION_DIR = "region";
        private const string _PLAYER_DIR = "players";
        private string _levelFile = "level.dat";

        private Level _level;

        private Dictionary<Dimension, AnvilRegionManager> _regionMgrs;
        private Dictionary<Dimension, RegionChunkManager> _chunkMgrs;
        private Dictionary<Dimension, BlockManager> _blockMgrs;

        private Dictionary<Dimension, ChunkCache> _caches;

        private PlayerManager _playerMan;
        private DataManager _dataMan;

        private int _prefCacheSize = 256;

        private AnvilWorld ()
        {
            _dataDir = _DATA_DIR;

            _regionMgrs = new Dictionary<Dimension, AnvilRegionManager>();
            _chunkMgrs = new Dictionary<Dimension, RegionChunkManager>();
            _blockMgrs = new Dictionary<Dimension, BlockManager>();

            _caches = new Dictionary<Dimension, ChunkCache>();
        }

        /// <summary>
        /// Gets a reference to this world's <see cref="Level"/> object.
        /// </summary>
        public Level Level
        {
            get { return _level; }
        }

        /// <summary>
        /// Gets a <see cref="BlockManager"/> for the default dimension.
        /// </summary>
        /// <returns>A <see cref="BlockManager"/> tied to the default dimension in this world.</returns>
        /// <remarks>Get a <see cref="BlockManager"/> if you need to manage blocks as a global, unbounded matrix.  This abstracts away
        /// any higher-level organizational divisions.  If your task is going to be heavily performance-bound, consider getting a
        /// <see cref="RegionChunkManager"/> instead and working with blocks on a chunk-local level.</remarks>
        public BlockManager GetBlockManager ()
        {
            return GetBlockManagerVirt(Dimension.DEFAULT) as BlockManager;
        }

        /// <summary>
        /// Gets a <see cref="BlockManager"/> for the given dimension.
        /// </summary>
        /// <param name="dim">The id of the dimension to look up.</param>
        /// <returns>A <see cref="BlockManager"/> tied to the given dimension in this world.</returns>
        /// <remarks>Get a <see cref="BlockManager"/> if you need to manage blocks as a global, unbounded matrix.  This abstracts away
        /// any higher-level organizational divisions.  If your task is going to be heavily performance-bound, consider getting a
        /// <see cref="RegionChunkManager"/> instead and working with blocks on a chunk-local level.</remarks>
        public BlockManager GetBlockManager (Dimension dim)
        {
            return GetBlockManagerVirt(dim) as BlockManager;
        }

        /// <summary>
        /// Gets a <see cref="RegionChunkManager"/> for the default dimension.
        /// </summary>
        /// <returns>A <see cref="RegionChunkManager"/> tied to the default dimension in this world.</returns>
        /// <remarks>Get a <see cref="RegionChunkManager"/> if you you need to work with easily-digestible, bounded chunks of blocks.</remarks>
        public RegionChunkManager GetChunkManager ()
        {
            return GetChunkManagerVirt(Dimension.DEFAULT) as RegionChunkManager;
        }

        /// <summary>
        /// Gets a <see cref="RegionChunkManager"/> for the given dimension.
        /// </summary>
        /// <param name="dim">The id of the dimension to look up.</param>
        /// <returns>A <see cref="RegionChunkManager"/> tied to the given dimension in this world.</returns>
        /// <remarks>Get a <see cref="RegionChunkManager"/> if you you need to work with easily-digestible, bounded chunks of blocks.</remarks>
        public RegionChunkManager GetChunkManager (Dimension dim)
        {
            return GetChunkManagerVirt(dim) as RegionChunkManager;
        }

        /// <summary>
        /// Gets a <see cref="RegionManager"/> for the default dimension.
        /// </summary>
        /// <returns>A <see cref="RegionManager"/> tied to the defaul dimension in this world.</returns>
        /// <remarks>Regions are a higher-level unit of organization for blocks unique to worlds created in Beta 1.3 and beyond.
        /// Consider using the <see cref="RegionChunkManager"/> if you are interested in working with blocks.</remarks>
        public AnvilRegionManager GetRegionManager ()
        {
            return GetRegionManager(Dimension.DEFAULT);
        }

        /// <summary>
        /// Gets a <see cref="RegionManager"/> for the given dimension.
        /// </summary>
        /// <param name="dim">The id of the dimension to look up.</param>
        /// <returns>A <see cref="RegionManager"/> tied to the given dimension in this world.</returns>
        /// <remarks>Regions are a higher-level unit of organization for blocks unique to worlds created in Beta 1.3 and beyond.
        /// Consider using the <see cref="RegionChunkManager"/> if you are interested in working with blocks.</remarks>
        public AnvilRegionManager GetRegionManager (Dimension dim)
        {
            AnvilRegionManager rm;
            if (_regionMgrs.TryGetValue(dim, out rm)) {
                return rm;
            }

            OpenDimension(dim);
            return _regionMgrs[dim];
        }

        /// <summary>
        /// Gets a <see cref="PlayerManager"/> for maanging players on multiplayer worlds.
        /// </summary>
        /// <returns>A <see cref="PlayerManager"/> for this world.</returns>
        /// <remarks>To manage the player of a single-player world, get a <see cref="Level"/> object for the world instead.</remarks>
        public PlayerManager GetPlayerManager ()
        {
            return GetPlayerManagerVirt() as PlayerManager;
        }

        /// <summary>
        /// Gets a <see cref="BetaDataManager"/> for managing data resources, such as maps.
        /// </summary>
        /// <returns>A <see cref="BetaDataManager"/> for this world.</returns>
        public DataManager GetDataManager ()
        {
            return GetDataManagerVirt() as DataManager;
        }

        /// <summary>
        /// Saves the world's <see cref="Level"/> data, and any <see cref="IChunk"/> objects known to have unsaved changes.
        /// </summary>
        public void Save ()
        {
            _level.Save();

            foreach (RegionChunkManager cm in _chunkMgrs.Values) {
                cm.Save();
            }
        }

        /// <summary>
        /// Gets the <see cref="ChunkCache"/> currently managing chunks in the default dimension.
        /// </summary>
        /// <returns>The <see cref="ChunkCache"/> for the default dimension, or null if the dimension was not found.</returns>
        public ChunkCache GetChunkCache ()
        {
            return GetChunkCache(Dimension.DEFAULT);
        }

        /// <summary>
        /// Gets the <see cref="ChunkCache"/> currently managing chunks in the given dimension.
        /// </summary>
        /// <param name="dim">The id of a dimension to look up.</param>
        /// <returns>The <see cref="ChunkCache"/> for the given dimension, or null if the dimension was not found.</returns>
        public ChunkCache GetChunkCache (Dimension dim)
        {
            if (_caches.ContainsKey(dim)) {
                return _caches[dim];
            }
            return null;
        }

        /// <summary>
        /// Opens an existing Beta-compatible Minecraft world and returns a new <see cref="BetaWorld"/> to represent it.
        /// </summary>
        /// <param name="path">The path to the directory containing the world's level.dat, or the path to level.dat itself.</param>
        /// <returns>A new <see cref="BetaWorld"/> object representing an existing world on disk.</returns>
        public static AnvilWorld Open (string path)
        {
            return new AnvilWorld().OpenWorld(path) as AnvilWorld;
        }

        /// <summary>
        /// Opens an existing Beta-compatible Minecraft world and returns a new <see cref="BetaWorld"/> to represent it.
        /// </summary>
        /// <param name="path">The path to the directory containing the world's level.dat, or the path to level.dat itself.</param>
        /// <param name="cacheSize">The preferred cache size in chunks for each opened dimension in this world.</param>
        /// <returns>A new <see cref="BetaWorld"/> object representing an existing world on disk.</returns>
        public static AnvilWorld Open (string path, int cacheSize)
        {
            AnvilWorld world = new AnvilWorld().OpenWorld(path);
            world._prefCacheSize = cacheSize;

            return world;
        }

        /// <summary>
        /// Creates a new Beta-compatible Minecraft world and returns a new <see cref="BetaWorld"/> to represent it.
        /// </summary>
        /// <param name="path">The path to the directory where the new world should be stored.</param>
        /// <returns>A new <see cref="BetaWorld"/> object representing a new world.</returns>
        /// <remarks>This method will attempt to create the specified directory immediately if it does not exist, but will not
        /// write out any world data unless it is explicitly saved at a later time.</remarks>
        public static AnvilWorld Create (string path)
        {
            return new AnvilWorld().CreateWorld(path) as AnvilWorld;
        }

        /// <summary>
        /// Creates a new Beta-compatible Minecraft world and returns a new <see cref="BetaWorld"/> to represent it.
        /// </summary>
        /// <param name="path">The path to the directory where the new world should be stored.</param>
        /// <param name="cacheSize">The preferred cache size in chunks for each opened dimension in this world.</param>
        /// <returns>A new <see cref="BetaWorld"/> object representing a new world.</returns>
        /// <remarks>This method will attempt to create the specified directory immediately if it does not exist, but will not
        /// write out any world data unless it is explicitly saved at a later time.</remarks>
        public static AnvilWorld Create (string path, int cacheSize)
        {
            AnvilWorld world = new AnvilWorld().CreateWorld(path);
            world._prefCacheSize = cacheSize;

            return world;
        }

        /// <summary>
        /// Virtual implementor of <see cref="GetBlockManager(int)"/>.
        /// </summary>
        /// <param name="dim">The given dimension to fetch an <see cref="IBlockManager"/> for.</param>
        /// <returns>An <see cref="IBlockManager"/> for the given dimension in the world.</returns>
        protected IBlockManager GetBlockManagerVirt (Dimension dim)
        {
            BlockManager rm;
            if (_blockMgrs.TryGetValue(dim, out rm)) {
                return rm;
            }

            OpenDimension(dim);
            return _blockMgrs[dim];
        }

        /// <summary>
        /// Virtual implementor of <see cref="GetChunkManager(int)"/>.
        /// </summary>
        /// <param name="dim">The given dimension to fetch an <see cref="IChunkManager"/> for.</param>
        /// <returns>An <see cref="IChunkManager"/> for the given dimension in the world.</returns>
        protected IChunkManager GetChunkManagerVirt (Dimension dim)
        {
            RegionChunkManager rm;
            if (_chunkMgrs.TryGetValue(dim, out rm)) {
                return rm;
            }

            OpenDimension(dim);
            return _chunkMgrs[dim];
        }

        /// <summary>
        /// Virtual implementor of <see cref="GetPlayerManager"/>.
        /// </summary>
        /// <returns>An <see cref="IPlayerManager"/> for the given dimension in the world.</returns>
        protected IPlayerManager GetPlayerManagerVirt ()
        {
            if (_playerMan != null) {
                return _playerMan;
            }

            string path = IO.Path.Combine(Path, _PLAYER_DIR);

            _playerMan = new PlayerManager(path);
            return _playerMan;
        }

        /// <summary>
        /// Virtual implementor of <see cref="GetDataManager"/>
        /// </summary>
        /// <returns>A <see cref="DataManager"/> for the given dimension in the world.</returns>
        protected Data.DataManager GetDataManagerVirt ()
        {
            if (_dataMan != null) {
                return _dataMan;
            }

            _dataMan = new DataManager(this);
            return _dataMan;
        }

        private void OpenDimension (Dimension dim)
        {
            string path = Path;
            if (dim == Dimension.DEFAULT) {
                path = IO.Path.Combine(path, _REGION_DIR);
            }
            else {
                path = IO.Path.Combine(path, "DIM" + dim);
                path = IO.Path.Combine(path, _REGION_DIR);
            }

            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }

            ChunkCache cc = new ChunkCache(_prefCacheSize);

            AnvilRegionManager rm = new AnvilRegionManager(path, cc);
            RegionChunkManager cm = new RegionChunkManager(rm, cc);
            BlockManager bm = new AnvilBlockManager(cm);

            _regionMgrs[dim] = rm;
            _chunkMgrs[dim] = cm;
            _blockMgrs[dim] = bm;

            _caches[dim] = cc;
        }

        private AnvilWorld OpenWorld (string path)
        {
            if (!Directory.Exists(path)) {
                if (File.Exists(path)) {
                    _levelFile = IO.Path.GetFileName(path);
                    path = IO.Path.GetDirectoryName(path);
                }
                else {
                    throw new DirectoryNotFoundException("Directory '" + path + "' not found");
                }
            }

            Path = path;

            string ldat = IO.Path.Combine(path, _levelFile);
            if (!File.Exists(ldat)) {
                throw new FileNotFoundException("Data file '" + _levelFile + "' not found in '" + path + "'", ldat);
            }

            if (!LoadLevel()) {
                throw new Exception("Failed to load '" + _levelFile + "'");
            }

            return this;
        }

        private AnvilWorld CreateWorld (string path)
        {
            if (!Directory.Exists(path)) {
                throw new DirectoryNotFoundException("Directory '" + path + "' not found");
            }

            string regpath = IO.Path.Combine(path, _REGION_DIR);
            if (!Directory.Exists(regpath)) {
                Directory.CreateDirectory(regpath);
            }

            Path = path;
            _level = new Level(this);

            return this;
        }

        private bool LoadLevel ()
        {
            NBTFile nf = new NBTFile(IO.Path.Combine(Path, _levelFile));
            Stream nbtstr = nf.GetDataInputStream();
            if (nbtstr == null) {
                return false;
            }

            NbtTree tree = new NbtTree(nbtstr);

            _level = new Level(this);
            _level = _level.LoadTreeSafe(tree.Root);

            return _level != null;
        }

        internal static void OnResolveOpen (object sender, OpenWorldEventArgs e)
        {
            try {
                AnvilWorld world = new AnvilWorld().OpenWorld(e.Path);
                if (world == null) {
                    return;
                }

                string regPath = IO.Path.Combine(e.Path, _REGION_DIR);
                if (!Directory.Exists(regPath)) {
                    return;
                }

                if (world.Level.Version < 19133) {
                    return;
                }

                e.AddHandler(Open);
            }
            catch (Exception) {
                return;
            }
        }


        private const string _DATA_DIR = "data";

        private string _path;
        private string _dataDir;

        /// <summary>
        /// Gets or sets the path to the directory containing the world.
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        /// <summary>
        /// Gets or sets the directory containing data resources, rooted in the world directory.
        /// </summary>
        public string DataDirectory
        {
            get { return _dataDir; }
            set { _dataDir = value; }
        }

        /// <summary>
        /// Attempts to determine the best matching world type of the given path, and open the world as that type.
        /// </summary>
        /// <param name="path">The path to the directory containing the world.</param>
        /// <returns>A concrete <see cref="NbtWorld"/> type, or null if the world cannot be opened or is ambiguos.</returns>
        public static AnvilWorld OpenNbtWorld(string path)
        {
            if (ResolveOpen == null) {
                return null;
            }

            OpenWorldEventArgs eventArgs = new OpenWorldEventArgs(path);
            ResolveOpen(null, eventArgs);

            if (eventArgs.HandlerCount != 1) {
                return null;
            }


            foreach (OpenWorldCallback callback in eventArgs.Handlers) {
                return callback(path);
            }

            return null;
        }


        /// <summary>
        /// Raised when <see cref="Open"/> is called, used to find a concrete <see cref="NbtWorld"/> type that can open the world.
        /// </summary>
        protected static event EventHandler<OpenWorldEventArgs> ResolveOpen;

        static AnvilWorld ()
        {
            ResolveOpen += AnvilWorld.OnResolveOpen;
            //            ResolveOpen += BetaWorld.OnResolveOpen;
            //            ResolveOpen += AlphaWorld.OnResolveOpen;
        }
    }
}
