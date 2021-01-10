using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IronManGame.Map
{
    class Level
    {
        private Texture2D _background;
        public Level(Texture2D background)
        {
            _background = background; 
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, new Rectangle(0, 0, game.windowWidth, game.windowHeight), Color.White);
        }

    }
}
