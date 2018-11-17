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
        int alpha = 0;
        int i = 0;
        public ComponentSplash()
        {
            float middleX = ((Globals.screenSize.X - Globals.splashScreenLogo.Width) / 2);
            float middleY = ((Globals.screenSize.Y - Globals.splashScreenLogo.Height) / 2);
            
            logoPosition = new Vector2(middleX, middleY);
        }
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(Globals.splashScreenLogo, logoPosition, Color.White);
            Globals.spriteBatch.Draw(Globals.splashScreenLogo, logoPosition, new Color(Color.Black, alpha));
            Globals.spriteBatch.End();

        }

        public void Update()
        {
            if (alpha >= 255)
            {
                Globals.activeState = Globals.enGameStates.MENU;
            }
            if (i++ >= 60) alpha += 3;
            Draw();
        }
    }
}
