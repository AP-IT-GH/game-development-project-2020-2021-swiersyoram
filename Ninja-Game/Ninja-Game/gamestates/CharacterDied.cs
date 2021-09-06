using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NinjaGame.controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.gamestates
{
    class CharacterDied : IGameState
    {
        private SpriteBatch _spriteBatch;
        private ContentManager Content;
        private Texture2D restartscreen;

        public CharacterDied(SpriteBatch spritebatch, ContentManager content )
        {
            _spriteBatch = spritebatch;
            Content = content;

        }


        public void load()
        {
            restartscreen = Content.Load<Texture2D>("restart");
        }

        public void update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Space))
            {
                GameParameters.gamestate = gameState.restart;
            }
        }
        public void draw()
        {
            _spriteBatch.Draw(restartscreen, new Rectangle(0, 0, 1800, 1000), Color.White*0.1f);


        }
    }
}
