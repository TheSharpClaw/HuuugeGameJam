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
            Globals.graphics.PreferredBackBufferWidth = 800;
            Globals.graphics.PreferredBackBufferHeight = 700;
            Globals.graphics.ApplyChanges();

            Globals.backgroundTexture = Content.Load<Texture2D>("textures/background_texture");
            Globals.yellowButton = Content.Load<Texture2D>("textures/yellow_button");

            Globals.defaultFont = Content.Load<SpriteFont>("DefaultFont");
            Globals.splashScreenLogo = Content.Load<Texture2D>("images/logo_test2");

            Globals.spiderTexture = Content.Load<Texture2D>("textures/spider_texture");
            Globals.spiderWebTexture = Content.Load<Texture2D>("textures/spider_web_texture");

            Globals.motherFlyTexture = Content.Load<Texture2D>("textures/mother_butterfly_texture");
            Globals.childrenFlyTexture = Content.Load<Texture2D>("textures/children_butterfly_texture");

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
            Globals.childrenFlyTexture = Content.Load<Texture2D>("textures/childrenFly");
            Globals.screenSize = new Vector2(Globals.graphics.PreferredBackBufferWidth, Globals.graphics.PreferredBackBufferHeight);
            manager = new StateManager();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || Globals.exit)
                Exit();

            manager.Update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
          base.Draw(gameTime);
        }
    }
}
