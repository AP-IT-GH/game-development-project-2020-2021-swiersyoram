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
        private float scale = 1f;
        public float Scale { get { return scale; } }

        public bool update(MouseState mouse)
        {
            if(mouse.X > Positie.X-Texture.Width/2 && mouse.X < Positie.X+Texture.Width/2 && mouse.Y > Positie.Y-Texture.Height/2 && mouse.Y < Positie.Y + Texture.Height / 2)
            {
                if(mouse.LeftButton == ButtonState.Pressed)
                {
                    return true;
                }
                else
                {
                    scale = 1.1f;
                    return false;
                }
            }
            else
            {
                scale = 1f;
                return false;
            }

        }
        
    }
}
