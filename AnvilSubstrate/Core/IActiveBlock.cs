using System;

namespace Substrate.Core
{
    /// <summary>
    /// A block type supporting active tick state.
    /// </summary>
    public interface IActiveBlock : IBlock
    {
        /// <summary>
        /// Gets a <see cref="TileTick"/> entry attached to this block.
        /// </summary>
        /// <returns>A <see cref="TileTick"/> for this block, or null if one has not been created yet.</returns>
        TileTick GetTileTick ();

        /// <summary>
        /// Sets the <see cref="TileTick"/> attached to this block.
        /// </summary>
        /// <param name="tt">A <see cref="TileTick"/> representing the delay until this block is next processed in-game.</param>
        void SetTileTick (TileTick tt);

        /// <summary>
        /// Creates a default <see cref="TileTick"/> entry for this block.
        /// </summary>
        /// <remarks>This method will overwrite any existing <see cref="TileTick"/> attached to the block.</remarks>
        void CreateTileTick ();

        /// <summary>
        /// Deletes the <see cref="TileTick"/> entry attached to this block, if one exists.
        /// </summary>
        void ClearTileTick ();

        /// <summary>
        /// Gets or sets the the actual tick delay associated with this block.
        /// </summary>
        /// <remarks>If no underlying <see cref="TileTick"/> entry exists for this block, one will be created.</remarks>
        int TileTickValue { get; set; }
    }
}
