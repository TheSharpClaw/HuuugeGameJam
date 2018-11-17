using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    class ComponentSplash : StateTemplate
    {
        Vector2 logoPosition;
        public ComponentSplash()
        {
            //int middleX = ((int)Globals.screenSize.X - Globals.splashScreenLogo.Width)/2;
            int middleX = ((int)Globals.screenSize.X)/2;
            //int middleY = ((int)Globals.screenSize.Y - Globals.splashScreenLogo.Height)/2;
            int middleY = ((int)Globals.screenSize.Y)/2;
            logoPosition = new Vector2(middleX, middleY);
        }
        public void Draw()
        {
            Globals.spriteBatch.Begin();

            Globals.spriteBatch.Draw(Globals.splashScreenLogo, logoPosition, Color.White);

            Globals.spriteBatch.End();
            //RYSOWANIE NA EKRANIE

        }

        public void Update()
        {
            //OBLICZENIA
            //Draw();
        }
    }
}
