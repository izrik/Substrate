using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    /// <summary>
    /// An unbounded container for blocks supporting active processing properties.
    /// </summary>
    /// <seealso cref="IBoundedActiveBlockCollection"/>
    public interface IActiveBlockCollection : IBlockCollection
    {
        /// <summary>
        /// Gets a block supporting active processing properties from an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>An <see cref="IActiveBlock"/> from the collection at the given coordinates.</returns>
        new IActiveBlock GetBlock (int x, int y, int z);

        /// <summary>
        /// Gets a reference object to a block supporting active processing properties within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>An <see cref="IActiveBlock"/> acting as a reference directly into the container at the given coordinates.</returns>
        new IActiveBlock GetBlockRef (int x, int y, int z);

        /// <summary>
        /// Updates a block in an unbounded block container with data from an existing <see cref="IActiveBlock"/> object.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="block">The <see cref="IActiveBlock"/> to copy data from.</param>
        void SetBlock (int x, int y, int z, IActiveBlock block);

        /// <summary>
        /// Gets the <see cref="TileTick"/> record of a block within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>A <see cref="TileTick"/> record attached to a block at the given coordinates, or null if no tile entity is set.</returns>
        TileTick GetTileTick (int x, int y, int z);

        /// <summary>
        /// Sets a <see cref="TileTick"/> record to a block within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="tt">The <see cref="TileTick"/> record to assign to the given block.</param>
        void SetTileTick (int x, int y, int z, TileTick tt);

        /// <summary>
        /// Creates a new default <see cref="TileTick"/> record for a block within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        void CreateTileTick (int x, int y, int z);

        /// <summary>
        /// Deletes a <see cref="TileTick"/> record associated with a block within an unbounded block container, if it exists.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        void ClearTileTick (int x, int y, int z);

        /// <summary>
        /// Gets the tick delay specified in a block's <see cref="TileTick"/> entry, if it exists.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>The tick delay in a block's <see cref="TileTick"/> entry, or <c>0</c> if no entry exists.</returns>
        int GetTileTickValue (int x, int y, int z);

        /// <summary>
        /// Sets the tick delay in a block's <see cref="TileTick"/> entry.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="tickValue">The tick delay that specifies when this block should next be processed for update.</param>
        void SetTileTickValue (int x, int y, int z, int tickValue);
    }

}
