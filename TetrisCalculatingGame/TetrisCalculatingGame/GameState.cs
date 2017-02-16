using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCalculatingGame
{
    public class GameState
    {
        private bool Menu, In_Game;
        public GameState(bool dsds)
        {
            this.Menu = true;
            this.In_Game = false;

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


    }
}
