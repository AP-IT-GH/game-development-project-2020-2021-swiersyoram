using IronManGame.Game_interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using IronManGame.Interfaces;


namespace IronManGame
{
     public class game : Game
    {
        private GraphicsDeviceManager _graphics ;
        private SpriteBatch _spriteBatch;
        //textures
        Texture2D _ironmanSprite;
        private Texture2D _startscreenBackground;
        private Texture2D _startBtn;
        private Texture2D _quitBtn;
        private Texture2D _mouseSprite;
        private Texture2D _rain;
        private Rectangle startButton; 


       

        //characters
        private Gamecharacter_hero hero;
        //menu
        private StartMenu _startMenu;



        public static int windowHeight = 800;
        public static int windowWidth = 1600;
        public static string _gameState = "start";
        private MouseState _mouse;
       




        public game()
        {
            _graphics = new GraphicsDeviceManager(this);
            
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
            _ironmanSprite = Content.Load<Texture2D>("ironman_sprites");
            _startscreenBackground = Content.Load<Texture2D>("startscreen_background");
            _startBtn = Content.Load<Texture2D>("startbutton");
            _quitBtn = Content.Load<Texture2D>("quitbutton");
            _mouseSprite = Content.Load<Texture2D>("cursorSprite");
            startButton = new Rectangle(700, 550, 300, 120);
            _rain = Content.Load<Texture2D>("raindrop");

           

            InitializeGameObjects();
        
        }

        private void InitializeGameObjects()
        {
            //menu
            _startMenu = new StartMenu(_startscreenBackground, _startBtn,_quitBtn, _rain);

            //characters
            hero = new Gamecharacter_hero(_ironmanSprite, GraphicsDevice) ;

            
           

        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                _gameState ="start" ;

            hero.Update(gameTime);
            _mouse = Mouse.GetState();
            switch (_gameState)
            {
                case "start":
                    {
                        
                        _startMenu.Update(gameTime);
                        break;
                    }
                case "game":
                    {
                        
                        hero.Update(gameTime);
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
                        hero.Draw(_spriteBatch);
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
