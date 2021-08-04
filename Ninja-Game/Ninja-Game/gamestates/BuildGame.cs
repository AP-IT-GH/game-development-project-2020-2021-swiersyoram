using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.gamestates
{
    class BuildGame
    {

       

         public static void build (GraphicsDeviceManager _graphics,int windowWidth,int windowHeight)
        {

            _graphics.PreferredBackBufferWidth = windowWidth;
            _graphics.PreferredBackBufferHeight = windowHeight;
            _graphics.ApplyChanges();
        }
    }
}
