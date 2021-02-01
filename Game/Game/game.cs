using IronManGame.Game_interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using IronManGame.Interfaces;
using IronManGame.Map;
using IronManGame.Characters;


namespace IronManGame
{
     public class game : Game
    {
        private GraphicsDeviceManager _graphics ;
        private SpriteBatch _spriteBatch;

        //textures
        //character textures
        private Texture2D _ironmanSprite;
        private Texture2D _enemySprite;
        //background textures
        private Texture2D _startscreenBackground;
        private Texture2D _levelBackground;
        private Texture2D _roadBackground;
        private Texture2D _platformBackground;
        private Texture2D _portalBackground;

        //button textures
        private Texture2D _startBtn;
        private Texture2D _quitBtn;
        //extras
        private Texture2D _mouseSprite;
        private Texture2D _rain;

        //characters
        private Gamecharacter_hero hero;
        private Gamecharacter_enemy enemy;

        //menu
        private StartMenu _startMenu;
        //level
        private Level _levelOne;

        //parameters
        public static int ground;
        public static Vector2 heroStartPos;
        public static int windowHeight = 800;
        public static int windowWidth = 1600;
        public static string _gameState = "game";
        private MouseState _mouse;
       




        public game()
        {
            _graphics = new GraphicsDeviceManager(this);
            ground = windowHeight - 50;
            heroStartPos = new Vector2(50, ground);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = windowWidth;  
            _graphics.PreferredBackBufferHeight = windowHeight;
            _graphics.ApplyChanges();
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = false; 

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
          
            //loading textures
            //characters
            _ironmanSprite = Content.Load<Texture2D>("ironman_sprites");
            _enemySprite = Content.Load<Texture2D>("enemySprites");

            //background and environment
            _startscreenBackground = Content.Load<Texture2D>("startscreen_background");
            _levelBackground = Content.Load<Texture2D>("gamebackground");
            _roadBackground = Content.Load<Texture2D>("floor");
            _platformBackground = Content.Load<Texture2D>("platform");
            _portalBackground = Content.Load<Texture2D>("portal");


            //extras
            _startBtn = Content.Load<Texture2D>("startbutton");
            _quitBtn = Content.Load<Texture2D>("quitbutton");
            _mouseSprite = Content.Load<Texture2D>("cursorSprite");
            _rain = Content.Load<Texture2D>("raindrop");

           

            InitializeGameObjects();
        
        }

        private void InitializeGameObjects()
        {
            //menu
            _startMenu = new StartMenu(_startscreenBackground, _startBtn,_quitBtn, _rain);
            //level
            _levelOne = new Level(_levelBackground, _roadBackground, _platformBackground, _portalBackground);
            //characters
            hero = new Gamecharacter_hero(_ironmanSprite, GraphicsDevice) ;
            enemy = new Gamecharacter_enemy(_enemySprite, GraphicsDevice);
           
            
           

        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                _gameState ="start" ;

           
            _mouse = Mouse.GetState();

            switch (_gameState)
            {
                case "start":
                    {

                        _startMenu.Update(gameTime);
                        
                        hero.resetPosition();
                       
                        break;
                    }
                case "game":
                    {
                        _levelOne.Update(gameTime);
                        hero.Update(gameTime);
                        enemy.Update(gameTime);

                        break; 
                    }
                case "exit":
                    {
                        break;
                    }
                default:
                    break;
            }
           

           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();
            
            switch (_gameState)
            {
                case "start":
                    {

                        _startMenu.Draw(gameTime, _spriteBatch);
                        _spriteBatch.Draw(_mouseSprite, new Vector2(_mouse.Position.X, _mouse.Position.Y), Color.White);
                        break;
                    }
                case "game":
                    {
                        _levelOne.Draw(_spriteBatch);
                        hero.Draw(_spriteBatch);
                        enemy.Draw(_spriteBatch);
                        break;
                    }

                case "exit":
                    {
                        Exit();
                        break; 
                    }
                default:
                    break;
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
