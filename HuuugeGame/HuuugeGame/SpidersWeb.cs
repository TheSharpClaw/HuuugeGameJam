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
                          for (int i = 0; i < stage.DrawList.Count; i++)
                {
                    if (stage.DrawList[i] is Hive)
                    {
                        Hive x = (Hive)stage.DrawList[i];
                        for (int j = 0; j < x.ChildrenFlies.Count; j++)
                        {
                            if (x.ChildrenFlies[j].BoundingBox.Intersects(BoundingBox))
                            {
                                x.ChildrenFlies.Remove(x.ChildrenFlies[j]);
                              
                            }
                        }
                    }
                }
                _spiderWebList.Remove(this);
            }
        }
        public void ResetSpiderWebLife()
        {
            _spiderWebLife = 60 * 8;
        }

        public void Collision()
        {
            for (int i = 0; i < stage.DrawList.Count; i++)
            {
                if (stage.DrawList[i] is Hive)
                {
                    Hive x = (Hive)stage.DrawList[i];
                    foreach (ChildrenFly fly in x.ChildrenFlies)
                    {
                        if (fly.doUpdate == true && BoundingBox.Intersects(fly.BoundingBox))
                        {
                            if (fliesCoughtCounter++ >= Power) continue;
                            fly.doUpdate = false;
                            ResetSpiderWebLife();
                        }
                    }
                }
            }
        }
    }
}
