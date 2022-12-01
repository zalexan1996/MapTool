using MapTool.Domain.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Domain.Types
{
    /// <summary>
    /// The base tile class representing a tile from a tile sheet.
    /// </summary>
    public class Tile : ITile, IKeyedEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// The reference to the tile sheet that this tile is a part of.
        /// </summary>
        public Tilesheet Tilesheet { get; set; }

        /// <summary>
        /// The foreign key id of the Tilesheet.
        /// </summary>
        public int ParentTilesheetId { get; set; }

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
