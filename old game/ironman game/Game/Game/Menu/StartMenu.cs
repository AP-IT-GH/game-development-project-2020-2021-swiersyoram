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
        private Button StartButton;
        private Button QuitButton;
        private Rain[] Rain =  new Rain[10];



        public StartMenu(Texture2D startscreenBackground, Texture2D startbutton, Texture2D quitbutton, Texture2D rain)
        {

            _startscreenBackground = startscreenBackground;
            _rain = rain;

            //buttons
            StartButton = new Button(startbutton, startButtonPosition, "game");
            QuitButton = new Button(quitbutton, quitButtonPosition, "exit");
            //Rain
            for (int i = 0; i < Rain.Length; i++)
            {
                Rain[i] = new Rain(_rain);
            }
            

        }

        public override void Update(GameTime gameTime)
        {
            StartButton.Update(gameTime);
            QuitButton.Update(gameTime);
            foreach (var rain in Rain)
            {
                rain.Update(gameTime);
            }
           
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_startscreenBackground, new Rectangle(0, 0, game.windowWidth, game.windowHeight), Color.White);
            foreach (var rain in Rain)
            {
                rain.Draw(gameTime, spriteBatch);
            }
            StartButton.Draw(gameTime, spriteBatch);
            QuitButton.Draw(gameTime, spriteBatch);
        }
    }
}
