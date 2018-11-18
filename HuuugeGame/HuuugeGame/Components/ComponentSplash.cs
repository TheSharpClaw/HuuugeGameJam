using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
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
        int k = 0;
        public ComponentSplash()
        {
            float middleX = ((Globals.screenSize.X - Globals.splashScreenLogo.Width) / 2);
            float middleY = ((Globals.screenSize.Y - Globals.splashScreenLogo.Height) / 2);
            
            logoPosition = new Vector2(middleX, middleY);
        }
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            switch (k)
            {
                case 0:
                    Globals.spriteBatch.Draw(Globals.splashScreenLogo2, new Rectangle(0, 0, (int)Globals.screenSize.X, (int)Globals.screenSize.Y), Color.White);

                    Globals.spriteBatch.Draw(Globals.splashScreenLogo2, new Rectangle(0, 0, (int)Globals.screenSize.X, (int)Globals.screenSize.Y), new Color(Color.Black, alpha));

                    break;
                case 1:
                    Globals.activeState = Globals.enGameStates.MENU;

                    Globals.spriteBatch.Draw(Globals.splashScreenLogo, logoPosition, Color.White);

                    Globals.spriteBatch.Draw(Globals.splashScreenLogo, logoPosition, new Color(Color.Black, alpha));

                    break;
                case 2:
                    Globals.spriteBatch.Draw(Globals.splashScreenLogo, logoPosition, Color.White);

                    Globals.spriteBatch.Draw(Globals.splashScreenLogo, logoPosition, new Color(Color.Black, alpha));

                    break;
                case 3:
                    Globals.activeState = Globals.enGameStates.MENU;
                    break;
            }
            Globals.spriteBatch.End();

        }

        public void Update()
        {
            switch (k)
            {
                case 0:
                    if (alpha >= 255)
                    {
                        k++;
                        i = 0;
                    }
                    if (i++ >= 150)                        
                            alpha += 3;
                    MediaPlayer.Play(Globals.battleBackgroundMusic);
                    break;
                case 1:
                    if (alpha <= 0)
                    {
                        k++;
                        i = 0;                       
                        
                    }
                    
                        alpha -= 3;
                    
                    break;
                case 2:
                    if (alpha >= 255)
                    {
                        k++;
                        i = 0;
                    }
                    if (i++ >= 150)
                        alpha += 3;


                    break;
                case 3:
                    Globals.activeState = Globals.enGameStates.MENU;
                    break;
            }
            if (i++ >= 150)
                if (k % 2 == 0)
                    alpha += 3;
                else
                    alpha -= 3;
          
           
            Draw();
        }
    }
}
