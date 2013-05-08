using System;

namespace Substrate.Core
{
    /// <summary>
    /// A block type supporting dual-source lighting.
    /// </summary>
    public interface ILitBlock : IBlock
    {
        /// <summary>
        /// Gets or sets the block-source light value on this block.
        /// </summary>
        int BlockLight { get; set; }

        /// <summary>
        /// Gets or sets the sky-source light value on this block.
        /// </summary>
        int SkyLight { get; set; }
    }
}
