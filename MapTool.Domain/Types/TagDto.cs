using MapTool.Domain.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Domain.Types
{
    /// <summary>
    /// A tag that can be assigned to a map, tilesheet, tile, etc. to categorize it.
    /// Think overworld, water, cave, house, enemySpawn, soundCue, Bob, etc.
    /// </summary>
    public class TagDto : IKeyedEntity, IInformationEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;
    }
}
