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
        public static Texture2D splashScreenLogo;
        public static Texture2D yellowButton;

        public static SpriteFont defaultFont;

        public static SpriteBatch spriteBatch = null;
        public static GraphicsDeviceManager graphics = null;
        public static Vector2 screenSize;

        //TEXTURES
        public static Texture2D backgroundTexture;

        public static Texture2D spiderTexture;
        public static Texture2D spiderWebTexture;

        public static Texture2D motherFlyTexture;
        public static Texture2D childrenFlyTexture;

        public static enGameStates activeState = enGameStates.MENU;
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
