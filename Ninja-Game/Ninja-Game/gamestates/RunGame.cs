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

        private IGameCharacter ninjaGirl;
        private IKeyboardReader keyboard;
        private IMap maplayout;

        private double lasttime;
        private double delay = 1;


        public RunGame(SpriteBatch spritebatch, ContentManager content){
            maplayout = new Map(spritebatch, content);
            ninjaGirl = new NinjaGirl(spritebatch, content, maplayout);
            keyboard = new KeyboardReader();
        }
       
        public void load()
        {
            maplayout.Load();
            ninjaGirl.load();
        }

        

        public void update(GameTime gameTime)
        {

            maplayout.Update(gameTime);
            ninjaGirl.update(gameTime, keyboard.Inputreader());

            if(ninjaGirl.Dood == false)
            {
                lasttime = gameTime.TotalGameTime.TotalSeconds;    
            }

            if (gameTime.TotalGameTime.TotalSeconds > lasttime + delay && ninjaGirl.Dood == true)
            {
                GameParameters.gamestate = gameState.died;
            }
        }
        
        public void draw()
        {
            maplayout.Draw();
            ninjaGirl.draw();
        }


    }
}
