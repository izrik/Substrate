using System;

namespace Substrate.Core
{
    /// <summary>
    /// Provides a common interface for block containers that provide global management, extended through Version 1.0 capabilities.
    /// </summary>
    public interface IVersion10BlockManager : IBlockManager, IActiveBlockCollection
    {
    }
}
