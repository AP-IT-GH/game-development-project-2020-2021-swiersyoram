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
       
        private Movement charactermovement;

        private SpriteBatch _spriteBatch;

        private Vector2 positie;




        public NinjaGirl(SpriteBatch spritebatch, ContentManager content)
        {
            charactermovement = new Movement(content);
            _spriteBatch = spritebatch;
            positie = new Vector2(0, GameParameters.grond);
        }

        public void load()
        {
            charactermovement.loadAnimations();
        }

       

        public void update(GameTime gameTime, Vector2 richting, List<Rectangle> layout)
        {
            positie = charactermovement.move(richting,layout);
            charactermovement.updateAnimation(gameTime);
            
        }

        public void draw()
        {
           
            _spriteBatch.Draw(charactermovement.AnimationTexture, positie, charactermovement.AnimationFrame, Color.White, 0f, Vector2.Zero, 0.35f, charactermovement.Direction, 0f);
                  

        }
    }
}
