using System;

namespace Substrate.Core
{
    /// <summary>
    /// A basic block type.
    /// </summary>
    public interface IBlock
    {
        /// <summary>
        /// Gets a variety of info and attributes on the block's type.
        /// </summary>
        BlockInfo Info { get; }

        /// <summary>
        /// Gets or sets the block's id (type).
        /// </summary>
        int ID { get; set; }
    }
}
