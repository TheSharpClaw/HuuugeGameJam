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

        //RYSOWANIE NA EKRANIE
        public void Draw()
        {
            throw new NotImplementedException();
        }



        //OBLICZENIA
        public void Update()
        {


            Draw();
        }

        //LOAD OBJECTS AND OTHER STUFF IMPORTANT FOR THE GAMESTATE
        public void OnLoad()
        {
            spider = new Spider(new Vector2(64, 64), 3);
        }

        public void CheckCollisions()
        {
            //TODO: butterfly -> spider
            //TODO: butterfly -> web
        }

        public void SpiderControls()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                //TODO: move up
            }else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                //TODO: move down
            }else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                //TODO: move left
            }else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                //TODO: move right
            }
            //TODO: movement
            //TODO: place web
        }

        public void ButterflyControls()
        {
            //TODO: movement
        }
    }
}
