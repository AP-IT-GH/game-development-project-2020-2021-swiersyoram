using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NinjaGame.characters;
using NinjaGame.controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.gamestates
{
    class RunGame : IGameState
    {

        private SpriteBatch _spriteBatch;
        private ContentManager Content;
        private Texture2D _gameBackground;
        private IGameCharacter ninjaGirl;

        private KeyboardReader keyboard;


        public RunGame(SpriteBatch spritebatch, ContentManager content){
            _spriteBatch = spritebatch;
            Content = content;
            ninjaGirl = new NinjaGirl(spritebatch, content);
            keyboard = new KeyboardReader();
            
        }
       
        public void load()
        {
            _gameBackground = Content.Load<Texture2D>("background");
            ninjaGirl.load();
        }

        

        public void update(GameTime gameTime)
        {
            ninjaGirl.update(gameTime,keyboard.move());

        }

        public void draw()
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_gameBackground, new Rectangle(0, 0, GameParameters.windowWidth, GameParameters.windowHeight), Color.White);
            ninjaGirl.draw();
            _spriteBatch.End();
        }

    }
}
