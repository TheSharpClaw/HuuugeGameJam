using HuuugeGame.Content.Behaviour;
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
        public Spider(Vector2 size, Vector2 position, int velocity)
        {
            Size = size;
            Position = position;
            Velocity = velocity;
        }

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
                null, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
        }

        private bool KeypressTest(Keys theKey)
        {
            if (oldKeyState.IsKeyUp(theKey) && newKeyState.IsKeyDown(theKey))
                return true;
            return false;
        }

        public void Update()
        {

            newKeyState = Keyboard.GetState();
            SpiderControls();

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
            if (KeypressTest(Keys.Tab))
            {
                spiderWebList.Add(new SpidersWeb(Position, new Vector2(Globals.spiderWebTexture.Width, Globals.spiderWebTexture.Height), 3));
            }
            #endregion


            //TODO: place web
        }
    }
}
