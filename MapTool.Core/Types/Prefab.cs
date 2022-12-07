using MapTool.Domain.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Types
{
    public class Prefab
    {
        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Tags used to provide queryable information about this prefab.
        /// </summary>
        public Collection<Tag> Tags { get; set; } = new();

        /// <summary>
        /// The collection of tile placements for this prefab.
        /// </summary>
        public Collection<TilePlacement> TilePlacements { get; set; } = new();
    }
}
