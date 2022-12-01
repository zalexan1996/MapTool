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
    /// A collection of tiles arranged to form a re-usable shape.
    /// </summary>
    public class PrefabDto : ITileRecipient, IKeyedEntity, IInformationEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Tags used to provide queryable information about this prefab.
        /// </summary>
        public Collection<TagDto> Tags { get; set; } = new();

        /// <summary>
        /// The collection of tile placements for this prefab.
        /// </summary>
        public Collection<TilePlacementDto> TilePlacements { get; set; } = new();
    }
}
