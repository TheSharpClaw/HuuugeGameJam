using HuuugeGame.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    class ComponentMenu : StateTemplate
    {

        private List<Button> _buttons;
        private Button newGameButton,quitGameButton,infoButton;
        int currently_selected;
        const int buttons_count = 3;
        //UWAGA TEN STATE JEST RAKIEM, NIE ZAGŁĘBIAJ SIĘ TUTAJ

        public ComponentMenu()
        {
            currently_selected = 0;
            float middleX = (Globals.screenSize.X - Globals.yellowButton.Width) / 2;
            float posY = (Globals.screenSize.Y - (Globals.yellowButton.Height*buttons_count)-(50*buttons_count-1) ) / 2;
            newGameButton = new Button(Globals.yellowButton, Globals.defaultFont, "NewGame")
            {
                Position = new Vector2(middleX, posY),
                Text = "New Game",
            };
            infoButton = new Button(Globals.yellowButton, Globals.defaultFont, "INFO")
            {
                Position = new Vector2(middleX, newGameButton.Position.Y + Globals.yellowButton.Height + 50),
                Text = "Info",
            };
            quitGameButton = new Button(Globals.yellowButton, Globals.defaultFont, "Quit")
            {
                Position = new Vector2(middleX, infoButton.Position.Y+Globals.yellowButton.Height+50),
                Text = "Quit",
            };

            _buttons = new List<Button>()
            {
                newGameButton,
                infoButton,
                quitGameButton,
            };
            _buttons[0]._isSelected = true;
        }    

        public void Draw()
        {
            //RYSOWANIE NA EKRANIE
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(Globals.backgroundTexture, new Vector2(0, 0), Color.White);

            foreach (var button in _buttons)
            {
                button.Draw(Globals.spriteBatch);
            }
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
           if (KeypressTest(Keys.W) || KeypressTest(Keys.Up))
          {
                refreshSelectedBtn(false);
            }
            else if (KeypressTest(Keys.S) || KeypressTest(Keys.Down))
            {                
                refreshSelectedBtn(true);

          }else if (KeypressTest(Keys.Space) || KeypressTest(Keys.Enter))
            {
                String name = _buttons[currently_selected].nameBtn;
                if (name.Equals("NewGame")){
                    Globals.activeState = Globals.enGameStates.GAME;
                }
                else if (name.Equals("Quit"))
                {
                    Globals.activeState = Globals.enGameStates.EXIT;
                }
                else if (name.Equals("INFO"))
                {
                    Globals.activeState = Globals.enGameStates.INFO;
                }

            }

           //true - w doł
           //false - w góre
           void refreshSelectedBtn(bool change){
                _buttons[currently_selected]._isSelected = false;
                if (change)
                {
                    if (currently_selected + 1 < _buttons.Count)
                    {
                        currently_selected++;
                    }
                }
                else
                {
                    if (currently_selected - 1 >= 0)
                    {
                        currently_selected--;
                    }
                }
                _buttons[currently_selected]._isSelected = true;
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
