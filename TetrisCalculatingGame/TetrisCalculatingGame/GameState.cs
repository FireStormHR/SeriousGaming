using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TetrisCalculatingGame
{
    public class GameState
    {
        public bool Menu, In_Game, EndScreen;
        public Dictionary<string, Tuple<Texture2D, Vector2, Rectangle>> All_Textures;
        public KeyboardState OldState;
        public MouseState OldMouse;
        public int Velocity, NotifyFramesCounter;

        public GameState(Dictionary<string, Tuple<Texture2D, Vector2, Rectangle>> All_textures, KeyboardState oldState, MouseState oldMouse)
        {
            this.Menu = true;
            this.In_Game = false;
            this.EndScreen = false;

            this.All_Textures = All_textures;
            this.OldState = oldState;
            this.OldMouse = oldMouse;
            this.Velocity = 1;
            this.NotifyFramesCounter = 0;
        }

        public void SetStateToMenu()
        {
            this.Menu = true;
            this.In_Game = false;
            this.EndScreen = false;
            
        }

        public void SetStateToGame()
        {
            this.Menu = false;
            this.In_Game = true;
            this.EndScreen = false;
        }
        public void ResetTheGame(GraphicsDeviceManager graphics, Game1 gamepje)
        {
            this.Velocity = 1;
            gamepje.Lifes = 5;
            gamepje.PlayerScore = 0;
            Vector2 SumBoxPos = new Vector2((float)301, (float)30);
            Texture2D SumBoxPNG = gamepje.Content.Load<Texture2D>("SumBox.png"); //Sumbox is 785 hoog en 81 breed, begint bij x 301 en y 30
            gamepje.All_Textures["SumBox"] = new Tuple<Texture2D, Vector2, Rectangle>(SumBoxPNG, SumBoxPos, new Rectangle((int)SumBoxPos.X, (int)SumBoxPos.Y, SumBoxPNG.Width, SumBoxPNG.Height));

        }

        //Until here, all methods and get setters are for changing the state. Beneath are all the inputchecks

        public void CheckMenuClicks(GraphicsDeviceManager graphics, Game1 gamepje)
        {
            //VOORBEELD

            KeyboardState newState = Keyboard.GetState();
            MouseState newMouse = Mouse.GetState();                                         //Hieronder staat de monogame/muis verhouding!!!
            Vector2 NewMouseCoordinates = new Vector2(newMouse.X, newMouse.Y);


            // Is the key down?
            if (newState.IsKeyDown(Keys.Escape))                                      
            {
                // If not down last update, key has just been pressed.
                if (!this.OldState.IsKeyDown(Keys.Escape))
                {
                    
                }
            }

            else if (this.OldState.IsKeyDown(Keys.Escape))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
                gamepje.Exit();
            }

            //----------------------------------------------------------new possibility-----------------------------------------
            //Depending on which gamestate boolean is true, it checks if the mouse clicked in one of the areas linked with it.

            if (newMouse.LeftButton == ButtonState.Pressed)
            {
                // If not down last update, key has just been pressed.
                if (this.OldMouse.LeftButton != ButtonState.Pressed)
                {
                    if (gamepje.AllSpritefontTexts[0].ClickArea.Contains(NewMouseCoordinates))
                    {
                        this.SetStateToGame();
                        this.ResetTheGame(graphics, gamepje);
                        gamepje.StartGameFirstTime();
                        
                        
                    }

                    if (gamepje.AllSpritefontTexts[2].ClickArea.Contains(NewMouseCoordinates))
                    {
                        gamepje.Exit();
                    }

                    if (gamepje.AllSpritefontTexts[5].ClickArea.Contains(NewMouseCoordinates))
                    {
                        gamepje.Difficulty = 2;
                        gamepje.AllSpritefontTexts[5].Colour = Color.Red;
                        gamepje.AllSpritefontTexts[6].Colour = Color.Black;
                    }

                    if (gamepje.AllSpritefontTexts[6].ClickArea.Contains(NewMouseCoordinates))
                    {
                        gamepje.Difficulty = 3;
                        gamepje.AllSpritefontTexts[5].Colour = Color.Black;
                        gamepje.AllSpritefontTexts[6].Colour = Color.Red;
                    }

                }
            }

            else if (this.OldMouse.LeftButton == ButtonState.Pressed) { }

            //----------------------------------------------------------new possibility-----------------------------------------



            // Update saved state.
            this.OldState = newState;
            this.OldMouse = newMouse;


        }

        public void CheckGameClicks(GraphicsDeviceManager graphics, Game1 gamepje)
        {
            KeyboardState newState = Keyboard.GetState();
            MouseState newMouse = Mouse.GetState();                                         //Hieronder staat de monogame/muis verhouding!!!
            Vector2 NewMouseCoordinates = new Vector2(newMouse.X, newMouse.Y);


            // Is the key down?
            if (newState.IsKeyDown(Keys.Escape))                                      
            {
                // If not down last update, key has just been pressed.
                if (!this.OldState.IsKeyDown(Keys.Escape))
                {
                    
                }
            }

            else if (this.OldState.IsKeyDown(Keys.Escape))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
                this.SetStateToMenu();
            }

            //----------------------------------------------------------new possibility-----------------------------------------
            //Depending on which gamestate boolean is true, it checks if the mouse clicked in one of the areas linked with it.

            if (newMouse.LeftButton == ButtonState.Pressed)
            {
                // If not down last update, key has just been pressed.
                if (this.OldMouse.LeftButton != ButtonState.Pressed)
                {

                    if (gamepje.AllSpritefontTexts[2].ClickArea.Contains(NewMouseCoordinates))
                    {
                        this.SetStateToMenu();
                    }

                }
            }

            else if (this.OldMouse.LeftButton == ButtonState.Pressed) { }

            //----------------------------------------------------------new possibility-----------------------------------------

            //Move sumbox to left or right

            // Is the key down?
            if (newState.IsKeyDown(Keys.Right) || newState.IsKeyDown(Keys.Left) || newState.IsKeyDown(Keys.Down) || newState.IsKeyDown(Keys.Space)) 
            {
                // If not down last update, key has just been pressed.

            }

            else if (this.OldState.IsKeyDown(Keys.Right) || this.OldState.IsKeyDown(Keys.Left) || this.OldState.IsKeyDown(Keys.Down) || this.OldState.IsKeyDown(Keys.Space))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
                Vector2 temp2 = new Vector2(this.All_Textures["SumBox"].Item2.X, this.All_Textures["SumBox"].Item2.Y); //coor of sumbox

                if (this.OldState.IsKeyDown(Keys.Right) && !newState.IsKeyDown(Keys.Right) && temp2.X < 1030)
                {
                    temp2.X = temp2.X + 81;
                    this.All_Textures["SumBox"] = new Tuple<Texture2D, Vector2, Rectangle>(gamepje.All_Textures["SumBox"].Item1, temp2, gamepje.All_Textures["SumBox"].Item3);

                }

                else if (this.OldState.IsKeyDown(Keys.Left) && !newState.IsKeyDown(Keys.Left) && temp2.X > 301)
                {
                    temp2.X = temp2.X - 81;
                    this.All_Textures["SumBox"] = new Tuple<Texture2D, Vector2, Rectangle>(gamepje.All_Textures["SumBox"].Item1, temp2, gamepje.All_Textures["SumBox"].Item3);
                }

                else if ((this.OldState.IsKeyDown(Keys.Down) && !newState.IsKeyDown(Keys.Down)) || (this.OldState.IsKeyDown(Keys.Space) && !newState.IsKeyDown(Keys.Space)))
                {
                    temp2.Y = temp2.Y + 150;
                    this.All_Textures["SumBox"] = new Tuple<Texture2D, Vector2, Rectangle>(gamepje.All_Textures["SumBox"].Item1, temp2, gamepje.All_Textures["SumBox"].Item3);
                }


            }

            //----------------------------------------------------------new possibility-----------------------------------------



            //Let the sumbox go down
            var temp = this.All_Textures["SumBox"].Item2;
            temp.Y = temp.Y + this.Velocity;

            //Check for right answer here
            if (temp.Y > 780)
            {
                
                float AnswerOfUser = (temp.X - 301) / 81;

                if (gamepje.calc.SomAnswer == AnswerOfUser)
                {
                    gamepje.PlayerScore = gamepje.PlayerScore + 1;
                    gamepje.AllSpritefontTexts[8].StringToShow = gamepje.PlayerScore.ToString();
                    if (gamepje.PlayerScore %5 == 0)
                    {
                        this.Velocity = this.Velocity + 1;
                        this.NotifyFramesCounter = NotifyFramesCounter + 1;
                    }

                }
                else
                {
                    gamepje.Lifes = gamepje.Lifes - 1;
                    if (gamepje.Lifes <= 0)
                    {
                        this.EndScreen = true;
                                             
                    }
                }


                gamepje.calc = new Calc(gamepje.Difficulty);
                gamepje.AllSpritefontTexts[7].StringToShow = gamepje.calc.StringSom;
                temp.Y = 30;
            }

            //Give notification about block speeding up
            if (NotifyFramesCounter != 0)
            {
                this.NotifyFramesCounter = NotifyFramesCounter + 1;
                if (this.NotifyFramesCounter > 120)
                {
                    this.NotifyFramesCounter = 0;
                }
            }

            this.All_Textures["SumBox"] = new Tuple<Texture2D, Vector2, Rectangle>(gamepje.All_Textures["SumBox"].Item1, temp, gamepje.All_Textures["SumBox"].Item3);

            

            // Update saved state.
            this.OldState = newState;
            this.OldMouse = newMouse;

        }

        public void CheckEndScreen(GraphicsDeviceManager graphics, Game1 gamepje)
        {
            //VOORBEELD

            KeyboardState newState = Keyboard.GetState();
            MouseState newMouse = Mouse.GetState();                                         //Hieronder staat de monogame/muis verhouding!!!
            Vector2 NewMouseCoordinates = new Vector2(newMouse.X, newMouse.Y);


            // Is the key down?
            if (newState.IsKeyDown(Keys.Escape))
            {
                // If not down last update, key has just been pressed.
                if (!this.OldState.IsKeyDown(Keys.Escape))
                {

                }
            }

            else if (this.OldState.IsKeyDown(Keys.Escape))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
                this.ResetTheGame(graphics, gamepje);
                this.SetStateToMenu();
            }

            //----------------------------------------------------------new possibility-----------------------------------------
            //Depending on which gamestate boolean is true, it checks if the mouse clicked in one of the areas linked with it.

            if (newMouse.LeftButton == ButtonState.Pressed)
            {
                // If not down last update, key has just been pressed.
                if (this.OldMouse.LeftButton != ButtonState.Pressed)
                {
                    if (gamepje.AllSpritefontTexts[0].ClickArea.Contains(NewMouseCoordinates))
                    {
                        this.ResetTheGame(graphics, gamepje);
                        this.SetStateToMenu();

                    }

                    if (gamepje.AllSpritefontTexts[2].ClickArea.Contains(NewMouseCoordinates))
                    {
                        this.ResetTheGame(graphics, gamepje);
                        this.SetStateToMenu();
                    }

                }
            }

            else if (this.OldMouse.LeftButton == ButtonState.Pressed) { }

            //----------------------------------------------------------new possibility-----------------------------------------



            // Update saved state.
            this.OldState = newState;
            this.OldMouse = newMouse;


        }

    }
}
