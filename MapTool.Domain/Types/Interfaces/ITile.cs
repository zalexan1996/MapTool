using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Domain.Types.Interfaces
{
    /// <summary>
    /// Base interface represents a tile. Can be a visual tile with collision or a utility tile for conveying data to the game.
    /// </summary>
    public interface ITile : IKeyedEntity, IInformationEntity
    {
    }
}
