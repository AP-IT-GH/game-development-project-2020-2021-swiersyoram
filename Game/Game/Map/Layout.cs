using IronManGame.Animaties;
using IronManGame;
using IronManGame.Input;
using IronManGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Text;

namespace IronManGame.Map
{
    class Layout
    {
        private Texture2D _platformBackground;
        public static List<Rectangle> platforms;
        public static Vector2 portalposition = new Vector2(1500, 300);
        private Portal portal;

        public Layout(Texture2D platformBackground, Texture2D portalbackground)
        {
            _platformBackground = platformBackground;
            platforms = new List<Rectangle>();
            portal = new Portal(portalbackground, portalposition);
        }
        public void addPlatform(Rectangle platform)
        {
            platforms.Add(platform);
            
        }
        public void Update(GameTime gameTime)
        {
            portal.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var platform in platforms)
            {
                spriteBatch.Draw(_platformBackground, platform, Color.White);
            }
            portal.Draw(spriteBatch);
        }
    }
}
