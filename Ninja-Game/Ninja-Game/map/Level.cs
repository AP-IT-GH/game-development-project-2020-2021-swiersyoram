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

        private Texture2D _deur;
        private Rectangle deur;

        private Texture2D _spike;
        private List<Rectangle> spikes;



        public Level(SpriteBatch spritebatch, ContentManager content, List<Rectangle> Crates, List<Rectangle> Spikes,Rectangle Deur)
        {
            _spriteBatch = spritebatch;
            Content = content;
            crates = Crates;
            spikes = Spikes;
            deur = Deur;
        }

        public void load()
        {
            _gameBackground = Content.Load<Texture2D>("background");
            _crate = Content.Load<Texture2D>("crate");
            _deur = Content.Load<Texture2D>("DoorLocked");
            _spike = Content.Load<Texture2D>("Spike");

        }

        public Dictionary<string,List<Rectangle>> layout()
        {
            var layout = new Dictionary<string, List<Rectangle>>()
            {
                {"crates",crates },
                {"door", new List<Rectangle>(){deur} },
                {"spikes", spikes }
            };

            return layout;
        }

        public void Draw()
        {
            _spriteBatch.Draw(_gameBackground, new Rectangle(0, 0, GameParameters.windowWidth, GameParameters.windowHeight), Color.White);
            _spriteBatch.Draw(_deur, deur,Color.White);

            foreach (var crate in crates)
            {
                _spriteBatch.Draw(_crate, crate, Color.White);

            }
            foreach (var spike in spikes)
            {
                _spriteBatch.Draw(_spike, spike, Color.White);

            }

        }
    }
}
