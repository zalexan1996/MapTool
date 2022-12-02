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
    /// The project information. There will only be one of these per database.
    /// </summary>
    public class ProjectDto : IKeyedEntity, IInformationEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The author of this project.
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// The version of this project.
        /// </summary>
        public string VersionString { get; set; } = "0.0.1";

        /// <summary>
        /// All the maps that are a part of this project.
        /// </summary>
        public Collection<MapDto> Maps { get; set; } = new();
    }
}
