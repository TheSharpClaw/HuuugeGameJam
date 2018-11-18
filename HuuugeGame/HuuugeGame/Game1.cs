using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace HuuugeGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        StateManager manager;

        public Game1()
        {
            Globals.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Globals.graphics.PreferredBackBufferWidth = 700;
            Globals.graphics.PreferredBackBufferHeight = 600;
            Globals.graphics.ApplyChanges();


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Globals.defaultFont = Content.Load<SpriteFont>("DefaultFont");

            Globals.splashScreenLogo = Content.Load<Texture2D>("images/splash_logo");
            Globals.backgroundTexture = Content.Load<Texture2D>("textures/background_texture");

            Globals.yellowButton = Content.Load<Texture2D>("textures/yellow_button");

            Globals.hpBar = Content.Load<Texture2D>("textures/hp_bar_gray");
            Globals.hpBar_white = Content.Load<Texture2D>("textures/hp_bar_white");

            Globals.motherFlyTexture = Content.Load<Texture2D>("textures/mother_butterfly_texture");
            Globals.motherFlyStaticTexture = Content.Load<Texture2D>("textures/mother_butterfly_static_texture");
            Globals.childrenFlyTexture = Content.Load<Texture2D>("textures/children_butterfly_texture");

            Globals.spiderTexture = Content.Load<Texture2D>("textures/spider_texture");
            Globals.spiderStaticTexture = Content.Load<Texture2D>("textures/spider_static_texture");
            Globals.spiderWebTexture = Content.Load<Texture2D>("textures/spider_web_texture");

            Globals.flowerTexture = Content.Load<Texture2D>("textures/flower_texture");

            Globals.wsadIMG = Content.Load<Texture2D>("images/keys_WSAD");
            Globals.arrowsIMG = Content.Load<Texture2D>("images/keys_arrows");
            Globals.shiftIMG = Content.Load<Texture2D>("images/key_shift");

            Globals.stumpTexture = Content.Load<Texture2D>("textures/stump_texture");
            Globals.stone1Texture = Content.Load<Texture2D>("textures/stone1_texture");
            Globals.stone2Texture = Content.Load<Texture2D>("textures/stone2_texture");
            Globals.stone3Texture = Content.Load<Texture2D>("textures/stone3_texture");
            Globals.stone4Texture = Content.Load<Texture2D>("textures/stone4_texture");
            Globals.holeTexture = Content.Load<Texture2D>("textures/hole_texture");
            Globals.bushTexture = Content.Load<Texture2D>("textures/brush_texture");

            Globals.wilhelmScreamSE = Content.Load<SoundEffect>("sounds/Wilhelm_scream");

            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.screenSize = new Vector2(Globals.graphics.PreferredBackBufferWidth, Globals.graphics.PreferredBackBufferHeight);
            manager = new StateManager();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Globals.exit)
                Exit();
            if (!Globals.pause)
            {
                manager.Update();
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
