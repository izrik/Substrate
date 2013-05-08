using System;

namespace Substrate.Core
{
    /// <summary>
    /// An Alpha-compatible block reference type supporting data, lighting, and properties.
    /// </summary>
    public interface IAlphaBlockRef : IDataBlock, ILitBlock, IPropertyBlock
    {
        /// <summary>
        /// Checks if the reference and its backing container are currently valid.
        /// </summary>
        bool IsValid { get; }
    }
}
