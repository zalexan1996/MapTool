using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Domain.Types.Interfaces
{
    public interface IInformationEntity
    {
        /// <summary>
        /// The Name used to present this asset.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description to provide context about this asset.
        /// </summary>
        public string Description { get; set; }
    }
}
