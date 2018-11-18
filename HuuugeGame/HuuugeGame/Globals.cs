using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuuugeGame
{
    public static class Globals
    {
        public static bool exit = false;

        public static SpriteFont defaultFont;

        public static SpriteBatch spriteBatch = null;
        public static GraphicsDeviceManager graphics = null;
        public static Vector2 screenSize;

        public static Random RandomBitches { get; set; } = new Random(1000);
        //TEXTURES
        public static Texture2D splashScreenLogo;

        public static Texture2D hpBar;
        public static Texture2D hpBar_white;
        public static Texture2D yellowButton;

        public static Texture2D backgroundTexture;

        public static Texture2D spiderTexture;
        public static Texture2D spiderStaticTexture;
        public static Texture2D spiderWebTexture;

        public static Texture2D motherFlyTexture;
        public static Texture2D motherFlyStaticTexture;
        public static Texture2D childrenFlyTexture;

        public static Texture2D flowerTexture;

        public static Texture2D stumpTexture;
        public static Texture2D stone1Texture;
        public static Texture2D stone2Texture;
        public static Texture2D stone3Texture;
        public static Texture2D stone4Texture;
        public static Texture2D holeTexture;
        public static Texture2D bushTexture;

        public static Texture2D wsadIMG;
        public static Texture2D arrowsIMG;
        public static Texture2D shiftIMG;
        
        public static SoundEffect wilhelmScreamSE;

        public static KeyboardState oldKeyState;
        public static KeyboardState newKeyState;

        public static enGameStates activeState = enGameStates.SPLASH;
        public static string winner;

        public enum enGameStates
        {
            SPLASH,
            MENU,
            GAME,
            PAUSE,
            TEST,
            EXIT,
            WINSTATE,
            INFO
        }

    }
}
