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

        public static Texture2D flowerTexture;

        public static Texture2D stumpTexture;
        public static Texture2D stone1Texture;
        public static Texture2D stone2Texture;
        public static Texture2D stone3Texture;
        public static Texture2D stone4Texture;

        public static enGameStates activeState = enGameStates.GAME;
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
