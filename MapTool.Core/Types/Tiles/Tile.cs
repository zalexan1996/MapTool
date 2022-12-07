using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Types.Tiles
{
    public class Tile
    {
        public Tile(string name, string description, int startX, int startY, int width, int height)
        {
            Name = name;
            Description = description;
            StartX = startX;
            StartY = startY;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// The name of the tile
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The description of the tile
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The X position in pixels that this tile starts at in the tilesheet.
        /// </summary>
        public int StartX { get; set; } = 0;

        /// <summary>
        /// The Y position in pixels that this tile starts at in the tilesheet.
        /// </summary>
        public int StartY { get; set; } = 0;

        /// <summary>
        /// The width in pixels of this tile.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// The height in pixels of this tile.
        /// </summary>
        public int Height { get; set; }
    }
}
