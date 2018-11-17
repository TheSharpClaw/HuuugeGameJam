using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    class ComponentGame : StateTemplate
    {
        public List<SpidersWeb> spiderWebList = new List<SpidersWeb>();
        public Spider spider;
        private bool isLoaded = false;
        private float angle = 0;
        Vector2 location = new Vector2(400, 240);
        Rectangle sourceRectangle;
        Vector2 origin = new Vector2(Globals.spiderTexture.Width / 2, Globals.spiderTexture.Height / 2);
        //Vector2 origin = new Vector2(0, 0);

        KeyboardState oldKeyState;
        KeyboardState newKeyState;


        private bool KeypressTest(Keys theKey)
        {
            if (oldKeyState.IsKeyUp(theKey) && newKeyState.IsKeyDown(theKey))
                return true;
            return false;
        }

        //RYSOWANIE NA EKRANIE
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            Globals.graphics.GraphicsDevice.Clear(Color.Black);
            foreach (SpidersWeb web in spiderWebList)
            {
                Globals.spriteBatch.Draw(Globals.spiderWebTexture, web.Position, Color.White);
            }
            Globals.spriteBatch.Draw(Globals.spiderTexture, new Vector2(spider.Position.X + spider.Size.X / 2, spider.Position.Y + spider.Size.Y / 2),
                null, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
            Globals.spriteBatch.End();
        }



        //OBLICZENIA
        public void Update()
        {
            if (!isLoaded)
            {
                OnLoad();
                isLoaded = true;
            }
            newKeyState = Keyboard.GetState();
            SpiderControls();

            oldKeyState = newKeyState;
            Draw();
        }

        //LOAD OBJECTS AND OTHER STUFF IMPORTANT FOR THE GAMESTATE
        public void OnLoad()
        {
            spider = new Spider(new Vector2(32, 32), new Vector2(100, 100), 3);
            sourceRectangle = new Rectangle(0, 0, (int)spider.Size.X, (int)spider.Size.Y);
        }

        public void CheckCollisions()
        {
            //TODO: butterfly -> spider
            //TODO: butterfly -> web
        }

        public void SpiderControls()
        {
            #region movement
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                spider.Position = new Vector2(spider.Position.X, spider.Position.Y - spider.Velocity);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                spider.Position = new Vector2(spider.Position.X, spider.Position.Y + spider.Velocity);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                spider.Position = new Vector2(spider.Position.X - spider.Velocity, spider.Position.Y);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                spider.Position = new Vector2(spider.Position.X + spider.Velocity, spider.Position.Y);
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
                spiderWebList.Add(new SpidersWeb(spider.Position, new Vector2(Globals.spiderWebTexture.Width, Globals.spiderWebTexture.Height), 3));
            }
            #endregion


            //TODO: place web
        }

        public void ButterflyControls()
        {
            //TODO: movement
        }
    }
}
