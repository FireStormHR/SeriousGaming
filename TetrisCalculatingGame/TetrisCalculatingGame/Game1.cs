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
        public int screen_depth, screen_width, PlayerScore, Lifes, Difficulty;
        public GameState gameState;
        public Calc calc;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameState = new GameState(All_Textures, oldState, oldMouse); //All textures have a key, with as return: texture, starting point, clickarea

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

        public void StartGameFirstTime()
        {
            if (AllSpritefontTexts.Count < 8)
            {
                //#7
                calc = new Calc(this.Difficulty);
                Vector2 TheSum = new Vector2((float)3.69 / 5 * screen_width + AllSpritefontTexts[3].ClickArea.Width, (float)1.0 / (float)8.9 * (float)screen_depth);
                AllSpritefontTexts.Add(new SpritefontText(Arial_32, calc.StringSom, TheSum, new Rectangle((int)TheSum.X, (int)TheSum.Y, (int)Arial_32.MeasureString(calc.StringSom).X, (int)Arial_32.MeasureString(calc.StringSom).Y), Color.Black));
                //#8
                Vector2 TheScore = new Vector2((float)4.0 / 5 * screen_width + AllSpritefontTexts[1].ClickArea.Width, (float)1.0 / (float)15 * (float)screen_depth);
                AllSpritefontTexts.Add(new SpritefontText(Arial_32, PlayerScore.ToString(), TheScore, new Rectangle((int)TheScore.X, (int)TheScore.Y, (int)Arial_32.MeasureString(PlayerScore.ToString()).X, (int)Arial_32.MeasureString(PlayerScore.ToString()).Y), Color.Black));
                //#9
                Vector2 LvlUpPos = new Vector2((float)3.55 / 5 * screen_width, (float)1.0 / (float)4 * (float)screen_depth);
                AllSpritefontTexts.Add(new SpritefontText(Arial_32, "Level up! Faster!", LvlUpPos, new Rectangle((int)LvlUpPos.X, (int)LvlUpPos.Y, (int)Arial_32.MeasureString("Level up! Faster!").X, (int)Arial_32.MeasureString("Level up! Faster!").Y), Color.Red));
                //#10
                Vector2 GameOverPos = new Vector2((float)1 / 6 * screen_width, (float)1.4 / (float)3 * (float)screen_depth);
                AllSpritefontTexts.Add(new SpritefontText(Arial_32, "Game Over, your end score:", GameOverPos, new Rectangle((int)GameOverPos.X, (int)GameOverPos.Y, (int)Arial_32.MeasureString("Game Over, your end score:").X, (int)Arial_32.MeasureString("Game Over, your end score:").Y), Color.Red));
            }
            else
            {
                //#7
                calc = new Calc(this.Difficulty);
                Vector2 TheSum = new Vector2((float)3.69 / 5 * screen_width + AllSpritefontTexts[3].ClickArea.Width, (float)1.0 / (float)8.9 * (float)screen_depth);
                AllSpritefontTexts[7] = new SpritefontText(Arial_32, calc.StringSom, TheSum, new Rectangle((int)TheSum.X, (int)TheSum.Y, (int)Arial_32.MeasureString(calc.StringSom).X, (int)Arial_32.MeasureString(calc.StringSom).Y), Color.Black);
                //#8
                Vector2 TheScore = new Vector2((float)4.0 / 5 * screen_width + AllSpritefontTexts[1].ClickArea.Width, (float)1.0 / (float)15 * (float)screen_depth);
                AllSpritefontTexts[8] = new SpritefontText(Arial_32, PlayerScore.ToString(), TheScore, new Rectangle((int)TheScore.X, (int)TheScore.Y, (int)Arial_32.MeasureString(PlayerScore.ToString()).X, (int)Arial_32.MeasureString(PlayerScore.ToString()).Y), Color.Black);

            }



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
            PlayerScore = 0;
            Lifes = 5;
            Difficulty = 2;
            
            //#0
            Arial_32 = Content.Load<SpriteFont>("NewSpriteFont");
            Vector2 ToTheGamePos = new Vector2((float)2.0 / 5 * screen_width, (float)1.0 / 3 * (float)screen_depth);
            AllSpritefontTexts.Add(new SpritefontText(Arial_32, "To the game", ToTheGamePos, new Rectangle((int)ToTheGamePos.X, (int)ToTheGamePos.Y, (int)Arial_32.MeasureString("To the game").X, (int)Arial_32.MeasureString("To the game").Y), Color.Black));
            //#1
            Vector2 ScoreTextPos = new Vector2((float)4.0 / 5 * screen_width, (float)1.0 / 15 * (float)screen_depth);
            AllSpritefontTexts.Add(new SpritefontText(Arial_32, "Score:", ScoreTextPos, new Rectangle((int)ScoreTextPos.X, (int)ScoreTextPos.Y, (int)Arial_32.MeasureString("Score:").X, (int)Arial_32.MeasureString("Score:").Y), Color.Black));
            //#2
            Vector2 EscPos = new Vector2((float)1.0 / 20 * screen_width, (float)1.0 / 20 * (float)screen_depth);
            AllSpritefontTexts.Add(new SpritefontText(Arial_32, "Esc", EscPos, new Rectangle((int)EscPos.X, (int)EscPos.Y, (int)Arial_32.MeasureString("Esc").X, (int)Arial_32.MeasureString("Esc").Y), Color.Black));
            //#3
            Vector2 Exercise = new Vector2((float)3.66 / 5 * screen_width, (float)1.0 / (float)8.9 * (float)screen_depth);
            AllSpritefontTexts.Add(new SpritefontText(Arial_32, "Exercise:", Exercise, new Rectangle((int)Exercise.X, (int)Exercise.Y, (int)Arial_32.MeasureString("Exercise:").X, (int)Arial_32.MeasureString("Exercise:").Y), Color.Black));
            //#4
            Vector2 DifficultyPos = new Vector2((float)16.0 / 20 * screen_width - 30, (float)1.0 / 20 * (float)screen_depth);
            AllSpritefontTexts.Add(new SpritefontText(Arial_32, "Difficulty:", DifficultyPos, new Rectangle((int)DifficultyPos.X, (int)DifficultyPos.Y, (int)Arial_32.MeasureString("Difficulty:").X, (int)Arial_32.MeasureString("Difficulty:").Y), Color.Black));
            //#5
            Vector2 PlusMinusPos = new Vector2((float)16.0 / 20 * screen_width, (float)2.0 / 20 * (float)screen_depth);
            AllSpritefontTexts.Add(new SpritefontText(Arial_32, "1: Plus/Minus", PlusMinusPos, new Rectangle((int)PlusMinusPos.X, (int)PlusMinusPos.Y, (int)Arial_32.MeasureString("1: Plus/Minus").X, (int)Arial_32.MeasureString("1: Plus/Minus").Y), Color.Red));
            //#6
            Vector2 MultiplyPos = new Vector2((float)16.0 / 20 * screen_width, (float)3.0 / 20 * (float)screen_depth);
            AllSpritefontTexts.Add(new SpritefontText(Arial_32, "2: Multiply/Divide", MultiplyPos, new Rectangle((int)MultiplyPos.X, (int)MultiplyPos.Y, (int)Arial_32.MeasureString("2: Multiply/Divide").X, (int)Arial_32.MeasureString("2: Multiply/Divide").Y), Color.Black));


            //All textures have a key, with as return: texture, starting point, clickarea
            Vector2 f1carPos = new Vector2((float)1.0 / 8 * screen_width, (float)1.0 / 2 * screen_depth);
            Texture2D jpgf1car = Content.Load<Texture2D>("formulacar.jpg");
            gameState.All_Textures.Add("f1car", new Tuple <Texture2D, Vector2, Rectangle>(jpgf1car, f1carPos, new Rectangle((int)f1carPos.X, (int)f1carPos.Y, jpgf1car.Width, jpgf1car.Height)));
            //#
            Vector2 RosterPos = new Vector2((float)300, (float)30);
            Texture2D RosterPNG = Content.Load<Texture2D>("TheMatrix.png"); //Roster is 785 hoog en 812 breed, begint bij x 300 en y 30
            gameState.All_Textures.Add("Roster", new Tuple<Texture2D, Vector2, Rectangle>(RosterPNG, RosterPos, new Rectangle((int)RosterPos.X, (int)RosterPos.Y, RosterPNG.Width, RosterPNG.Height)));
            //#
            Vector2 SumBoxPos = new Vector2((float)301, (float)30);
            Texture2D SumBoxPNG = Content.Load<Texture2D>("SumBox.png"); //Sumbox is 785 hoog en 81 breed, begint bij x 301 en y 30
            gameState.All_Textures.Add("SumBox", new Tuple<Texture2D, Vector2, Rectangle>(SumBoxPNG, SumBoxPos, new Rectangle((int)SumBoxPos.X, (int)SumBoxPos.Y, SumBoxPNG.Width, SumBoxPNG.Height)));
            //#
            Vector2 FirstHeartPos = new Vector2((float)2.5 / 4 * screen_width, (float)1.0 / (float)2.5 * screen_depth);
            Texture2D HeartPNG = Content.Load<Texture2D>("heart.png"); 
            gameState.All_Textures.Add("Heart", new Tuple<Texture2D, Vector2, Rectangle>(HeartPNG, FirstHeartPos, new Rectangle((int)FirstHeartPos.X, (int)FirstHeartPos.Y, HeartPNG.Width, HeartPNG.Height)));
            //#
            Vector2 BlackScreenPos = new Vector2(0,0);
            Texture2D BlackScreenPNG = Content.Load<Texture2D>("TransBlack.png");
            gameState.All_Textures.Add("TransBlack", new Tuple<Texture2D, Vector2, Rectangle>(BlackScreenPNG, BlackScreenPos, new Rectangle((int)BlackScreenPos.X, (int)BlackScreenPos.Y, BlackScreenPNG.Width, BlackScreenPNG.Height)));




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
            
            if (gameState.Menu == true)
                gameState.CheckMenuClicks(graphics, this);

            else if (gameState.EndScreen == true)
                gameState.CheckEndScreen(graphics, this);

            else if (gameState.In_Game == true)
                gameState.CheckGameClicks(graphics, this);
            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (gameState.Menu == true)
            {
                spriteBatch.DrawString(AllSpritefontTexts[0].TextType, AllSpritefontTexts[0].StringToShow, AllSpritefontTexts[0].StringStartPos, AllSpritefontTexts[0].Colour);
                spriteBatch.DrawString(AllSpritefontTexts[2].TextType, AllSpritefontTexts[2].StringToShow, AllSpritefontTexts[2].StringStartPos, AllSpritefontTexts[2].Colour);
                spriteBatch.DrawString(AllSpritefontTexts[4].TextType, AllSpritefontTexts[4].StringToShow, AllSpritefontTexts[4].StringStartPos, AllSpritefontTexts[4].Colour);
                spriteBatch.DrawString(AllSpritefontTexts[5].TextType, AllSpritefontTexts[5].StringToShow, AllSpritefontTexts[5].StringStartPos, AllSpritefontTexts[5].Colour);
                spriteBatch.DrawString(AllSpritefontTexts[6].TextType, AllSpritefontTexts[6].StringToShow, AllSpritefontTexts[6].StringStartPos, AllSpritefontTexts[6].Colour);

                spriteBatch.Draw(gameState.All_Textures["f1car"].Item1, gameState.All_Textures["f1car"].Item2);
            }
            if (gameState.In_Game == true)
            {
                spriteBatch.DrawString(AllSpritefontTexts[1].TextType, AllSpritefontTexts[1].StringToShow, AllSpritefontTexts[1].StringStartPos, AllSpritefontTexts[1].Colour);
                spriteBatch.DrawString(AllSpritefontTexts[2].TextType, AllSpritefontTexts[2].StringToShow, AllSpritefontTexts[2].StringStartPos, AllSpritefontTexts[2].Colour);
                spriteBatch.DrawString(AllSpritefontTexts[3].TextType, AllSpritefontTexts[3].StringToShow, AllSpritefontTexts[3].StringStartPos, AllSpritefontTexts[3].Colour);
                spriteBatch.DrawString(AllSpritefontTexts[7].TextType, AllSpritefontTexts[7].StringToShow, AllSpritefontTexts[7].StringStartPos, AllSpritefontTexts[7].Colour);
                spriteBatch.DrawString(AllSpritefontTexts[8].TextType, AllSpritefontTexts[8].StringToShow, AllSpritefontTexts[8].StringStartPos, AllSpritefontTexts[8].Colour);
                if (gameState.NotifyFramesCounter!=0)
                    spriteBatch.DrawString(AllSpritefontTexts[9].TextType, AllSpritefontTexts[9].StringToShow, AllSpritefontTexts[9].StringStartPos, AllSpritefontTexts[9].Colour);

                spriteBatch.Draw(gameState.All_Textures["Roster"].Item1, gameState.All_Textures["Roster"].Item2);
                spriteBatch.Draw(gameState.All_Textures["SumBox"].Item1, gameState.All_Textures["SumBox"].Item2);
                for (int x = 0; x < Lifes; x = x + 1)
                {
                    spriteBatch.Draw(gameState.All_Textures["Heart"].Item1, new Vector2(gameState.All_Textures["Heart"].Item2.X + 100*x, gameState.All_Textures["Heart"].Item2.Y));
                }

            }

            if (gameState.EndScreen == true)
            {
                //Volgende stap is donkerder scherm, eindscore te zien en aangeven dat je op esc moet drukken
                spriteBatch.Draw(gameState.All_Textures["TransBlack"].Item1, gameState.All_Textures["TransBlack"].Item2);
                spriteBatch.DrawString(AllSpritefontTexts[10].TextType, AllSpritefontTexts[10].StringToShow, AllSpritefontTexts[10].StringStartPos, AllSpritefontTexts[10].Colour);
                spriteBatch.DrawString(AllSpritefontTexts[8].TextType, AllSpritefontTexts[8].StringToShow, new Vector2(AllSpritefontTexts[10].StringStartPos.X + AllSpritefontTexts[10].ClickArea.Width, AllSpritefontTexts[10].StringStartPos.Y), Color.Red);
                spriteBatch.DrawString(AllSpritefontTexts[2].TextType, "Menu", AllSpritefontTexts[2].StringStartPos, Color.Red);

            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}