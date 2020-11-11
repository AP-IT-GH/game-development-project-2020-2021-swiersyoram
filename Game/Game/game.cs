using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace IronManGame
{
    public class game : Game
    {
        private GraphicsDeviceManager _graphics ;
        private SpriteBatch _spriteBatch;
        private Texture2D texture;
        private IronMan hero;
        public int windowHeight = 880;
        public int windowWidth = 1620;
        private float timelast;
        private float timenow;
        private float elapsedFrameTimeInSeconds;



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
           

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("ironman_sprites");

            InitializeGameObjects();
        
        }

        private void InitializeGameObjects()
        {
            hero = new IronMan(texture, GraphicsDevice) ;
            

        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

          
            hero.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();
            hero.Draw(_spriteBatch);
            _spriteBatch.End();
        

            base.Draw(gameTime);
        }
    }
}
