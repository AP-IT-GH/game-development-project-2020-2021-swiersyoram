using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.map
{
    class Level:ILevel
    {
        private SpriteBatch _spriteBatch;
        private ContentManager Content;

        private Texture2D _gameBackground;
        private Texture2D _crate;

        private List<Rectangle> crates;

        public Level(SpriteBatch spritebatch, ContentManager content, List<Rectangle> Crates)
        {
            _spriteBatch = spritebatch;
            Content = content;
            crates = Crates;
        }

        public void load()
        {
            _gameBackground = Content.Load<Texture2D>("background");
            _crate = Content.Load<Texture2D>("crate");
        }

        public List<Rectangle> layout()
        {
            return crates;
        }

        public void Draw()
        {
            _spriteBatch.Draw(_gameBackground, new Rectangle(0, 0, GameParameters.windowWidth, GameParameters.windowHeight), Color.White);
            foreach (var crate in crates)
            {
                _spriteBatch.Draw(_crate, crate, Color.White);

            }
        }
    }
}
