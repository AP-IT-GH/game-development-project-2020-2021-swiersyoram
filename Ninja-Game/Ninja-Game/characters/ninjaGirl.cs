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

        public Vector2 positie { get; set; }

        public bool Dood { get; set; }

        public Animation Activeanimation { get; set; }





        public NinjaGirl(SpriteBatch spritebatch, ContentManager content)
        {
            positie = new Vector2(50, GameParameters.grond);
            charactermovement = new Movement(content,this);
            _spriteBatch = spritebatch;
        }

        public void load()
        {
            charactermovement.loadAnimations();
        }

       

        public void update(GameTime gameTime, Vector2 richting, Dictionary<string, List<Rectangle>> layout)
        {
            if(this.Dood == false)
            {
                charactermovement.move(richting, layout);

            }
            charactermovement.updateAnimation(gameTime);
            
        }

        public void draw()
        {
           _spriteBatch.Draw(Activeanimation.Texture, positie, Activeanimation.Frame, Color.White, 0f, Activeanimation.Origin, Activeanimation.Scale, charactermovement.Direction, 0f);
        }
    }
}
