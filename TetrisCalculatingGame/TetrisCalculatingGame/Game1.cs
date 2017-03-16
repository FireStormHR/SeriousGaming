using System;
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
        public Dictionary<string, Tuple<Texture2D, Vector2, Rectangle>> All_Textures = new Dictionary<string, Tuple<Texture2D, Vector2, Rectangle>>();
        public List<SpritefontText> AllSpritefontTexts = new List<SpritefontText>();
        public SpriteFont Arial_32 = null;
        public int screen_depth, screen_width;
        public GameState gameState;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameState = new GameState(All_Textures, AllSpritefontTexts, oldState, oldMouse); //All textures have a key, with as return: texture, starting point, clickarea
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            oldState = Keyboard.GetState();
            oldMouse = Mouse.GetState();
            IsMouseVisible = true; //You can see the cursor
            //graphics.IsFullScreen = true;                                                                //DISABLED FOR DEVELOPING REASONS
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; //Set xna resolution height to curr screen resolution
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;   //Set xna resolution width to curr screen resolution
            graphics.ApplyChanges();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            screen_depth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;                       //Get screen height
            screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            Arial_32 = Content.Load<SpriteFont>("NewSpriteFont");
            Vector2 ToTheGamePos = new Vector2((float)2.0 / 5 * screen_width, (float)1.0 / 3 * (float)screen_depth);
            AllSpritefontTexts.Add(new SpritefontText(Arial_32, "To the game", ToTheGamePos, new Rectangle((int)ToTheGamePos.X, (int)ToTheGamePos.Y, (int)Arial_32.MeasureString("To the game").X, (int)Arial_32.MeasureString("To the game").Y), Color.Black));
            Vector2 ScoreTextPos = new Vector2((float)4.0 / 5 * screen_width, (float)1.0 / 15 * (float)screen_depth);
            AllSpritefontTexts.Add(new SpritefontText(Arial_32, "Score:", ScoreTextPos, new Rectangle((int)ScoreTextPos.X, (int)ScoreTextPos.Y, (int)Arial_32.MeasureString("Score:").X, (int)Arial_32.MeasureString("Score:").Y), Color.Black));
            Vector2 EscPos = new Vector2((float)1.0 / 20 * screen_width, (float)1.0 / 20 * (float)screen_depth);
            AllSpritefontTexts.Add(new SpritefontText(Arial_32, "Esc", EscPos, new Rectangle((int)EscPos.X, (int)EscPos.Y, (int)Arial_32.MeasureString("Esc").X, (int)Arial_32.MeasureString("Esc").Y), Color.Black));





            //All textures have a key, with as return: texture, starting point, clickarea
            Vector2 f1carPos = new Vector2((float)1.0 / 8 * screen_width, (float)1.0 / 2 * screen_depth);
            Texture2D jpgf1car = Content.Load<Texture2D>("formulacar.jpg");
            gameState.All_Textures.Add("f1car", new Tuple <Texture2D, Vector2, Rectangle>(jpgf1car, f1carPos, new Rectangle((int)f1carPos.X, (int)f1carPos.Y, jpgf1car.Width, jpgf1car.Height)));


            
            


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

            Calc calc = new Calc(2); 
            Console.WriteLine(calc.StringSom + " heeft als antwoord: " + calc.SomAnswer);

            if (gameState.Menu == true)
            {
                gameState.CheckMenuClicks(graphics, this);
            }
            else if (gameState.In_Game == true)
            {
                gameState.CheckGameClicks(graphics);
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
            if (gameState.Menu == true)
            {
                spriteBatch.DrawString(AllSpritefontTexts[0].TextType, AllSpritefontTexts[0].StringToShow, AllSpritefontTexts[0].StringStartPos, AllSpritefontTexts[0].Colour);
                spriteBatch.DrawString(AllSpritefontTexts[2].TextType, AllSpritefontTexts[2].StringToShow, AllSpritefontTexts[2].StringStartPos, AllSpritefontTexts[2].Colour);
                spriteBatch.Draw(gameState.All_Textures["f1car"].Item1, gameState.All_Textures["f1car"].Item2);
            }
            if (gameState.In_Game == true)
            {
                spriteBatch.DrawString(AllSpritefontTexts[1].TextType, AllSpritefontTexts[1].StringToShow, AllSpritefontTexts[1].StringStartPos, AllSpritefontTexts[1].Colour);
                spriteBatch.DrawString(AllSpritefontTexts[2].TextType, AllSpritefontTexts[2].StringToShow, AllSpritefontTexts[2].StringStartPos, AllSpritefontTexts[2].Colour);

            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}