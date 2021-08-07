using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NinjaGame.characters;
using NinjaGame.controller;
using NinjaGame.map;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.gamestates
{
    class RunGame : IGameState
    {

        private SpriteBatch _spriteBatch;
      

        private IGameCharacter ninjaGirl;

        private IInputReader keyboard;
        private IMap maplayout;


        public RunGame(SpriteBatch spritebatch, ContentManager content){
            _spriteBatch = spritebatch;
            ninjaGirl = new NinjaGirl(spritebatch, content);
            keyboard = new KeyboardReader();
            maplayout = new Map(spritebatch, content);
            
            
        }
       
        public void load()
        {
            maplayout.load();
            ninjaGirl.load();
        }

        

        public void update(GameTime gameTime)
        {
            maplayout.Activelevel();
            ninjaGirl.update(gameTime, keyboard.Inputreader(), maplayout.layout());

        }

        public void draw()
        {
            _spriteBatch.Begin();
            maplayout.Draw();
            ninjaGirl.draw();
            _spriteBatch.End();
        }

    }
}
