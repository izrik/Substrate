using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    /// <summary>
    /// A bounded container of blocks supporting data, lighting, and properties.
    /// </summary>
    /// <seealso cref="IAlphaBlockCollection"/>
    public interface IBoundedAlphaBlockCollection : IBoundedDataBlockCollection, IBoundedLitBlockCollection, IBoundedPropertyBlockCollection
    {
        /// <summary>
        /// Gets a context-sensitive Alpha-compatible block from a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>An <see cref="AlphaBlock"/> from the collection at the given coordinates.</returns>
        new AlphaBlock GetBlock (int x, int y, int z);

        /// <summary>
        /// Gets a reference object to a context-sensitive Alpha-compatible block within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>An <see cref="AlphaBlockRef"/> acting as a reference directly into the container at the given coordinates.</returns>
        new AlphaBlockRef GetBlockRef (int x, int y, int z);

        /// <summary>
        /// Updates a block in a bounded block container with data from an existing <see cref="AlphaBlock"/> object.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <param name="block">The <see cref="AlphaBlock"/> to copy data from.</param>
        void SetBlock (int x, int y, int z, AlphaBlock block);
    }
}
