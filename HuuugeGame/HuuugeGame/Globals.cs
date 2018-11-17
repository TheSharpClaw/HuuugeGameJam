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

        //TEXTURES
        public static Texture2D backgroundTexture;
        
        public static enGameStates activeState = enGameStates.TEST;

        public static Texture2D MotherFlyTexture { get; set; }
        public static Texture2D ChildrenFlyTexture { get; set; }

        public static Random RandomBitches { get; set; } = new Random(1000);

        public enum enGameStates
        {
            SPLASH,
            MENU,
            GAME,
            PAUSE,
            EXIT,
            TEST
        }

    }
}
