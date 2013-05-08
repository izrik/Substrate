using System;

namespace Substrate.Core
{
    /// <summary>
    /// A version-1.0-compatible reference type supporting data, lighting, properties, and active tick state.
    /// </summary>
    public interface IVersion10BlockRef : IAlphaBlockRef, IActiveBlock
    {
    }
}
