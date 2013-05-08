using System;

namespace Substrate.Core
{
    /// <summary>
    /// A block type supporting a data field.
    /// </summary>
    public interface IDataBlock : IBlock
    {
        /// <summary>
        /// Gets or sets a data value on the block.
        /// </summary>
        int Data { get; set; }
    }
}
