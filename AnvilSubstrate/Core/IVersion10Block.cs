using System;

namespace Substrate.Core
{
    /// <summary>
    /// A version-1.0-compatible context-free block type supporting data, properties, and active tick state.
    /// </summary>
    public interface IVersion10Block : IAlphaBlock, IActiveBlock
    {
    }
}
