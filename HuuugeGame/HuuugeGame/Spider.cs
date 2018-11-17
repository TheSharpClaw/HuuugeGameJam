using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    class Spider
    {
        private Vector2 size;
        private int velocity;

        public Spider(Vector2 size, int velocity)
        {
            this.Size = size;
            this.Velocity = velocity;
        }

        public Vector2 Size { get => size; set => size = value; }
        public int Velocity { get => velocity; set => velocity = value; }
    }
}
