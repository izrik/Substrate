using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Substrate.Core;
using Substrate.Nbt;

namespace Substrate
{
    /// <summary>
    /// A collection of constants to specify different Minecraft world dimensions.
    /// </summary>
    public enum Dimension : int
    {
        /// <summary>
        /// Specifies the Nether dimension.
        /// </summary>
        NETHER = -1,

        /// <summary>
        /// Specifies the default overworld.
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        /// Specifies the Enderman dimension, The End.
        /// </summary>
        THE_END = 1,
    }

    public class DimensionNotFoundException : Exception { }
}
