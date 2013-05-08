using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    /// <summary>
    /// An unbounded container of blocks supporting dual-source lighting.
    /// </summary>
    /// <seealso cref="IBoundedLitBlockCollection"/>
    public interface ILitBlockCollection : IBlockCollection
    {
        /// <summary>
        /// Gets a block with lighting information from an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>An <see cref="ILitBlock"/> from the collection at the given coordinates.</returns>
        new ILitBlock GetBlock (int x, int y, int z);

        /// <summary>
        /// Gets a reference object to a block with lighting information within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>An <see cref="ILitBlock"/> acting as a reference directly into the container at the given coordinates.</returns>
        new ILitBlock GetBlockRef (int x, int y, int z);

        /// <summary>
        /// Updates a block in an unbounded block container with data from an existing <see cref="ILitBlock"/> object.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="block">The <see cref="ILitBlock"/> to copy data from.</param>
        void SetBlock (int x, int y, int z, ILitBlock block);

        /// <summary>
        /// Gets a block's block-source light value from an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>The block-source light value of a block at the given coordinates.</returns>
        int GetBlockLight (int x, int y, int z);

        /// <summary>
        /// Gets a block's sky-source light value from an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>The sky-source light value of a block at the given coordinates.</returns>
        int GetSkyLight (int x, int y, int z);

        /// <summary>
        /// Sets a block's block-source light value within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="light">The block-source light value to assign to a block at the given coordinates.</param>
        void SetBlockLight (int x, int y, int z, int light);

        /// <summary>
        /// Sets a block's sky-source light value within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="light">The sky-source light value to assign to a block at the given coordinates.</param>
        void SetSkyLight (int x, int y, int z, int light);

        /// <summary>
        /// Gets the Y-coordinate of the lowest block with unobstructed view of the sky at the given coordinates within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <returns>The height value of an X-Z coordinate pair in the block container.</returns>
        /// <remarks>The height value represents the lowest block with an unobstructed view of the sky.  This is the lowest block with
        /// a maximum-value sky-light value.  Fully transparent blocks, like glass, do not count as an obstruction.</remarks>
        int GetHeight (int x, int z);

        /// <summary>
        /// Sets the Y-coordinate of the lowest block with unobstructed view of the sky at the given coordinates within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <param name="height">The height value of an X-Z coordinate pair in the block container.</param>
        /// <remarks>Minecraft lighting algorithms rely heavily on this value being correct.  Setting this value too low may result in
        /// rooms that can never get dark, for example.</remarks>
        void SetHeight (int x, int z, int height);

        /// <summary>
        /// Recalculates the block-source light value of a single block within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <remarks><para>The lighting of the block will be updated to be consistent with the lighting in neighboring blocks.
        /// If the block is itself a light source, many nearby blocks may be updated to maintain consistent lighting.  These
        /// updates may also touch neighboring <see cref="ILitBlockCollection"/> objects, if they can be resolved.</para>
        /// <para>This function assumes that the entire <see cref="ILitBlockCollection"/> and neighboring <see cref="ILitBlockCollection"/>s
        /// already have consistent lighting, with the exception of the block being updated.  If this assumption is violated, 
        /// lighting may fail to converge correctly.</para></remarks>
        void UpdateBlockLight (int x, int y, int z);

        /// <summary>
        /// Recalculates the sky-source light value of a single block within an unbounded block container.
        /// </summary>
        /// <param name="x">The global X-coordinate of a block.</param>
        /// <param name="y">The global Y-coordinate of a block.</param>
        /// <param name="z">The global Z-coordinate of a block.</param>
        /// <remarks><para>The lighting of the block will be updated to be consistent with the lighting in neighboring blocks.
        /// If the block is itself a light source, many nearby blocks may be updated to maintain consistent lighting.  These
        /// updates may also touch neighboring <see cref="ILitBlockCollection"/> objects, if they can be resolved.</para>
        /// <para>This function assumes that the entire <see cref="ILitBlockCollection"/> and neighboring <see cref="ILitBlockCollection"/>s
        /// already have consistent lighting, with the exception of the block being updated.  If this assumption is violated,
        /// lighting may fail to converge correctly.</para></remarks>
        void UpdateSkyLight (int x, int y, int z);
    }

}
