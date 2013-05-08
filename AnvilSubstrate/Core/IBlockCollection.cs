using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    /// <summary>
    /// A basic unconstrained container of blocks.
    /// </summary>
    /// <remarks>The scope of coordinates is undefined for unconstrained block containers.</remarks>
    public interface IBlockCollection
    {
        /// <summary>
        /// Gets a basic block from an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>A basic <see cref="IBlock"/> from the collection at the given coordinates.</returns>
        IBlock GetBlock (int x, int y, int z);

        /// <summary>
        /// Gets a reference object to a basic block within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>A basic <see cref="IBlock"/> acting as a reference directly into the container at the given coordinates.</returns>
        IBlock GetBlockRef (int x, int y, int z);

        /// <summary>
        /// Updates a block in an unbounded block container with data from an existing <see cref="IBlock"/> object.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="block">The <see cref="IBlock"/> to copy basic data from.</param>
        void SetBlock (int x, int y, int z, IBlock block);

        /// <summary>
        /// Gets a block's id (type) from an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>The block id (type) from the block container at the given coordinates.</returns>
        int GetID (int x, int y, int z);

        /// <summary>
        /// Sets a block's id (type) within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="id">The id (type) to assign to a block at the given coordinates.</param>
        void SetID (int x, int y, int z, int id);

        /// <summary>
        /// Gets info and attributes on a block's type within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>A <see cref="BlockInfo"/> instance for the block's type.</returns>
        BlockInfo GetInfo (int x, int y, int z);
    }

}
