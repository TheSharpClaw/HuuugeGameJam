using HuuugeGame.Behaviour;
using HuuugeGame.Content.Behaviour;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace HuuugeGame
{
    class SpidersWeb : IEntity
    {
        List<SpidersWeb> _spiderWebList;
        int _spiderWebLife;
        public SpidersWeb(IComponent stage, Vector2 position, Vector2 size, int power, List<SpidersWeb> spiderWebList)
        {
            Position = position;

            BoundingBox = Texture.Bounds;

            this.stage = stage;
            Size = size;
            Power = power;
            _spiderWebList = spiderWebList;
            _spiderWebLife = 60 * 8;
                //60 * 8 = 8sekund
        }

        public Vector2 Position { get; set; }

        public Vector2 Size { get; set; }
        public int Power { get; set; }

        public Texture2D Texture { get; set; } = Globals.spiderWebTexture;
        public Rectangle BoundingBox { get; set; }

        public IComponent stage { get; private set; }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Update()
        {
            if (--_spiderWebLife==0)
            {
                _spiderWebList.Remove(this);
            }
        }
    }
}
