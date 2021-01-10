using IronManGame.Game_interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

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
        private Rectangle startButton; 


        private MouseState _mouse;


        private Gamecharacter_hero hero;
        private const int windowHeight = 800;
        private const int windowWidth = 1600;
        private float timelast;
        private float timenow;
        private float elapsedFrameTimeInSeconds;
        private string _gameState = "start";


        private List<Button> _gameComponents;




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
            _ironmanSprite = Content.Load<Texture2D>("ironman_sprites");
            _startscreenBackground = Content.Load<Texture2D>("startscreen_background");
            _startBtn = Content.Load<Texture2D>("startbutton");
            _quitBtn = Content.Load<Texture2D>("quitbutton");
            _mouseSprite = Content.Load<Texture2D>("cursorSprite");
            startButton = new Rectangle(700, 550, 300, 120);

           

            InitializeGameObjects();
        
        }

        private void InitializeGameObjects()
        {
            hero = new Gamecharacter_hero(_ironmanSprite, GraphicsDevice) ;
           

        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                _gameState ="start" ;

            hero.Update(gameTime);
            switch (_gameState)
            {
                case "start":
                    {
                        _mouse = Mouse.GetState();

                        if(_mouse.Position.X >= 700 
                            && _mouse.Position.X <= 1000
                            && _mouse.Position.Y >= 550 
                            && _mouse.Position.Y<= 770)
                        {
                            startButton.Width = 320;
                            startButton.Height = 140;

                            if (_mouse.LeftButton == ButtonState.Pressed)
                            {
                                Debug.WriteLine(_mouse.Position);
                                _gameState = "game";
                            }
                        }
                        else
                        {
                            startButton.Width = 300;
                            startButton.Height = 120;
                        }
                        

                        break;
                    }
                case "game":
                    {
                        
                        hero.Update(gameTime);
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

                        _spriteBatch.Draw(_startscreenBackground, new Rectangle(0, 0, windowWidth, windowHeight), Color.White);
                        _spriteBatch.Draw(_startBtn, startButton, Color.White);
                        _spriteBatch.Draw(_quitBtn, new Rectangle(1100, 550, 300, 120), Color.White);
                        _spriteBatch.Draw(_mouseSprite, new Vector2(_mouse.Position.X, _mouse.Position.Y), Color.White);

                        
                        break;
                    }
                case "game":
                    {
                        hero.Draw(_spriteBatch);
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
