using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.Core
{
    /// <summary>
    /// A bounded container of blocks supporting dual-source lighting.
    /// </summary>
    /// <seealso cref="ILitBlockCollection"/>
    public interface IBoundedLitBlockCollection : IBoundedBlockCollection
    {
        /// <summary>
        /// Gets a block with lighting information from a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>An <see cref="ILitBlock"/> from the collection at the given coordinates.</returns>
        new ILitBlock GetBlock (int x, int y, int z);

        /// <summary>
        /// Gets a reference object to a block with lighting information within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>An <see cref="ILitBlock"/> acting as a reference directly into the container at the given coordinates.</returns>
        new ILitBlock GetBlockRef (int x, int y, int z);

        /// <summary>
        /// Updates a block in a bounded block container with data from an existing <see cref="ILitBlock"/> object.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <param name="block">The <see cref="ILitBlock"/> to copy data from.</param>
        void SetBlock (int x, int y, int z, ILitBlock block);

        /// <summary>
        /// Gets a block's block-source light value from a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>The block-source light value of a block at the given coordinates.</returns>
        int GetBlockLight (int x, int y, int z);

        /// <summary>
        /// Gets a block's sky-source light value from a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>The sky-source light value of a block at the given coordinates.</returns>
        int GetSkyLight (int x, int y, int z);

        /// <summary>
        /// Sets a block's block-source light value within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <param name="light">The block-source light value to assign to a block at the given coordinates.</param>
        void SetBlockLight (int x, int y, int z, int light);

        /// <summary>
        /// Sets a block's sky-source light value within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <param name="light">The sky-source light value to assign to a block at the given coordinates.</param>
        void SetSkyLight (int x, int y, int z, int light);

        /// <summary>
        /// Gets the Y-coordinate of the lowest block with unobstructed view of the sky at the given coordinates within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <returns>The height value of an X-Z coordinate pair in the block container.</returns>
        /// <remarks>The height value represents the lowest block with an unobstructed view of the sky.  This is the lowest block with
        /// a maximum-value sky-light value.  Fully transparent blocks, like glass, do not count as an obstruction.</remarks>
        int GetHeight (int x, int z);

        /// <summary>
        /// Sets the Y-coordinate of the lowest block with unobstructed view of the sky at the given coordinates within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <param name="height">The height value of an X-Z coordinate pair in the block container.</param>
        /// <remarks>Minecraft lighting algorithms rely heavily on this value being correct.  Setting this value too low may result in
        /// rooms that can never get dark, for example.</remarks>
        void SetHeight (int x, int z, int height);

        /// <summary>
        /// Recalculates the block-source light value of a single block within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <remarks><para>The lighting of the block will be updated to be consistent with the lighting in neighboring blocks.
        /// If the block is itself a light source, many nearby blocks may be updated to maintain consistent lighting.  These
        /// updates may also touch neighboring <see cref="ILitBlockCollection"/> objects, if they can be resolved.</para>
        /// <para>This function assumes that the entire <see cref="ILitBlockCollection"/> and neighboring <see cref="ILitBlockCollection"/>s
        /// already have consistent lighting, with the exception of the block being updated.  If this assumption is violated, 
        /// lighting may fail to converge correctly.</para></remarks>
        void UpdateBlockLight (int x, int y, int z);

        /// <summary>
        /// Recalculates the sky-source light value of a single block within a bounded block container.
        /// </summary>
        /// <param name="x">The container-local X-coordinate of a block.</param>
        /// <param name="y">The container-local Y-coordinate of a block.</param>
        /// <param name="z">The container-local Z-coordinate of a block.</param>
        /// <remarks><para>The lighting of the block will be updated to be consistent with the lighting in neighboring blocks.
        /// If the block is itself a light source, many nearby blocks may be updated to maintain consistent lighting.  These
        /// updates may also touch neighboring <see cref="ILitBlockCollection"/> objects, if they can be resolved.</para>
        /// <para>This function assumes that the entire <see cref="ILitBlockCollection"/> and neighboring <see cref="ILitBlockCollection"/>s
        /// already have consistent lighting, with the exception of the block being updated.  If this assumption is violated,
        /// lighting may fail to converge correctly.</para></remarks>
        void UpdateSkyLight (int x, int y, int z);

        /// <summary>
        /// Resets the block-source light value to 0 for all blocks within a bounded block container.
        /// </summary>
        void ResetBlockLight ();

        /// <summary>
        /// Resets the sky-source light value to 0 for all blocks within a bounded block container.
        /// </summary>
        void ResetSkyLight ();

        /// <summary>
        /// Reconstructs the block-source lighting for all blocks within a bounded block container.
        /// </summary>
        /// <remarks><para>This function should only be called after the lighting has been reset in this <see cref="IBoundedLitBlockCollection"/>
        /// and all neighboring <see cref="IBoundedLitBlockCollection"/>s, or lighting may fail to converge correctly.  
        /// This function cannot reset the lighting on its own, due to interactions between <see cref="IBoundedLitBlockCollection"/>s.</para>
        /// <para>If many light source or block opacity values will be modified in this <see cref="IBoundedLitBlockCollection"/>, it may
        /// be preferable to avoid explicit or implicit calls to <see cref="UpdateBlockLight"/> and call this function once when
        /// modifications are complete.</para></remarks>
        /// <seealso cref="ResetBlockLight"/>
        void RebuildBlockLight ();

        /// <summary>
        /// Reconstructs the sky-source lighting for all blocks within a bounded block container.
        /// </summary>
        /// <remarks><para>This function should only be called after the lighting has been reset in this <see cref="IBoundedLitBlockCollection"/>
        /// and all neighboring <see cref="IBoundedLitBlockCollection"/>s, or lighting may fail to converge correctly.  
        /// This function cannot reset the lighting on its own, due to interactions between <see cref="IBoundedLitBlockCollection"/>s.</para>
        /// <para>If many light source or block opacity values will be modified in this <see cref="IBoundedLitBlockCollection"/>, it may
        /// be preferable to avoid explicit or implicit calls to <see cref="UpdateSkyLight"/> and call this function once when
        /// modifications are complete.</para></remarks>
        /// <seealso cref="ResetSkyLight"/>
        void RebuildSkyLight ();

        /// <summary>
        /// Reconstructs the height-map for a bounded block container.
        /// </summary>
        void RebuildHeightMap ();

        /// <summary>
        /// Reconciles any block-source lighting inconsistencies between this <see cref="IBoundedLitBlockCollection"/> and any of its neighbors.
        /// </summary>
        /// <remarks>It will be necessary to call this function if an <see cref="IBoundedLitBlockCollection"/> is reset and rebuilt, but
        /// some of its neighbors are not.  A rebuilt <see cref="IBoundedLitBlockCollection"/> will spill lighting updates into its neighbors,
        /// but will not see lighting that should be propagated back from its neighbors.</remarks>
        /// <seealso cref="RebuildBlockLight"/>
        void StitchBlockLight ();

        /// <summary>
        /// Reconciles any sky-source lighting inconsistencies between this <see cref="IBoundedLitBlockCollection"/> and any of its neighbors.
        /// </summary>
        /// <remarks>It will be necessary to call this function if an <see cref="IBoundedLitBlockCollection"/> is reset and rebuilt, but
        /// some of its neighbors are not.  A rebuilt <see cref="IBoundedLitBlockCollection"/> will spill lighting updates into its neighbors,
        /// but will not see lighting that should be propagated back from its neighbors.</remarks>
        /// <seealso cref="RebuildSkyLight"/>
        void StitchSkyLight ();

        /// <summary>
        /// Reconciles any block-source lighting inconsistencies between this <see cref="IBoundedLitBlockCollection"/> and another <see cref="IBoundedLitBlockCollection"/> on a given edge.
        /// </summary>
        /// <param name="blockset">An <see cref="IBoundedLitBlockCollection"/>-compatible object with the same dimensions as this <see cref="IBoundedLitBlockCollection"/>.</param>
        /// <param name="edge">The edge that <paramref name="blockset"/> is a neighbor on.</param>
        /// <remarks>It will be necessary to call this function if an <see cref="IBoundedLitBlockCollection"/> is reset and rebuilt, but
        /// some of its neighbors are not.  A rebuilt <see cref="IBoundedLitBlockCollection"/> will spill lighting updates into its neighbors,
        /// but will not see lighting that should be propagated back from its neighbors.</remarks>
        /// <seealso cref="RebuildBlockLight"/>
        void StitchBlockLight (IBoundedLitBlockCollection blockset, BlockCollectionEdge edge);

        /// <summary>
        /// Reconciles any sky-source lighting inconsistencies between this <see cref="IBoundedLitBlockCollection"/> and another <see cref="IBoundedLitBlockCollection"/> on a given edge.
        /// </summary>
        /// <param name="blockset">An <see cref="IBoundedLitBlockCollection"/>-compatible object with the same dimensions as this <see cref="IBoundedLitBlockCollection"/>.</param>
        /// <param name="edge">The edge that <paramref name="blockset"/> is a neighbor on.</param>
        /// <remarks>It will be necessary to call this function if an <see cref="IBoundedLitBlockCollection"/> is reset and rebuilt, but
        /// some of its neighbors are not.  A rebuilt <see cref="IBoundedLitBlockCollection"/> will spill lighting updates into its neighbors,
        /// but will not see lighting that should be propagated back from its neighbors.</remarks>
        /// <seealso cref="RebuildSkyLight"/>
        void StitchSkyLight (IBoundedLitBlockCollection blockset, BlockCollectionEdge edge);
    }
}
