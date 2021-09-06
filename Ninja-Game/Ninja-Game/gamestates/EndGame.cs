using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.gamestates
{
    class EndGame : IGameState
    {
        private SpriteBatch _spriteBatch;
        private ContentManager Content;
        private Texture2D endscreen;

        private Game game;

        public EndGame(SpriteBatch spritebatch, ContentManager content, Game Game)
        {
            _spriteBatch = spritebatch;
            Content = content;
            game = Game;
        }


        public void load()
        {
            endscreen = Content.Load<Texture2D>("end");
        }

        public void update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }
        }
        public void draw()
        {
            _spriteBatch.Draw(endscreen, new Rectangle(0, 0, 1800, 1000), Color.White * 0.1f);


        }
    }
}
