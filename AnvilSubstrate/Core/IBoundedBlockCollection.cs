using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    /// <summary>
    /// A container of blocks with set dimensions.
    /// </summary>
    public interface IBoundedBlockCollection
    {
        /// <summary>
        /// Gets the length of the X-dimension of the container.
        /// </summary>
        int XDim { get; }

        /// <summary>
        /// Gets the length of the Y-dimension of the container.
        /// </summary>
        int YDim { get; }

        /// <summary>
        /// Gets the length of the Z-dimension of the container.
        /// </summary>
        int ZDim { get; }

        /// <summary>
        /// Counts all instances of a block with the given type in the bounded block container.
        /// </summary>
        /// <param name="id">The id (type) of the block to count.</param>
        /// <returns>The count of blocks in the container matching the given id (type).</returns>
        int CountByID (int id);

        /// <summary>
        /// Gets a basic block from a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>A basic <see cref="IBlock"/> from the collection at the given coordinates.</returns>
        IBlock GetBlock (int x, int y, int z);

        /// <summary>
        /// Gets a reference object to a basic within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>A basic <see cref="IBlock"/> acting as a reference directly into the container at the given coordinates.</returns>
        IBlock GetBlockRef (int x, int y, int z);

        /// <summary>
        /// Updates a block in a bounded block container with data from an existing <see cref="IBlock"/> object.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <param name="block">The <see cref="IBlock"/> to copy basic data from.</param>
        void SetBlock (int x, int y, int z, IBlock block);

        /// <summary>
        /// Gets a block's id (type) from a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>The block id (type) from the block container at the given coordinates.</returns>
        int GetID (int x, int y, int z);

        /// <summary>
        /// Sets a block's id (type) within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <param name="id">The id (type) to assign to a block at the given coordinates.</param>
        void SetID (int x, int y, int z, int id);

        /// <summary>
        /// Gets info and attributes on a block's type within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>A <see cref="BlockInfo"/> instance for the block's type.</returns>
        BlockInfo GetInfo (int x, int y, int z);
    }
}
