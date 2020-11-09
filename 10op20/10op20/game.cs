using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace _10op20
{
    public class game : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D texture;
        private Rectangle heroViewRectangle;
        private int[] heroX = {160,320,480,320};
        private int heroRunningCounter = 0;
        private int counter = 0;

        public game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1620;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 880;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            heroViewRectangle = new Rectangle(heroX[0], 0, 160,160);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("sprites");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin();
            _spriteBatch.Draw(texture, new Vector2(10, 400), heroViewRectangle, Color.White);
            _spriteBatch.End();
            counter++;
            if (counter == 10)
            {
                counter = 0;
                if(heroRunningCounter>3)
                {
                    heroRunningCounter = 0;
                }
                heroViewRectangle.X = heroX[heroRunningCounter];
                heroRunningCounter++;
            }
            
                
            
            
           

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
