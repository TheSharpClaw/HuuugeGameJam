using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HuuugeGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
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

            Globals.backgroundTexture = Content.Load<Texture2D>("textures/background_texture");

            Globals.defaultFont = Content.Load<SpriteFont>("DefaultFont");
            Globals.splashScreenLogo = Content.Load<Texture2D>("images/logo_test2");

            Globals.spiderTexture = Content.Load<Texture2D>("textures/spider_texture");
            Globals.spiderWebTexture = Content.Load<Texture2D>("textures/spider_web_texture");

            Globals.yellowButton = Content.Load<Texture2D>("textures/yellow_button");

            Globals.hpBar = Content.Load<Texture2D>("textures/hp_bar_gray");
            Globals.hpBar_white = Content.Load<Texture2D>("textures/hp_bar_white");

            Globals.motherFlyTexture = Content.Load<Texture2D>("textures/mother_butterfly_texture");
            Globals.childrenFlyTexture = Content.Load<Texture2D>("textures/children_butterfly_texture");

            Globals.flowerTexture = Content.Load<Texture2D>("textures/flower_texture");

            Globals.stumpTexture = Content.Load<Texture2D>("textures/stump_texture");
            Globals.stone1Texture = Content.Load<Texture2D>("textures/stone1_texture");
            Globals.stone2Texture = Content.Load<Texture2D>("textures/stone2_texture");
            Globals.stone3Texture = Content.Load<Texture2D>("textures/stone3_texture");
            Globals.stone4Texture = Content.Load<Texture2D>("textures/stone4_texture");

            manager = new StateManager();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.motherFlyTexture = Content.Load<Texture2D>("textures/motherFly");
            Globals.childrenFlyTexture = Content.Load<Texture2D>("textures/children_butterfly_texture");
            Globals.screenSize = new Vector2(Globals.graphics.PreferredBackBufferWidth, Globals.graphics.PreferredBackBufferHeight);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            manager.Update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {


            // TODO: Add your drawing code here
            //manager.splashComponent.Draw();
            base.Draw(gameTime);
        }
    }
}
