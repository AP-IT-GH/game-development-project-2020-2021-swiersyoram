using System;
using System.Collections.Generic;
using System.Text;
using IronManGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IronManGame.Game_interface
{
    class Button : Component
    {
        private SpriteBatch _spritebatch;
        public Button(SpriteBatch spriteBatch)
        {
            _spritebatch = spriteBatch;
        }
       
       
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public override void Update(GameTime gameTime, MouseState mousestate)
        {
           
        }
    }
}
