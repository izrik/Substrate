using System;
using System.Collections.Generic;
using System.IO;

namespace Substrate.Core
{
    /// <summary>
    /// Provides a common interface for chunk containers that provide global management.
    /// </summary>
    public interface IChunkManager : IChunkContainer, IEnumerable<ChunkRef>
    {

    }
}
