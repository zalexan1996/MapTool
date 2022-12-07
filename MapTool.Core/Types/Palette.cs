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
    public class Palette
    {
        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The tiles used in this palette. Can be visual tiles or utility tiles.
        /// </summary>
        public Collection<Tile> Tiles { get; set; } = new();
    }
}
