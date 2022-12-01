using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Domain.Types.Interfaces
{
    public interface IKeyedEntity
    {
        /// <summary>
        /// The Id used to uniquely identify this entity.
        /// </summary>
        public int Id { get; set; }
    }
}
