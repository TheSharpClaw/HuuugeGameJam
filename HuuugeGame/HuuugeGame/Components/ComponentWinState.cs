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
    class ComponentWinState : StateTemplate
    {
        private Button retryButton, quitGameButton;
        private List<Button> _buttons;
        const int buttons_count = 3;    
        int currently_selected;
        float middleX, posY;
        public ComponentWinState()
        {
            currently_selected = 0;
            middleX = (Globals.screenSize.X - Globals.yellowButton.Width) / 2;
            posY = (Globals.screenSize.Y - (Globals.yellowButton.Height * buttons_count) - (50 * buttons_count - 1)) / 2;
            retryButton = new Button(Globals.yellowButton, Globals.defaultFont, "Retry")
            {
                Position = new Vector2(middleX, posY+50),
                Text = "Retry",
            };
            quitGameButton = new Button(Globals.yellowButton, Globals.defaultFont, "Quit")
            {
                Position = new Vector2(middleX, retryButton.Position.Y + Globals.yellowButton.Height + 50),
                Text = "Quit",
            };

            _buttons = new List<Button>()
            {
                retryButton,
                quitGameButton,
            };
            _buttons[0]._isSelected = true;
        }
        public void Draw()
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.DrawString(Globals.defaultFont, "Wygrywa " + "winner", new Vector2(Globals.screenSize.X/2-60, posY),Color.White);
            foreach (var button in _buttons)
            {
                button.Draw(Globals.spriteBatch);
            }
            Globals.spriteBatch.End();
        }

        public void Update()
        {
            MenuControls();
            Draw();
        }
        public void MenuControls()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                refreshSelectedBtn(false);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                refreshSelectedBtn(true);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                String name = _buttons[currently_selected].nameBtn;
                if (name.Equals("Retry"))
                {
                    Globals.activeState = Globals.enGameStates.GAME;
                }
                else if (name.Equals("Quit"))
                {
                    Globals.activeState = Globals.enGameStates.EXIT;
                }

            }

            //true - w doł
            //false - w góre
            void refreshSelectedBtn(bool change)
            {
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
    }
}
