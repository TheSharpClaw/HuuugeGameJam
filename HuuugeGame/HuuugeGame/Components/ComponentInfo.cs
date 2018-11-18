using HuuugeGame.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame.Components
{
    class ComponentInfo : StateTemplate
    {

        Button goBack;
        public ComponentInfo()
        {
            goBack = new Button(Globals.yellowButton, Globals.defaultFont, "BACK")
            {
                Position = new Vector2((3*(Globals.screenSize.X/4) - Globals.yellowButton.Width/2), Globals.screenSize.Y - 100),
                Text = "Quit"
            };
            goBack._isSelected = true;
        }

        public void Draw()
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(Globals.backgroundTexture, new Vector2(0, 0), Color.White);
            Globals.spriteBatch.Draw(Globals.hpBar, new Rectangle(0, 0, 700, 600), new Color(0, 0, 0, 150));

            Globals.spriteBatch.DrawString(Globals.defaultFont, "STEROWANIE", new Vector2(Globals.screenSize.X/2-50, 50), Color.White);
            Globals.spriteBatch.Draw(Globals.spiderStaticTexture, new Rectangle((int)Globals.screenSize.X / 4 - Globals.spiderStaticTexture.Width, 100, Globals.spiderStaticTexture.Width * 2, Globals.spiderStaticTexture.Height * 2), Color.White);
            Globals.spriteBatch.Draw(Globals.motherFlyStaticTexture, new Rectangle(((int)Globals.screenSize.X / 4) * 3 - Globals.motherFlyStaticTexture.Width, 100, Globals.motherFlyStaticTexture.Width * 2, Globals.motherFlyStaticTexture.Height * 2), Color.White);
            Globals.spriteBatch.Draw(Globals.wsadIMG, new Rectangle(((int)Globals.screenSize.X / 4) - Globals.wsadIMG.Width/2, (100 + Globals.spiderStaticTexture.Height * 2+40), Globals.wsadIMG.Width, Globals.wsadIMG.Height),Color.White);
            Globals.spriteBatch.Draw(Globals.shiftIMG, new Rectangle(((int)Globals.screenSize.X / 4) - Globals.shiftIMG.Width / 2, (100 + Globals.spiderStaticTexture.Height * 2 + Globals.wsadIMG.Height +103), Globals.shiftIMG.Width, Globals.shiftIMG.Height),Color.White);
            Globals.spriteBatch.DrawString(Globals.defaultFont, "press to place a web", new Vector2(Globals.screenSize.X / 4 - 75, 100 + Globals.spiderStaticTexture.Height * 2 + Globals.wsadIMG.Height + 70), Color.White);
            Globals.spriteBatch.DrawString(Globals.defaultFont, "Target: Eat every small butterflies", new Vector2(Globals.screenSize.X / 4 - 115, 100 + Globals.spiderStaticTexture.Height * 2 + Globals.wsadIMG.Height + 190), Color.White);
            Globals.spriteBatch.DrawString(Globals.defaultFont, "Target: Collect as many\nbutterflies as possible", new Vector2((Globals.screenSize.X / 4)*3 - 75, 100 + Globals.spiderStaticTexture.Height * 2 + Globals.wsadIMG.Height + 70), Color.White);
            Globals.spriteBatch.DrawString(Globals.defaultFont, "Take the flowers", new Vector2((Globals.screenSize.X / 4)*3 - 75, 100 + Globals.spiderStaticTexture.Height * 2 + Globals.wsadIMG.Height + 140), Color.White);
            Globals.spriteBatch.Draw(Globals.flowerTexture, new Rectangle(((int)Globals.screenSize.X / 4)*3 + 70, 100 + Globals.spiderStaticTexture.Height * 2 + Globals.wsadIMG.Height + 135, Globals.flowerTexture.Width, Globals.flowerTexture.Height), Color.White);

            Globals.spriteBatch.Draw(Globals.arrowsIMG, new Rectangle(((int)Globals.screenSize.X / 4)*3 - Globals.arrowsIMG.Width/2, (100 + Globals.motherFlyStaticTexture.Height * 2+40), Globals.arrowsIMG.Width, Globals.arrowsIMG.Height),Color.White);
            goBack.Draw(Globals.spriteBatch);
            Globals.spriteBatch.End();
        }

        public void Update()
        {
            Globals.newKeyState = Keyboard.GetState();
            MenuControls();
            Draw();
            Globals.oldKeyState = Globals.newKeyState;
        }
        public void MenuControls()
        {
            if (KeypressTest(Keys.Space) || KeypressTest(Keys.Enter))
            {
                  Globals.activeState = Globals.enGameStates.MENU;
            }

        }
        private bool KeypressTest(Keys theKey)
        {
            if (Globals.oldKeyState.IsKeyUp(theKey) && Globals.newKeyState.IsKeyDown(theKey))
                return true;
            return false;
        }
    }
}
