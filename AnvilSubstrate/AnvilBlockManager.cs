using System;
using Substrate.Core;

namespace Substrate
{

    public class AnvilBlockManager : BlockManager
    {
        public AnvilBlockManager (IChunkManager cm)
            : base(cm)
        {
            IChunk c = AnvilChunk.Create(0, 0);

            chunkXDim = c.Blocks.XDim;
            chunkYDim = c.Blocks.YDim;
            chunkZDim = c.Blocks.ZDim;
            chunkXMask = chunkXDim - 1;
            chunkYMask = chunkYDim - 1;
            chunkZMask = chunkZDim - 1;
            chunkXLog = Log2(chunkXDim);
            chunkYLog = Log2(chunkYDim);
            chunkZLog = Log2(chunkZDim);
        }
    }

    /// <summary>
    /// Represents an Alpha-compatible interface for globally managing blocks.
    /// </summary>
    
}
