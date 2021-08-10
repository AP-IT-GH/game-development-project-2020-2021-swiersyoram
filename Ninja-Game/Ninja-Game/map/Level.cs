using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NinjaGame.animation;
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

        private Texture2D _deur;

        private Texture2D _spike;

        private Animation coinsanimation;


        public List<Rectangle> Crates { get; set; }

        public List<Rectangle> Spikes { get; set; }
        public List<Vector2> Coins { get; set; }
        public List<Rectangle> Rotatedspikes { get; set; }

        public Rectangle Deur { get; set; }



        public Level(SpriteBatch spritebatch, ContentManager content, List<Rectangle> crates, List<Rectangle> spikes, List<Rectangle> rotatedspikes, List<Vector2> coins,Rectangle deur)
        {
            _spriteBatch = spritebatch;
            Content = content;
            Crates = crates;
            Spikes = spikes;
            Deur = deur;
            Rotatedspikes = rotatedspikes;
            Coins = new List<Vector2>(coins);
            coinsanimation = new Animation(content.Load<Texture2D>("coins"),0.1f,10,0.2f,true);

        }

        public void Load()
        {
            _gameBackground = Content.Load<Texture2D>("background");
            _crate = Content.Load<Texture2D>("crate");
            _deur = Content.Load<Texture2D>("DoorLocked");
            _spike = Content.Load<Texture2D>("Spike");

        }

       
        public void Update(GameTime gameTime)
        {
            coinsanimation.update(gameTime);
            if(this.Coins.Count == 0)
            {
                _deur = Content.Load<Texture2D>("DoorUnlocked");


            }
        }

        public void Draw()
        {
            _spriteBatch.Draw(_gameBackground, new Rectangle(0, 0, GameParameters.windowWidth, GameParameters.windowHeight), Color.White);
            _spriteBatch.Draw(_deur, Deur,Color.White);

            foreach (var crate in Crates)
            {
                _spriteBatch.Draw(_crate, crate, Color.White);

            }
            foreach (var spike in Spikes)
            {
                _spriteBatch.Draw(_spike, spike, Color.White);

            }
            foreach (var spike in Rotatedspikes)
            {
                _spriteBatch.Draw(_spike, spike, new Rectangle(0,0,_spike.Width, _spike.Height), Color.White,0f, Vector2.Zero, SpriteEffects.FlipVertically, 0f);
               
            }
            foreach (var coin in Coins)
            {
                _spriteBatch.Draw(coinsanimation.Texture, coin, coinsanimation.Frame, Color.White, 0f, Vector2.Zero, coinsanimation.Scale,SpriteEffects.FlipVertically, 0f);

            }

        }
    }
}
