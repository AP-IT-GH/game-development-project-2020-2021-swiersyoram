using System;
using System.Collections.Generic;
using System.Text;
using IronManGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IronManGame.Menu
{
    class Rain : Component
    {
        private Texture2D _rain;
        private Vector2 rainPosition;
        private Random r = new Random();
        public Rain(Texture2D rain)
        {
            _rain = rain;
            
            rainPosition = new Vector2(r.Next(0,1600), r.Next(0,400));
        }
        public override void Update(GameTime gameTime)
        {

            if (rainPosition.Y >= 800) {
          
                rainPosition = new Vector2(r.Next(0, 1600), r.Next(0, 400));
            }
            else
            {
                rainPosition.Y += 10;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_rain, rainPosition, Color.White);
        }

        
    }
}
