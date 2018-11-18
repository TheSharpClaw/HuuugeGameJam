using HuuugeGame.Behaviour;
using HuuugeGame.Behaviour.Hive;
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
        List<ChildrenFly> caughtFlies = new List<ChildrenFly>();

        int _spiderWebLife;

        public SpidersWeb(IComponent stage, Vector2 position, Vector2 size, int power, List<SpidersWeb> spiderWebList)
        {
            Position = position;

            BoundingBox = new Rectangle((int)Position.X + Globals.spiderWebTexture.Width * 3 / 10, (int)Position.Y + +Globals.spiderWebTexture.Height * 3 / 10, (int)Globals.spiderWebTexture.Width * 4 / 10, (int)Globals.spiderWebTexture.Height * 4 / 10);

            this.stage = stage;
            Size = size;
            Power = 12;
            _spiderWebList = spiderWebList;
            ResetSpiderWebLife();
        }

        public Vector2 Position { get; set; }

        public Vector2 Size { get; set; }
        public int Power { get; set; }

        public Texture2D Texture { get; set; } = Globals.spiderWebTexture;
        public Rectangle BoundingBox { get; set; }

        private int fliesCoughtCounter = 0;

        public IComponent stage { get; private set; }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Update()
        {
            Collision();
            if (--_spiderWebLife == 0)
            {
                caughtFlies.ForEach(x => x.doUpdate = true);
                _spiderWebList.Remove(this);
            }
        }
        public void ResetSpiderWebLife()
        {
            _spiderWebLife = 60 * 8;
        }

        public void Collision()
        {
            var flies = ((Hive)stage.DrawList.Find(x => x is Hive)).ChildrenFlies.FindAll(x => !caughtFlies.Contains(x) && x.BoundingBox.Intersects(BoundingBox));

            if(flies.Count > 0)
            {
                flies.ForEach(x => x.doUpdate = false);

                caughtFlies.AddRange(flies);

                ResetSpiderWebLife();
            }
        }
    }
}
