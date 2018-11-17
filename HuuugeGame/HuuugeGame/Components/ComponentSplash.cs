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
            float middleX = ((Globals.screenSize.X - Globals.splashScreenLogo.Width)/2);
            //float middleX = 150;       
           float middleY = ((Globals.screenSize.Y - Globals.splashScreenLogo.Height)/2);
           // float middleY = 150;
      
            logoPosition = new Vector2(middleX, middleY);
        }
        public void Draw()
        {
            Globals.spriteBatch.Begin();

            Globals.spriteBatch.Draw(Globals.splashScreenLogo, logoPosition);

            Globals.spriteBatch.End();
            //RYSOWANIE NA EKRANIE

        }

        public void Update()
        {
            //OBLICZENIA
            Draw();
        }
    }
}
