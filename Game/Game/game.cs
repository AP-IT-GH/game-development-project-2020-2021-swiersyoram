using IronManGame.Game_interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace IronManGame
{
    public class game : Game
    {
        private GraphicsDeviceManager _graphics ;
        private SpriteBatch _spriteBatch;
        private Texture2D texture;
        private Gamecharacter_hero hero;
        public int windowHeight = 880;
        public int windowWidth = 1620;
        private float timelast;
        private float timenow;
        private float elapsedFrameTimeInSeconds;

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
            IsMouseVisible = true; 

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("ironman_sprites");

            var startBtn = new Button(Content.Load<Texture2D>("btn"), Content.Load<SpriteFont>("File"))
            {
                position = new Vector2(350, 200),
                Text = "start"
            };
            startBtn.Click += StartBtn_Click;
            var quitBtn = new Button(Content.Load<Texture2D>("btn"), Content.Load<SpriteFont>("File"))
            {
                position = new Vector2(350, 250),
                Text = "quit"
            };
            quitBtn.Click += QuitBtn_Click;

            _gameComponents = new List<Button>()
            {
                startBtn,
                quitBtn,
            };

            InitializeGameObjects();
        
        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("start");
        }

        private void InitializeGameObjects()
        {
            hero = new Gamecharacter_hero(texture, GraphicsDevice) ;
            

        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var component in _gameComponents)
                component.Update(gameTime);

            hero.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();
            foreach (var component in _gameComponents)
                component.Draw(gameTime, _spriteBatch);
            hero.Draw(_spriteBatch);
            _spriteBatch.End();

            

            base.Draw(gameTime);
        }
    }
}
