using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    class StateManager
    {
        ComponentGame gameComponent = new ComponentGame();
        ComponentMenu menuComponent = new ComponentMenu();
        public ComponentSplash splashComponent = new ComponentSplash();
        public void Update()
        {
            //TU SIE DZIEJE INTERPRETACJA STANÓW
            switch (Globals.activeState)
            {
                case Globals.enGameStates.SPLASH:
                    splashComponent.Update();
                    break;
                case Globals.enGameStates.MENU:
                    menuComponent.Update();
                    break;
                case Globals.enGameStates.GAME:
                    gameComponent.Update();
                    break;
                case Globals.enGameStates.PAUSE:
                    break;
                case Globals.enGameStates.EXIT:
                    break;
            }
        }
    }
}
