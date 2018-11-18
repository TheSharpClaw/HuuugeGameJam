using HuuugeGame.Components;
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
        ComponentSplash splashComponent = new ComponentSplash();
        ComponentTest testComponent = new ComponentTest();
        ComponentWinState winStateComponent = new ComponentWinState();
        ComponentInfo componentInfo = new ComponentInfo();
        ComponentPause componentPause = new ComponentPause();
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
                    componentPause.Update();
                    break;
                case Globals.enGameStates.EXIT:
                    Globals.exit = true;
                    break;
                case Globals.enGameStates.TEST:
                    testComponent.Update();
                    break;
                case Globals.enGameStates.WINSTATE:
                    winStateComponent.Update();
                    break;
                case Globals.enGameStates.INFO:
                    componentInfo.Update();
                    break;
            }
        }
    }
}
