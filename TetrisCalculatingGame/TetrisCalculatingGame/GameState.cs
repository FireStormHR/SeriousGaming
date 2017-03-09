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

        public void CheckMenuClicks(GraphicsDeviceManager graphics)
        {
            //VOORBEELD

            KeyboardState newState = Keyboard.GetState();
            MouseState newMouse = Mouse.GetState();                                         //Hieronder staat de monogame/muis verhouding!!!
            Vector2 NewMouseCoordinates = new Vector2(newMouse.X, newMouse.Y);


            // Is the key down?
            if (newState.IsKeyDown(Keys.A))                                      //press A to change full screen mode or not
            {
                // If not down last update, key has just been pressed.
                if (!this.OldState.IsKeyDown(Keys.A))
                {
                    //d
                }
            }

            else if (this.OldState.IsKeyDown(Keys.A))
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

                }
            }

            else if (this.OldMouse.LeftButton == ButtonState.Pressed) { }

            //----------------------------------------------------------new possibility-----------------------------------------



            // Update saved state.
            this.OldState = newState;
            this.OldMouse = newMouse;


        }

        public void CheckGameClicks(GraphicsDeviceManager graphics)
        {

        }


    }
}
