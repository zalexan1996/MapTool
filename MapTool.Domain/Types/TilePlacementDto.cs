using MapTool.Domain.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Domain.Types
{
    /// <summary>
    /// Represents a tile placement in a map or a prefab.
    /// </summary>
    public class TilePlacementDto : IKeyedEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// The reference to the tile.
        /// </summary>
        public TileDto Tile { get; set; }

        /// <summary>
        /// The foreign key id for the Tile.
        /// </summary>
        public int TileId { get; set; }

        /// <summary>
        /// The X position in pixels that we should place this tile in the map or prefab.
        /// Tile origin is top left.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The Y position in pixels that we should place this tile in the map or prefab.
        /// Tile origin is top left.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The Z-ordering position of this tile. It's assumed that the player is at index 0.
        /// Can be a value from -99 to 99.
        /// </summary>
        public int Position { get; set; } = 0;

        /// <summary>
        /// The opacity of this tile.
        /// </summary>
        public float Opacity { get; set; } = 1.0f;

        /// <summary>
        /// Whether this tile is visible in game or not.
        /// If not, it's probably a utility tile with a helper icon.
        /// </summary>
        public bool VisibleInGame { get; set; } = true;

        /// <summary>
        /// Tags used to provide queryable information about this Tile Placement.
        /// </summary>
        public Collection<TagDto> Tags { get; set; } = new();

        /// <summary>
        /// Additional JSON information used to convey logic about this tile.
        /// </summary>
        public string AdditionalDataJson { get; set; } = "";

    }
}
