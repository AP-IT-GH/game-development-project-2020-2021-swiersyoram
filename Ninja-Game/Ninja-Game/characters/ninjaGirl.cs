using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NinjaGame.animation;
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
        private characterState characterstate = characterState.running;

        private Vector2 positie;
        private Vector2 snelheid;
        private Vector2 versnelling;




        

        public NinjaGirl(SpriteBatch spritebatch, ContentManager content)
        {
            _spriteBatch = spritebatch;
            Content = content;
           
            runningAnimation = new Animation(GameParameters.girlSpriteWidth, GameParameters.girlSpriteHeight, GameParameters.girlWidth,0.03);
            idleAnimation = new Animation(2180, 375, 218, 0.05);
            positie = new Vector2(0, (float)(GameParameters.windowHeight - GameParameters.girlScaledHeight - 50));
            snelheid = new Vector2(5, 0);



        }

        public void load()
        {
            _runningGirl = Content.Load<Texture2D>("girl-running");
            _idleGirl = Content.Load<Texture2D>("girl-idle");
        }

        private void move()
        {
            positie += snelheid;
            if(snelheid.X == 0)
            {
                characterstate = characterState.idle;
            }
            else
            {
                characterstate = characterState.running;
            }

        }

        public void update(GameTime gameTime, Vector2 newspeed)
        {
            snelheid = newspeed;
            move();
            switch (characterstate)
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
            switch (characterstate)
            {
                case characterState.idle:
                    _spriteBatch.Draw(_idleGirl, positie, idleAnimation.Frame, Color.White, 0f, Vector2.Zero, 0.35f, SpriteEffects.None, 0f);
                    break;
                case characterState.running:
                    _spriteBatch.Draw(_runningGirl, positie, runningAnimation.Frame, Color.White, 0f, Vector2.Zero, 0.35f, SpriteEffects.None, 0f);
                    break;
                default:
                    break;
            }

        }
    }
}
