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
        public SpidersWeb(Vector2 position, Vector2 size, int power, List<SpidersWeb> spiderWebList)
        {
            Position = position;
            Size = size;
            Power = power;
            _spiderWebList = spiderWebList;
            _spiderWebLife = 60 * 8;
                //60 * 8 = 8sekund
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
            if (--_spiderWebLife==0)
            {
                _spiderWebList.Remove(this);
            }
        }
    }
}
