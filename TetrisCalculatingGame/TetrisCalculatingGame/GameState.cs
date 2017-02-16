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
        public Dictionary<string, Texture2D> All_Textures;
        public KeyboardState OldState;
        public MouseState OldMouse;

        public GameState(Dictionary<string, Texture2D> All_textures, KeyboardState oldState, MouseState oldMouse)
        {
            this.Menu = true;
            this.In_Game = false;

            this.All_Textures = All_textures;
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

        public void CheckMenuClicks(GraphicsDeviceManager graphics)
        {



        }

        public void CheckGameClicks(GraphicsDeviceManager graphics)
        {
            ////VOORBEELD

            //KeyboardState newState = Keyboard.GetState();
            //MouseState newMouse = Mouse.GetState();                                         //Hieronder staat de monogame/muis verhouding!!!



            //float ThisWillBeX = newMouse.X * (Screen_Width_Ratio);          //Matches the pixel resolution with the mouse position
            //float ThisWillBeY = newMouse.Y * (Screen_Height_Ratio);
            //Vector2 NewMouseCoordinates = new Vector2(ThisWillBeX, ThisWillBeY); //Puts them together


            //// Is the key down?
            //if (newState.IsKeyDown(Keys.A))                                      //press A to change full screen mode or not
            //{
            //    // If not down last update, key has just been pressed.
            //    if (!this.oldState.IsKeyDown(Keys.A))
            //    {
            //        this.ChangeFullScreenMode(graphics);
            //    }
            //}

            //else if (this.oldState.IsKeyDown(Keys.A))
            //{
            //    // Key was down last update, but not down now, so
            //    // it has just been released.
            //}

            ////----------------------------------------------------------new possibility-----------------------------------------
            ////Depending on which gamestate boolean is tru, it checks if the mouse clicked in one of the areas linked with it.

            //if (newMouse.LeftButton == ButtonState.Pressed)
            //{
            //    // If not down last update, key has just been pressed.
            //    if (this.oldMouse.LeftButton != ButtonState.Pressed)
            //    {
            //        if (this.Main_Game == true) //Every pin gets folded
            //        {
            //            foreach (Monument Monumentje in Monumentenlijst)
            //            {
            //                Monumentje.Pin_Un_Folded = false;
            //            }

            //            foreach (Monument Monumentje in Monumentenlijst) //If mouse is in one of the rectangles, unfold that pin
            //            {
            //                if (Monumentje.Click_area.Contains(NewMouseCoordinates.X, NewMouseCoordinates.Y))
            //                {
            //                    Monumentje.ToggleFoldPin();
            //                }
            //            }

            //            //If pressed on the word menu, change gamestate booleans leading to main menu
            //            if (Main_menu_instance.Click_area_exit.Contains(NewMouseCoordinates.X, NewMouseCoordinates.Y)) { this.NextStep("Main_Menu"); }
            //        }

            //        else if (this.Main_Menu == true) //If in main menu, determine next gamestate
            //        {
            //            if (Main_menu_instance.Click_area_exit.Contains(NewMouseCoordinates.X, NewMouseCoordinates.Y)) { Program.Game.Exit(); }
            //            if (Main_menu_instance.Click_area_Start_map.Contains(NewMouseCoordinates.X, NewMouseCoordinates.Y)) { this.NextStep("Main_Game"); }
            //            if (Main_menu_instance.Click_area_start_graph.Contains(NewMouseCoordinates.X, NewMouseCoordinates.Y)) { this.NextStep("Windows_Form"); }


            //        }

            //    }
            //}

            //else if (this.oldMouse.LeftButton == ButtonState.Pressed) { }

            ////----------------------------------------------------------new possibility-----------------------------------------



            //// Update saved state.
            //this.oldState = newState;
            //this.oldMouse = newMouse;

        }


    }
}
