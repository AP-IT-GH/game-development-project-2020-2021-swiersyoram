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
        private Texture2D _roadbackground;
        private Layout layout;
        public Level(Texture2D background, Texture2D roadbackground, Texture2D platformbackground, Texture2D portalbackground , List<Rectangle> platforms)
        {
            _background = background;
            _roadbackground = roadbackground;
            

            layout = new Layout(platformbackground, portalbackground);
            foreach (var platform in platforms)
            {
                layout.addPlatform(platform);
               
            }


        }
    

        public void Update(GameTime gameTime)
        {
            layout.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, new Rectangle(0, 0, game.windowWidth, game.windowHeight), Color.White);
            spriteBatch.Draw(_roadbackground, new Rectangle(0, game.windowHeight-50, game.windowWidth,50), Color.White);
            layout.Draw(spriteBatch);
        }

    }
}
