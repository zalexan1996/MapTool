using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Domain.Types.UtilityTiles
{
    /// <summary>
    /// A type of tile used to convey asset spawning information.
    /// </summary>
    public class SpawnerTile : Tile
    {
        /// <summary>
        /// The type of asset this tile is used to spawn.
        /// </summary>
        public string AssetReference { get; set; } = string.Empty;
    }
}
