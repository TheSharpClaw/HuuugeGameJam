using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    class StateManager
    {
        public void Update()
        {
            switch (Globals.activeState)
            {
                case Globals.enGameStates.SPLASH:
                    break;
                case Globals.enGameStates.MENU:
                    break;
                case Globals.enGameStates.GAME:
                    break;
                case Globals.enGameStates.PAUSE:
                    break;
                case Globals.enGameStates.EXIT:
                    break;
            }
        }
    }
}
