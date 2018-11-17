using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    public static class Globals
    {
        public static Texture2D tekstury_robimy_w_taki_sposób = null;

        public static SpriteBatch spriteBatch = null;
        public static GraphicsDeviceManager graphics = null;
        public static Vector2 screenSize;

        public static enGameStates activeState = enGameStates.SPLASH;
        public enum enGameStates
        {
            SPLASH,
            MENU,
            GAME,
            PAUSE,
            EXIT
        }

    }
}
