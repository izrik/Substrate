using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    /// <summary>
    /// An unbounded container of blocks supporting data, lighting, and properties.
    /// </summary>
    /// <seealso cref="IBoundedAlphaBlockCollection"/>
    public interface IAlphaBlockCollection : IDataBlockCollection, ILitBlockCollection, IPropertyBlockCollection
    {
        /// <summary>
        /// Gets a context-insensitive Alpha-compatible block from an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>An <see cref="AlphaBlock"/> from the collection at the given coordinates.</returns>
        new AlphaBlock GetBlock (int x, int y, int z);

        /// <summary>
        /// Gets a reference object to a context-insensitive Alpha-compatible block within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>An <see cref="AlphaBlockRef"/> acting as a reference directly into the container at the given coordinates.</returns>
        new AlphaBlockRef GetBlockRef (int x, int y, int z);

        /// <summary>
        /// Updates a block in an unbounded block container with data from an existing <see cref="AlphaBlock"/> object.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="block">The <see cref="AlphaBlock"/> to copy data from.</param>
        void SetBlock (int x, int y, int z, AlphaBlock block);
    }
}
