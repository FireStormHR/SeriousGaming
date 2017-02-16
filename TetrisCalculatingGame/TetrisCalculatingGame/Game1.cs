using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TetrisCalculatingGame
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public KeyboardState oldState;             //Makes it possible to compare the old keyboard state with the new one
        public MouseState oldMouse;                //Makes it possible to compare the old mouse state with the new one
        public SpriteBatch spriteBatch;
        public Dictionary<string, Texture2D> All_Textures = new Dictionary<string, Texture2D>();
        public SpriteFont Arial_32 = null;
        public int screen_depth, screen_width;
        public GameState gameState;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameState = new GameState(All_Textures, oldState, oldMouse);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            oldState = Keyboard.GetState();
            oldMouse = Mouse.GetState();
            IsMouseVisible = true; //You can see the cursor
            //graphics.IsFullScreen = true;                                                                //disabled for developing reasons
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; //Set xna resolution height to curr screen resolution
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;   //Set xna resolution width to curr screen resolution
            graphics.ApplyChanges();
            screen_depth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            gameState.All_Textures.Add("f1car", Content.Load<Texture2D>("formulacar.jpg"));


            Arial_32 = Content.Load<SpriteFont>("NewSpriteFont");
            


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Arial_32 = null;
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameState.Menu == true)
            {
                
            }
            else if (gameState.In_Game == true)
            {
                
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.DrawString(Arial_32, "Back to menu", new Vector2((float)2.0/5*(float)screen_width, (float)1.0/3*(float)screen_depth), Color.Black);
            spriteBatch.Draw(gameState.All_Textures["f1car"], new Vector2((float)1.0/8*screen_width, (float)1.0/2*screen_depth));
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}