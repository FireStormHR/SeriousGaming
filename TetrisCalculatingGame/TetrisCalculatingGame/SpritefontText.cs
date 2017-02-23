using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TetrisCalculatingGame
{
    public class SpritefontText
    {
        public SpriteFont TextType;
        public string StringToShow;
        public Vector2 StringStartPos;
        public Rectangle ClickArea;
        public Color Colour;

        public SpritefontText(SpriteFont TextType, string StringToShow, Vector2 StringStartPos, Rectangle ClickArea, Color Colour)
        {
            this.TextType = TextType;
            this.StringToShow = StringToShow;
            this.StringStartPos = StringStartPos;
            this.ClickArea = ClickArea;
            this.Colour = Colour;
        }



    }
}
