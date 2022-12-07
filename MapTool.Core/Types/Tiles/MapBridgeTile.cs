using MapTool.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Types.Tiles
{
    public class MapBridgeTile : Tile
    {
        public MapBridgeTile(string name, string description, int startX, int startY, int width, int height, Map destinationMap) : base(name, description, startX, startY, width, height)
        {
            DestinationMap = destinationMap;
        }

        /// <summary>
        /// The map this tile is a gateway to.
        /// </summary>
        public Map DestinationMap { get; set; }
    }
}
