using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapTool.Domain.Types.Interfaces;

namespace MapTool.Domain.Types
{
    /// <summary>
    /// A map. Contains a collection of TilePlacement items.
    /// </summary>
    public class MapDto : ITileRecipient, IKeyedEntity, IInformationEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Tags used to provide queryable information about this map.
        /// </summary>
        public Collection<TagDto> Tags { get; set; } = new Collection<TagDto>();

        /// <summary>
        /// The tile placements in this map. Contains both visual tiles and utility tiles.
        /// </summary>
        public Collection<TilePlacementDto> TilePlacements { get; set; } = new();
    }
}
