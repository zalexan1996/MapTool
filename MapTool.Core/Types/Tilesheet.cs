using MapTool.Core.Types.Tiles;
using MapTool.Domain.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Types
{
    public class Tilesheet
    {
        public Tilesheet(string name, string description, string assetReference)
        {
            Name = name;
            Description = description;
            AssetReference = assetReference;
        }

        /// <summary>
        /// The name of the tilesheet
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The description of the tilesheet
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// A string used to identify the tilesheet asset.
        /// </summary>
        public string AssetReference { get; set; } = string.Empty;

        /// <summary>
        /// The collection of tiles generated from the tilesheet asset.
        /// </summary>
        public Collection<Tile> Tiles { get; set; } = new();
    }
}
