using IronManGame.Game_interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using IronManGame.Menu;




namespace IronManGame
{
    class StartMenu : Interfaces.Component
    {
        //textures
        private Texture2D _startscreenBackground;
        private Texture2D _rain;
        private Rectangle startButtonPosition = new Rectangle(700, 550, 300, 120);
        private Rectangle quitButtonPosition = new Rectangle(1100, 550, 300, 120);
        private Button _startButton;
        private Button _quitButton;
        private Rain
       


        public StartMenu(Texture2D startscreenBackground,Texture2D startbutton, Texture2D quitbutton, Texture2D rain)
        {
            
            _startscreenBackground = startscreenBackground;
            _rain = rain;

            //buttons
            _startButton = new Button(startbutton, startButtonPosition, "game");
            _quitButton = new Button(quitbutton, quitButtonPosition,"exit");
            //Rain
            

        }
       
        public override void Update(GameTime gameTime)
        {
            _startButton.Update(gameTime);
            _quitButton.Update(gameTime);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_startscreenBackground, new Rectangle(0, 0, game.windowWidth, game.windowHeight), Color.White);
            _startButton.Draw(gameTime, spriteBatch);
            _quitButton.Draw(gameTime, spriteBatch);
        }
    }
}
