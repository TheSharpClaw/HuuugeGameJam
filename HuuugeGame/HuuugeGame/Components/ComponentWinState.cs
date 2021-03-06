﻿using HuuugeGame.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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

        private int victorySEFlag = 0;

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
            quitGameButton = new Button(Globals.yellowButton, Globals.defaultFont, "MENU")
            {
                Position = new Vector2(middleX, retryButton.Position.Y + Globals.yellowButton.Height + 50),
                Text = "MENU",
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
            Globals.spriteBatch.Draw(Globals.backgroundTexture, new Vector2(0, 0), Color.White);
            Globals.spriteBatch.Draw(Globals.hpBar, new Rectangle(0, 0, 700, 600), new Color(0, 0, 0, 150));
            Globals.spriteBatch.DrawString(Globals.defaultFont, "THE WINNER IS: " + Globals.winner.ToString(), new Vector2(Globals.screenSize.X/2-95, posY),Color.White);
            foreach (var button in _buttons)
            {
                button.Draw(Globals.spriteBatch);
            }
            Globals.spriteBatch.End();
        }

        public void Update()
        {
            if(victorySEFlag == 0)
            {
                MediaPlayer.Stop();
                Globals.victorySoundEffect.Play(0.35f, 0, 0);
                victorySEFlag++;
            }
            else if(victorySEFlag <= 200)
            {
                MediaPlayer.Play(Globals.battleBackgroundMusic);
            }
            else
            {
                victorySEFlag++;
            }           

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

            }
            else if (KeypressTest(Keys.Space) || KeypressTest(Keys.Enter))
            {
                String name = _buttons[currently_selected].nameBtn;
                if (name.Equals("Retry"))
                {
                    Globals.activeState = Globals.enGameStates.GAME;
                }
                else if (name.Equals("MENU"))
                {
                    Globals.activeState = Globals.enGameStates.MENU;
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
        private bool KeypressTest(Keys theKey)
        {
            if (Globals.oldKeyState.IsKeyUp(theKey) && Globals.newKeyState.IsKeyDown(theKey))
                return true;
            return false;
        }
    }
}
