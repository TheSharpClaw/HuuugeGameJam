using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    class SpidersWeb
    {
        private Vector2 position;
        private Vector2 size;
        private int power;
        public SpidersWeb(Vector2 position, Vector2 size, int power)
        {
            this.Position = position;
            this.Size = size;
            this.Power = power;
        }

        public Vector2 Position { get => position; set => position = value; }
        public Vector2 Size { get => size; set => size = value; }
        public int Power { get => power; set => power = value; }
    }
}
