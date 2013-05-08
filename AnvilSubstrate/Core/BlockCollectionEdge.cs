using System;

namespace Substrate.Core
{
    /// <summary>
    /// Represents the cardinal direction of a block collection's neighboring collection.
    /// </summary>
    public enum BlockCollectionEdge
    {
        /// <summary>
        /// Refers to a chunk/collection to the east of the current chunk/collection.
        /// </summary>
        EAST = 0,

        /// <summary>
        /// Refers to a chunk/collection to the north of the current chunk/collection.
        /// </summary>
        NORTH = 1,

        /// <summary>
        /// Refers to a chunk/collection to the west of the current chunk/collection.
        /// </summary>
        WEST = 2,

        /// <summary>
        /// Refers to a chunk/collection to the south of the current chunk/collection.
        /// </summary>
        SOUTH = 3
    }
}
