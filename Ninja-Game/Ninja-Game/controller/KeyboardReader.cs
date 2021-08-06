using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.controller
{
    class KeyboardReader:IInputReader
    {
        private Vector2 richting;
        public KeyboardReader()
        {
            richting = new Vector2(0, 0);
        }
        public Vector2 Inputreader()
        {
            KeyboardState keyboard = Keyboard.GetState();
           

            if (keyboard.IsKeyDown(Keys.Right)|| keyboard.IsKeyDown(Keys.Left))
            {
                if (keyboard.IsKeyDown(Keys.Right))
                {
                    richting.X = 1;
                }
                if (keyboard.IsKeyDown(Keys.Left))
                {
                    richting.X = -1;
                }
                
            }
            else
            {
                richting.X = 0;
            }
            if (keyboard.IsKeyDown(Keys.Up))
            {
                richting.Y = 1;
            }
            else
            {
                richting.Y = 0;
            }


            return richting;
        }
    }
}
