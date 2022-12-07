using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Types.Tiles
{
    public class SpawnerTile : Tile
    {
        public SpawnerTile(string name, string description, int startX, int startY, int width, int height, string spawningAssetReference) : base(name, description, startX, startY, width, height)
        {
            AssetReference = spawningAssetReference;
        }

        /// <summary>
        /// The type of asset this tile is used to spawn.
        /// </summary>
        public string AssetReference { get; set; } = string.Empty;
    }
}
