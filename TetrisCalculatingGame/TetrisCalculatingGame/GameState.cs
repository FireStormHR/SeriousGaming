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
        public bool Menu, In_Game;
        public Dictionary<string, Tuple<Texture2D, Vector2, Rectangle>> All_Textures;
        public List<SpritefontText> AllSpritefontTexts;
        public KeyboardState OldState;
        public MouseState OldMouse;

        public GameState(Dictionary<string, Tuple<Texture2D, Vector2, Rectangle>> All_textures, List<SpritefontText> AllSpritefontTexts, KeyboardState oldState, MouseState oldMouse)
        {
            this.Menu = true;
            this.In_Game = false;

            this.All_Textures = All_textures;
            this.AllSpritefontTexts = AllSpritefontTexts;
            this.OldState = oldState;
            this.OldMouse = oldMouse;
        }

        public void SetStateToMenu()
        {
            this.Menu = true;
            this.In_Game = false;
            
        }

        public void SetStateToGame()
        {
            this.Menu = false;
            this.In_Game = true;
        }

        //Until here, all methods and get setters are for changing the state. Beneath are all the inputchecks

        public void CheckMenuClicks(GraphicsDeviceManager graphics, Game1 gamepje)
        {
            //VOORBEELD

            KeyboardState newState = Keyboard.GetState();
            MouseState newMouse = Mouse.GetState();                                         //Hieronder staat de monogame/muis verhouding!!!
            Vector2 NewMouseCoordinates = new Vector2(newMouse.X, newMouse.Y);


            // Is the key down?
            if (newState.IsKeyDown(Keys.Escape))                                      //press A to change full screen mode or not
            {
                // If not down last update, key has just been pressed.
                if (!this.OldState.IsKeyDown(Keys.Escape))
                {
                    gamepje.Exit();
                }
            }

            else if (this.OldState.IsKeyDown(Keys.Escape))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
            }

            //----------------------------------------------------------new possibility-----------------------------------------
            //Depending on which gamestate boolean is true, it checks if the mouse clicked in one of the areas linked with it.

            if (newMouse.LeftButton == ButtonState.Pressed)
            {
                // If not down last update, key has just been pressed.
                if (this.OldMouse.LeftButton != ButtonState.Pressed)
                {
                    if (AllSpritefontTexts[0].ClickArea.Contains(NewMouseCoordinates))
                    {
                        this.SetStateToGame();
                        
                    }

                    if (AllSpritefontTexts[2].ClickArea.Contains(NewMouseCoordinates))
                    {
                        gamepje.Exit();
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
                    this.SetStateToMenu();
                }
            }

            else if (this.OldState.IsKeyDown(Keys.Escape))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
            }

            //----------------------------------------------------------new possibility-----------------------------------------
            //Depending on which gamestate boolean is true, it checks if the mouse clicked in one of the areas linked with it.

            if (newMouse.LeftButton == ButtonState.Pressed)
            {
                // If not down last update, key has just been pressed.
                if (this.OldMouse.LeftButton != ButtonState.Pressed)
                {

                    if (AllSpritefontTexts[2].ClickArea.Contains(NewMouseCoordinates))
                    {
                        this.SetStateToMenu();
                    }

                }
            }

            else if (this.OldMouse.LeftButton == ButtonState.Pressed) { }

            //----------------------------------------------------------new possibility-----------------------------------------

            // Is the key down?
            if (newState.IsKeyDown(Keys.Right) || newState.IsKeyDown(Keys.Left)) //press A to change full screen mode or not
            {
                // If not down last update, key has just been pressed.

            }

            else if (this.OldState.IsKeyDown(Keys.Right) || this.OldState.IsKeyDown(Keys.Left))
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

            }







            var temp = this.All_Textures["SumBox"].Item2;
            temp.Y = temp.Y + 1;
            this.All_Textures["SumBox"] = new Tuple<Texture2D, Vector2, Rectangle>(gamepje.All_Textures["SumBox"].Item1, temp, gamepje.All_Textures["SumBox"].Item3);

            // Update saved state.
            this.OldState = newState;
            this.OldMouse = newMouse;

        }


    }
}
