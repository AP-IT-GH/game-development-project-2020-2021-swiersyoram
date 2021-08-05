using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NinjaGame.animation;
using NinjaGame.characters.movement;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.characters
{
    class NinjaGirl:IGameCharacter
    {
        private SpriteBatch _spriteBatch;
        private ContentManager Content;
        private Texture2D _runningGirl;
        private Texture2D _idleGirl;

        private Animation runningAnimation;
        private Animation idleAnimation;
        private Movement charactermovement;
      




        

        public NinjaGirl(SpriteBatch spritebatch, ContentManager content)
        {
            _spriteBatch = spritebatch;
            Content = content;

            charactermovement = new Movement(10);
            runningAnimation = new Animation(GameParameters.girlSpriteWidth, GameParameters.girlSpriteHeight, GameParameters.girlWidth,0.03);
            idleAnimation = new Animation(2180, 375, 218, 0.1);

        }

        public void load()
        {
            _runningGirl = Content.Load<Texture2D>("girl-running");
            _idleGirl = Content.Load<Texture2D>("girl-idle");
        }

       

        public void update(GameTime gameTime, Vector2 richting)
        {
            charactermovement.move(richting);
            charactermovement.movestate();
            switch (charactermovement.State)
            {
                case characterState.idle:
                    idleAnimation.update(gameTime);
                    break;
                case characterState.running:
                    runningAnimation.update(gameTime);
                    break;
                default:
                    break;
            }
        }

        public void draw()
        {
            switch (charactermovement.State)
            {
                case characterState.idle:
                    _spriteBatch.Draw(_idleGirl, charactermovement.Positie, idleAnimation.Frame, Color.White, 0f, Vector2.Zero, 0.35f, charactermovement.Direction, 0f);
                    break;
                case characterState.running:
                    _spriteBatch.Draw(_runningGirl, charactermovement.Positie, runningAnimation.Frame, Color.White, 0f, Vector2.Zero, 0.35f, charactermovement.Direction, 0f);
                    break;
                default:
                    break;
            }

        }
    }
}
