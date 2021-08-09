using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using NinjaGame.gamestates.startmenu;
using NinjaGame.controller;

namespace NinjaGame.gamestates
{
    class Start : IGameState
    {
        private SpriteBatch _spriteBatch;
        private ContentManager Content;
        private Texture2D startscreen;

        private Button startbutton;
        private Button endbutton;

        private IMouseReader mouse;
        private Game game;



        public Start(SpriteBatch spritebatch, ContentManager content,Game Game)
        {
            _spriteBatch = spritebatch;
            Content = content;
            game = Game;
            startbutton = new Button(content.Load<Texture2D>("beginbutton"),new Vector2(600,600));
            endbutton = new Button(content.Load<Texture2D>("endbutton"), new Vector2(1100, 600));
            mouse = new MouseReader();


        }

        public void load()
        {
            startscreen = Content.Load<Texture2D>("begin");

        }

        public void update(GameTime gameTime)
        {
            MouseState input = mouse.Inputreader();
            if (endbutton.update(input))
            {
                game.Exit();   
            }
            if (startbutton.update(input))
            {
                GameParameters.gamestate = gameState.running;
            }

        }
        public void draw()
        {
            _spriteBatch.Draw(startscreen, new Rectangle(0, 0, 1800, 1000), Color.White * 0.1f);
            _spriteBatch.Draw(startbutton.Texture, startbutton.Positie,Color.White);
            _spriteBatch.Draw(endbutton.Texture, endbutton.Positie, Color.White);

        }
    }
}
