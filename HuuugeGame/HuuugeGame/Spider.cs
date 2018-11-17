﻿using HuuugeGame.Content.Behaviour;
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
        public int spiderWebPower;
        public Spider(Vector2 size, Vector2 position, int velocity)
        {
            Size = size;
            Position = position;
            Velocity = velocity;
            spiderWebPower = 30;
        }

        int counterTimer = 0;
        public Vector2 Size { get; set; }
        public int Velocity { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public List<SpidersWeb> spiderWebList = new List<SpidersWeb>();
        private float angle = 0;

        Vector2 origin = new Vector2(Globals.spiderTexture.Width / 2, Globals.spiderTexture.Height / 2);

        KeyboardState oldKeyState;
        KeyboardState newKeyState;

        public void Draw()
        {
            foreach (SpidersWeb web in spiderWebList)
                web.Draw();

            Globals.spriteBatch.Draw(Globals.spiderTexture, new Vector2(Position.X + Size.X / 2, Position.Y + Size.Y / 2),
                null, Color.Black, angle, origin, 1.0f, SpriteEffects.None, 1);

            #region drawSpiderWebPower
            Globals.spriteBatch.Draw(Globals.hpBar, new Rectangle((int)Position.X - 10, (int)Position.Y - 20, 50, Globals.hpBar.Height), Color.White);
            Globals.spriteBatch.Draw(Globals.hpBar_green, new Rectangle((int)Position.X - 10, (int)Position.Y - 20, spiderWebPower / 2, Globals.hpBar.Height), Color.White);
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
            //counterTimer == 60 - upłynęła 1 sekunda
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
        }

        public void SpiderControls()
        {
            var keys = Keyboard.GetState().GetPressedKeys().Cast<Keys>().ToList();

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
                    spiderWebList.Add(new SpidersWeb(Position, new Vector2(Globals.spiderWebTexture.Width, Globals.spiderWebTexture.Height), 3));
                    spiderWebPower -= 10;
                }
            }
            #endregion
        }

        public void SpiderCollision()
        {
            if (Position.X < 24) Position = new Vector2(24, Position.Y);
            else if (Position.X + Size.X > Globals.screenSize.X - 24) Position = new Vector2(Globals.screenSize.X - 24 - Size.X, Position.Y);
            if (Position.Y < 24) Position = new Vector2(Position.X, 24);
            else if (Position.Y + Size.Y > Globals.screenSize.Y - 24) Position = new Vector2(Position.X, Globals.screenSize.Y - 24 - Size.Y);
        }
    }
}
