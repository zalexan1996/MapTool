using MapTool.Domain.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Types
{
    public class Project
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
        public Collection<Map> Maps { get; set; } = new();
    }
}
