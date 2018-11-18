using HuuugeGame.Behaviour;
using HuuugeGame.Components;
using HuuugeGame.Content.Behaviour;
using HuuugeGame.Behaviour.Hive;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuuugeGame
{
    class Spider : IEntity
    {
        public AnimatedSprite animatedSprite;
        public int spiderWebPower;

        public Spider(IComponent stage, Vector2 size, Vector2 position, int velocity)
        {
            this.stage = stage;
            Position = position;
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width / 2, Texture.Height / 2);
            Velocity = velocity;
            spiderWebPower = 30;
            animatedSprite = new AnimatedSprite(Globals.spiderTexture, 2, 2);

        }

        int counterTimer = 0;
        public int Velocity { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; } = Globals.spiderTexture;
        public Rectangle BoundingBox { get; set; }

        public IComponent stage { get; private set; }

        public List<SpidersWeb> spiderWebList = new List<SpidersWeb>();
        private float angle = 0;

        private int killSEDelay = 0;
        private int stepSEDelay = 0;

        private Color color = Color.Gray;

        KeyboardState oldKeyState;
        KeyboardState newKeyState;

        public void Draw()
        {
            foreach (SpidersWeb web in spiderWebList)
                web.Draw();

            //Globals.spriteBatch.Draw(Globals.spiderTexture, new Vector2(Position.X + Size.X / 2, Position.Y + Size.Y / 2),
            //    null, Color.Black, angle, origin, 1.0f, SpriteEffects.None, 1);

            animatedSprite.Draw(Position, angle, color);

            #region drawSpiderWebPower
            Globals.spriteBatch.Draw(Globals.hpBar, new Rectangle((int)Position.X - 10, (int)Position.Y - 20, 50, Globals.hpBar.Height), Color.White);
            Globals.spriteBatch.Draw(Globals.hpBar_white, new Rectangle((int)Position.X - 10, (int)Position.Y - 20, spiderWebPower / 2, Globals.hpBar.Height), Color.White);
            #endregion
        }

        private bool KeypressTest(Keys theKey)
        {
            if (oldKeyState.IsKeyUp(theKey) && newKeyState.IsKeyDown(theKey))
                return true;
            return false;
        }

        public void Update()
        {
            var keys = Keyboard.GetState().GetPressedKeys().Cast<Keys>().ToList();

            if (keys.Contains(Keys.W) || keys.Contains(Keys.S) || keys.Contains(Keys.A) || keys.Contains(Keys.D))
            {
                BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width / 2, Texture.Height / 2);
                if (counterTimer % 6 == 0)
                    animatedSprite.Update();
            }
            
            List<ChildrenFly> ListOfChildrenFlies = ((Hive)stage.DrawList.Find(x => x is Hive)).ChildrenFlies;                 
            var count = ListOfChildrenFlies.RemoveAll(x => x.BoundingBox.Intersects(BoundingBox));
            if(count >= 1 && killSEDelay >= 15)
            {
                Globals.wilhelmScreamSE.Play(0.5f, 0.4f, 1);
                killSEDelay = 0;
            }
            killSEDelay++;

            if (counterTimer++ > (60 * 2))
            {
                if (spiderWebPower < 90)
                {
                    spiderWebPower += 10;
                }
                counterTimer = 0;
            }

            newKeyState = Keyboard.GetState();
            SpiderControls();
            SpiderCollision();
            oldKeyState = newKeyState;
            for (int i = 0; i < spiderWebList.Count; i++)
            {
                spiderWebList[i].Update();
            }
        }

        public void SpiderControls()
        {
            var keys = Keyboard.GetState().GetPressedKeys().Cast<Keys>().ToList();

            if (keys.Contains(Keys.A) || keys.Contains(Keys.D) ||keys.Contains(Keys.W) ||keys.Contains(Keys.S))
            {
                playStepSE();
            }

            if (keys.Contains(Keys.A) && keys.Contains(Keys.D))
            {
                keys.Remove(Keys.A);
                keys.Remove(Keys.D);
            }

            if (keys.Contains(Keys.W) && keys.Contains(Keys.S))
            {
                keys.Remove(Keys.W);
                keys.Remove(Keys.S);
            }

            foreach (var key in keys)
            {
                switch (key)
                {
                    case Keys.W:
                        {
                            if (keys.Contains(Keys.A) || keys.Contains(Keys.D))
                            {
                                if (keys.Contains(Keys.A))
                                {
                                    Position += new Vector2((float)-Math.Cos((Math.PI / 180 * 45)) * Velocity, (float)-Math.Cos((Math.PI / 180 * 45)) * Velocity);
                                    angle = (float)Math.PI * 1.75f;
                                }
                                else
                                {
                                    Position += new Vector2((float)Math.Cos((Math.PI / 180 * 45)) * Velocity, (float)-Math.Cos((Math.PI / 180 * 45)) * Velocity);
                                    angle = (float)Math.PI * 0.25f;
                                }

                                break;
                            }

                            Position += new Vector2(0, -Velocity);
                            angle = 0;

                            break;
                        }
                    case Keys.S:
                        {
                            if (keys.Contains(Keys.A) || keys.Contains(Keys.D))
                            {
                                if (keys.Contains(Keys.A))
                                {
                                    Position += new Vector2((float)-Math.Cos((Math.PI / 180 * 45)) * Velocity, (float)Math.Cos((Math.PI / 180 * 45)) * Velocity);
                                    angle = (float)Math.PI * 1.25f;
                                }
                                else
                                {
                                    Position += new Vector2((float)Math.Cos((Math.PI / 180 * 45)) * Velocity, (float)Math.Cos((Math.PI / 180 * 45)) * Velocity);
                                    angle = (float)Math.PI * 0.75f;
                                }
                                break;
                            }

                            Position += new Vector2(0, Velocity);
                            angle = (float)Math.PI;

                            break;
                        }
                    case Keys.A:
                        {
                            if (keys.Contains(Keys.W) || keys.Contains(Keys.S))
                                break;

                            Position += new Vector2(-Velocity, 0);
                            angle = (float)Math.PI * 1.5f;
                            break;
                        }
                    case Keys.D:
                        {
                            if (keys.Contains(Keys.W) || keys.Contains(Keys.S))
                                break;

                            Position += new Vector2(Velocity, 0);
                            angle = (float)Math.PI * 0.5f;
                            break;
                        }
                }
            }
            #region webPlacing
            if (KeypressTest(Keys.LeftShift))
            {
                if (spiderWebPower > 0)
                {
                    spiderWebList.Add(new SpidersWeb(stage, Position, new Vector2(Globals.spiderWebTexture.Width, Globals.spiderWebTexture.Height), 12, spiderWebList));
                    spiderWebPower -= 10;
                }
            }
            #endregion
        }

        private void playStepSE()
        {
            if(stepSEDelay >= 20)
            {
                Globals.stepSE.Play(0.25f, 0.1f, 1);
                stepSEDelay = 0;
            }
            stepSEDelay++;
        }

        public void SpiderCollision()
        {
            if (Position.X < 24) Position = new Vector2(24, Position.Y);

            else if (Position.X + BoundingBox.Width > Globals.screenSize.X - 24) Position = new Vector2(Globals.screenSize.X - 24 - BoundingBox.Width, Position.Y);

            if (Position.Y < 24) Position = new Vector2(Position.X, 24);

            else if (Position.Y + BoundingBox.Height > Globals.screenSize.Y - 24) Position = new Vector2(Position.X, Globals.screenSize.Y - 24 - BoundingBox.Height);

            var obstacles = stage.DrawList.FindAll(x => x is Obstacle).ToList();

            if ((obstacles = obstacles.FindAll(x => x.BoundingBox.Intersects(BoundingBox))).Count > 0)
            {
                foreach (var item in obstacles)
                {
                    var top = new Rectangle(new Point(item.BoundingBox.Left, item.BoundingBox.Top), new Point(item.BoundingBox.Width, 0));

                    if (BoundingBox.Intersects(top))
                    {
                        Position = new Vector2(Position.X, top.Top - BoundingBox.Height);
                    }



                    var bottom = new Rectangle(new Point(item.BoundingBox.Left, item.BoundingBox.Bottom), new Point(item.BoundingBox.Width, 0));

                    if (BoundingBox.Intersects(bottom))
                    {
                        Position = new Vector2(Position.X, bottom.Bottom);
                    }



                    var left = new Rectangle(new Point(item.BoundingBox.Left, item.BoundingBox.Top), new Point(0, item.BoundingBox.Height));

                    if (BoundingBox.Intersects(left))
                    {
                        Position = new Vector2(left.Left - BoundingBox.Width, Position.Y);
                    }



                    var right = new Rectangle(new Point(item.BoundingBox.Right, item.BoundingBox.Top), new Point(0, item.BoundingBox.Height));

                    if (BoundingBox.Intersects(right))
                    {
                        Position = new Vector2(right.Right, Position.Y);
                    }

                }
            }
        }
    }
}
