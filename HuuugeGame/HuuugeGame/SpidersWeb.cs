using HuuugeGame.Content.Behaviour;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace HuuugeGame
{
    class SpidersWeb : IEntity
    {
        public SpidersWeb(Vector2 position, Vector2 size, int power)
        {
            Position = position;
            Size = size;
            Power = power;
        }

        public Vector2 Position { get; set; }

        public Vector2 Size { get; set; }
        public int Power { get; set; }

        public Texture2D Texture { get; set; }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Globals.spiderWebTexture, Position, Color.White);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
