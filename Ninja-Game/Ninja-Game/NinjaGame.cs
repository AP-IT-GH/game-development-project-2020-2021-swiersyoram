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
        private IGameState startGame;
        private IGameState runGame;
        private IGameState characterDied;
        private IGameState endGame;

        public NinjaGame()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            BuildGame.build(_graphics, GameParameters.windowWidth, GameParameters.windowHeight);
            startGame = new Start(_spriteBatch, this.Content,this);
            runGame = new RunGame(_spriteBatch, this.Content);
            characterDied = new CharacterDied(_spriteBatch, this.Content);
            endGame = new EndGame(_spriteBatch, this.Content, this);



            base.Initialize();
        }

        protected override void LoadContent()
        {
            startGame.load();
            runGame.load();
            characterDied.load();
            endGame.load();

        }

        protected override void Update(GameTime gameTime)
        {
            switch (GameParameters.gamestate)
            {
                case gameState.start:
                    startGame.update(gameTime);
                    break;
                case gameState.running:
                    runGame.update(gameTime);
                    break;
                case gameState.died:
                    characterDied.update(gameTime);
                    break;
                case gameState.pause:
                    break;
                case gameState.restart:
                    runGame = new RunGame(_spriteBatch, this.Content);
                    runGame.load();
                    GameParameters.activelevel = level.one;
                    GameParameters.gamestate = gameState.running;

                    break;
                case gameState.end:
                    endGame.update(gameTime);
                    break;

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            switch (GameParameters.gamestate)
            {
                case gameState.start:
                    startGame.draw();
                    break;
                case gameState.running:
                    runGame.draw();
                    break;
                case gameState.died:
                    characterDied.draw();
                    break;
                case gameState.pause:
                    break;
                case gameState.end:
                    endGame.draw();
                    break;
                
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
