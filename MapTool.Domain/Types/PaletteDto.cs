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
    /// A collection of tiles used like a color palette in map creation.
    /// </summary>
    public class PaletteDto : IKeyedEntity, IInformationEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The tiles used in this palette. Can be visual tiles or utility tiles.
        /// </summary>
        public Collection<TileDto> Tiles { get; set; } = new();
    }
}
