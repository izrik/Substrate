using System;
using System.Collections.Generic;
using System.IO;

namespace Substrate.Core
{

    /// <summary>
    /// Provides a common interface for accessing Alpha-compatible chunk data.
    /// </summary>
    public interface IChunk
    {
        /// <summary>
        /// Gets the global X-coordinate of a chunk.
        /// </summary>
        int X { get; }

        /// <summary>
        /// Gets the global Z-coordinate of a chunk.
        /// </summary>
        int Z { get; }

        /// <summary>
        /// Gets access to an <see cref="AlphaBlockCollection"/> representing all block data of a chunk.
        /// </summary>
        AlphaBlockCollection Blocks { get; }

        /// <summary>
        /// Gets access to an <see cref="EntityCollection"/> representing all entity data of a chunk.
        /// </summary>
        EntityCollection Entities { get; }

        /// <summary>
        /// Gets or sets the flag indicating that the terrain generator has created terrain features.
        /// </summary>
        /// <remarks>Terrain features include ores, water and lava sources, dungeons, trees, flowers, etc.</remarks>
        bool IsTerrainPopulated { get; set; }

        void SetLocation (int x, int z);

        /// <summary>
        /// Writes out the chunk's data to an output stream.
        /// </summary>
        /// <param name="outStream">A valid, open output stream.</param>
        /// <returns>True if the chunk could be saved; false otherwise.</returns>
        bool Save (Stream outStream);
    }
}
