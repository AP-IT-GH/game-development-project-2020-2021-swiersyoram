using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.gamestates.startmenu
{
    class Button
    {
        public Texture2D Texture { get; }
        public Vector2 Positie { get; set; }
        public Button(Texture2D texture, Vector2 positie)
        {
            Texture = texture;
            Positie = positie;
        }
        
        public bool update(MouseState mouse)
        {
            if(mouse.X > Positie.X && mouse.X < Positie.X + Texture.Width && mouse.Y > Positie.Y && mouse.Y < Positie.Y + Texture.Height)
            {
                if(mouse.LeftButton == ButtonState.Pressed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        
    }
}
