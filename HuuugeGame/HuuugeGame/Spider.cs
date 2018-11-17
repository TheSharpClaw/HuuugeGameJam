using HuuugeGame.Content.Behaviour;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

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
                Globals.spriteBatch.Draw(Globals.spiderWebTexture, web.Position, Color.White);

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
            #region movement
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Position = new Vector2(Position.X, Position.Y - Velocity);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Position = new Vector2(Position.X, Position.Y + Velocity);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Position = new Vector2(Position.X - Velocity, Position.Y);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Position = new Vector2(Position.X + Velocity, Position.Y);
            }
            #endregion

            #region spriteRotation
            if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                angle = (float)Math.PI * 1.75f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                angle = (float)Math.PI * 0.25f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                angle = (float)Math.PI * 1.25f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S) && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                angle = (float)Math.PI * 0.75f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                angle = 0;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                angle = (float)Math.PI;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                angle = (float)Math.PI * 1.5f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                angle = (float)Math.PI * 0.5f;
            }
            #endregion

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
