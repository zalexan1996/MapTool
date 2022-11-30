using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Types.Interfaces
{
    /// <summary>
    /// Represents an object that contains multiple tiles arranged in a shape.
    /// Map, prefab, etc.
    /// </summary>
    public interface ITileRecipient
    {
        /// <summary>
        /// The collection of tiles in use by this recipient.
        /// </summary>
        public Collection<TilePlacement> TilePlacements { get; set; }
    }
}
