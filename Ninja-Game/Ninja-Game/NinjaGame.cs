using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NinjaGame.gamestates;
using System.Diagnostics;

namespace NinjaGame
{
    public class NinjaGame : Game
    {
        

        //sprites
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //gamestates
        private IGameState runGame;


        


        public NinjaGame()
        {
            Content.RootDirectory = "Content";
            _graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            BuildGame.build(_graphics, GameParameters.windowWidth, GameParameters.windowHeight);
            runGame = new RunGame(_spriteBatch, this.Content);
            base.Initialize();
        }

        protected override void LoadContent()
        {
           
            runGame.load();
        }

        protected override void Update(GameTime gameTime)
        {
            switch (GameParameters.gamestate)
            {
                case gameState.start:

                    break;
                case gameState.running:
                    runGame.update(gameTime);
                    break;
                case gameState.pause:
                    break;
                case gameState.end:
                    break;

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            switch (GameParameters.gamestate)
            {
                case gameState.start:

                    break;
                case gameState.running:
                    runGame.draw();
                    break;
                case gameState.pause:
                    break;
                case gameState.end:
                    break;
                
            }
            base.Draw(gameTime);
        }
    }
}
