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
using System.Diagnostics;

namespace IronManGame.Map
{
    class Portal
    {
        private Texture2D _portalBackground;
        private Animatie portalAnimatie;
        private Vector2 _positie;

        public Portal(Texture2D portalbackground, Vector2 positie)
        {
            _positie = positie;
            _portalBackground = portalbackground;
            portalAnimatie = new Animatie();
            portalAnimatie.addFrame(new Rectangle(0, 0, 17, 35));
            portalAnimatie.addFrame(new Rectangle(17, 0, 17, 35));
            portalAnimatie.addFrame(new Rectangle(35, 0, 17, 35));
            portalAnimatie.addFrame(new Rectangle(52, 0, 17, 35));


        }
        public void Update(GameTime gameTime)
        {
            portalAnimatie.Update(gameTime);
            
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_portalBackground, _positie, portalAnimatie.currentframe, Color.White, 0f, new Vector2(0,35), 4f, SpriteEffects.None,0f);

        }
    }
}
