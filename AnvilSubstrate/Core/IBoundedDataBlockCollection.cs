using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    /// <summary>
    /// A bounded container of blocks supporting data fields.
    /// </summary>
    /// <seealso cref="IDataBlockCollection"/>
    public interface IBoundedDataBlockCollection : IBoundedBlockCollection
    {
        /// <summary>
        /// Gets a block with data field from a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>An <see cref="IDataBlock"/> from the collection at the given coordinates.</returns>
        new IDataBlock GetBlock (int x, int y, int z);

        /// <summary>
        /// Gets a reference object to a block with data field within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>An <see cref="IDataBlock"/> acting as a reference directly into the container at the given coordinates.</returns>
        new IDataBlock GetBlockRef (int x, int y, int z);

        /// <summary>
        /// Updates a block in a bounded block container with data from an existing <see cref="IDataBlock"/> object.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <param name="block">The <see cref="IDataBlock"/> to copy data from.</param>
        void SetBlock (int x, int y, int z, IDataBlock block);

        /// <summary>
        /// Gets a block's data field from a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>The data field of a block at the given coordinates.</returns>
        int GetData (int x, int y, int z);

        /// <summary>
        /// Sets a block's data field within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <param name="data">The data field to assign to a block at the given coordinates.</param>
        void SetData (int x, int y, int z, int data);

        /// <summary>
        /// Counts all blocks within a bounded container set to a given id (type) and data value.
        /// </summary>
        /// <param name="id">The id (type) of blocks to match.</param>
        /// <param name="data">The data value of blocks to match.</param>
        /// <returns>A count of all blocks in the container matching both conditions.</returns>
        int CountByData (int id, int data);
    }
}
