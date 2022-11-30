﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapTool.Core.Types.Interfaces;

namespace MapTool.Core.Types
{
    /// <summary>
    /// A map. Contains a collection of TilePlacement items.
    /// </summary>
    public class Map : ITileRecipient, IKeyedEntity, IInformationEntity
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
        public Collection<Tag> Tags { get; set; } = new Collection<Tag>();

        /// <summary>
        /// The tile placements in this map. Contains both visual tiles and utility tiles.
        /// </summary>
        public Collection<TilePlacement> TilePlacements { get; set; } = new();
    }
}