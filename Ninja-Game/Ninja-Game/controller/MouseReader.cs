using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.controller
{
    class MouseReader :IMouseReader
    {
        public MouseState Inputreader()
        {
            MouseState mouse = Mouse.GetState();
            

            return mouse;
        }
    }
}
