using Microsoft.Xna.Framework;
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
        public Spider spider;
        private bool isLoaded = false;
        //RYSOWANIE NA EKRANIE
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            Globals.graphics.GraphicsDevice.Clear(Color.Black);
            Globals.spriteBatch.Draw(Globals.spiderTexture, spider.Position, Color.White);
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
            SpiderControls();

            Draw();
        }

        //LOAD OBJECTS AND OTHER STUFF IMPORTANT FOR THE GAMESTATE
        public void OnLoad()
        {
            spider = new Spider(new Vector2(64, 64), new Vector2(100, 100), 3);
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

            //TODO: place web
        }

        public void ButterflyControls()
        {
            //TODO: movement
        }
    }
}
