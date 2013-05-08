using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    /// <summary>
    /// An unbounded container for blocks supporting extra properties.
    /// </summary>
    /// <seealso cref="IBoundedPropertyBlockCollection"/>
    public interface IPropertyBlockCollection : IBlockCollection
    {
        /// <summary>
        /// Gets a block supporting extra properties from an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>An <see cref="IPropertyBlock"/> from the collection at the given coordinates.</returns>
        new IPropertyBlock GetBlock (int x, int y, int z);

        /// <summary>
        /// Gets a reference object to a block supporting extra properties within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>An <see cref="IPropertyBlock"/> acting as a reference directly into the container at the given coordinates.</returns>
        new IPropertyBlock GetBlockRef (int x, int y, int z);

        /// <summary>
        /// Updates a block in an unbounded block container with data from an existing <see cref="IPropertyBlock"/> object.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="block">The <see cref="IPropertyBlock"/> to copy data from.</param>
        void SetBlock (int x, int y, int z, IPropertyBlock block);

        /// <summary>
        /// Gets the <see cref="TileEntity"/> record of a block within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>A <see cref="TileEntity"/> record attached to a block at the given coordinates, or null if no tile entity is set.</returns>
        TileEntity GetTileEntity (int x, int y, int z);

        /// <summary>
        /// Sets a <see cref="TileEntity"/> record to a block within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="te">The <see cref="TileEntity"/> record to assign to the given block.</param>
        /// <exception cref="ArgumentException">Thrown when an incompatible <see cref="TileEntity"/> is added to a block.</exception>
        /// <exception cref="InvalidOperationException">Thrown when a <see cref="TileEntity"/> is added to a block that does not use tile entities.</exception>
        void SetTileEntity (int x, int y, int z, TileEntity te);

        /// <summary>
        /// Creates a new default <see cref="TileEntity"/> record for a block within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <exception cref="InvalidOperationException">Thrown when a <see cref="TileEntity"/> is created for a block that does not use tile entities.</exception>
        /// <exception cref="UnknownTileEntityException">Thrown when the tile entity type associated with the given block has not been registered with <see cref="TileEntityFactory"/>.</exception>
        void CreateTileEntity (int x, int y, int z);

        /// <summary>
        /// Deletes a <see cref="TileEntity"/> record associated with a block within an unbounded block container, if it exists.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        void ClearTileEntity (int x, int y, int z);
    }

}
