using System;

namespace Substrate.Core
{
    /// <summary>
    /// A block type supporting properties.
    /// </summary>
    public interface IPropertyBlock : IBlock
    {
        /// <summary>
        /// Gets a tile entity attached to this block.
        /// </summary>
        /// <returns>A <see cref="TileEntity"/> for this block, or null if this block type does not support a tile entity.</returns>
        TileEntity GetTileEntity ();

        /// <summary>
        /// Sets the tile entity attached to this block.
        /// </summary>
        /// <param name="te">A <see cref="TileEntity"/> supported by this block type.</param>
        /// <exception cref="ArgumentException">Thrown when the <see cref="TileEntity"/> being passed is of the wrong type for the given block.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the given block is of a type that does not support a <see cref="TileEntity"/> record.</exception>
        void SetTileEntity (TileEntity te);

        /// <summary>
        /// Creates a default tile entity for this block consistent with its type.
        /// </summary>
        /// <remarks>This method will overwrite any existing <see cref="TileEntity"/> attached to the block.</remarks>
        /// <exception cref="InvalidOperationException">Thrown when the given block is of a type that does not support a <see cref="TileEntity"/> record.</exception>
        /// <exception cref="UnknownTileEntityException">Thrown when the block type requests a <see cref="TileEntity"/> that has not been registered with the <see cref="TileEntityFactory"/>.</exception>
        void CreateTileEntity ();

        /// <summary>
        /// Deletes the tile entity attached to this block if one exists.
        /// </summary>
        void ClearTileEntity ();
    }
}
