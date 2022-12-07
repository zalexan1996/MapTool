using MapTool.Domain.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapTool.Core.Types.Tiles
{
    public class AnimatedTile
    {
        /// <inheritdoc/>
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc/>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The tiles used in this animation. The order matters.
        /// </summary>
        public Collection<Tile> Tiles { get; set; } = new();

        /// <summary>
        /// The suggested animation playback speed.
        /// Time in milliseconds between each frame.
        /// Default of one second.
        /// </summary>
        public int AnimationSpeed { get; set; } = 1000;

        /// <summary>
        /// The suggested delay between successful playbacks.
        /// In other words, once an animation has completed, 
        /// wait this long in milliseconds before playing the animation again.
        /// </summary>
        public int AnimationDelay { get; set; } = 0;
    }
}
