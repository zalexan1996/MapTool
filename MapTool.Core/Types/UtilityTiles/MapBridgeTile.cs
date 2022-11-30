using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Types.UtilityTiles
{
    /// <summary>
    /// A type of tile used for connecting two maps together (door, edge of map transition).
    /// </summary>
    public class MapBridgeTile : Tile
    {
        /// <summary>
        /// The map this tile is a gateway to.
        /// </summary>
        public Map DestinationMap { get; set; }
    }
}
