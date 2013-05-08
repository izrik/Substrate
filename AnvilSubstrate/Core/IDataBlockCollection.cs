using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    /// <summary>
    /// An unbounded container of blocks supporting data fields.
    /// </summary>
    /// <seealso cref="IBoundedDataBlockCollection"/>
    public interface IDataBlockCollection : IBlockCollection
    {
        /// <summary>
        /// Gets a block with data field from an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>An <see cref="IDataBlock"/> from the collection at the given coordinates.</returns>
        new IDataBlock GetBlock (int x, int y, int z);

        /// <summary>
        /// Gets a reference object to a block with data field within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>An <see cref="IDataBlock"/> acting as a reference directly into the container at the given coordinates.</returns>
        new IDataBlock GetBlockRef (int x, int y, int z);

        /// <summary>
        /// Updates a block in an unbounded block container with data from an existing <see cref="IDataBlock"/> object.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="block">The <see cref="IDataBlock"/> to copy data from.</param>
        void SetBlock (int x, int y, int z, IDataBlock block);

        /// <summary>
        /// Gets a block's data field from an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>The data field of a block at the given coordinates.</returns>
        int GetData (int x, int y, int z);

        /// <summary>
        /// Sets a block's data field within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="data">The data field to assign to a block at the given coordinates.</param>
        void SetData (int x, int y, int z, int data);
    }
}
