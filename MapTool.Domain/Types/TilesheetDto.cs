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
    /// Represents a tilesheet asset.
    /// </summary>
    public class TilesheetDto : IKeyedEntity, IInformationEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// A string used to identify the tilesheet asset.
        /// </summary>
        public string AssetReference { get; set; } = string.Empty;

        /// <summary>
        /// The collection of tiles generated from the tilesheet asset.
        /// </summary>
        public Collection<TileDto> Tiles { get; set; }
    }
}
