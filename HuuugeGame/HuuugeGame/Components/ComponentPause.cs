using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame.Components
{
    class ComponentPause : StateTemplate
    {
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(Globals.hpBar, new Rectangle(0, 0, 700, 600), Color.Gray);
            Globals.spriteBatch.DrawString(Globals.defaultFont, "PAUSED",new Vector2(Globals.screenSize.X/2-30, Globals.screenSize.Y/2), Color.White);
            Globals.spriteBatch.End();

        }

        public void Update()
        {
            Draw();
            Globals.newKeyState = Keyboard.GetState();

            if (KeypressTest(Keys.Escape)){
                Globals.activeState = Globals.activeState == Globals.enGameStates.GAME ? Globals.enGameStates.PAUSE : Globals.enGameStates.GAME;
                        }
                Globals.oldKeyState = Globals.newKeyState;

        }
        private bool KeypressTest(Keys theKey)
        {
            if (Globals.oldKeyState.IsKeyUp(theKey) && Globals.newKeyState.IsKeyDown(theKey))
                return true;
            return false;
        }
    }
}
