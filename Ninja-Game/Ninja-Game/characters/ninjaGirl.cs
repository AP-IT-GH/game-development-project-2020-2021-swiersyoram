using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.characters
{
    class ninjaGirl:IGameCharacter
    {
        private SpriteBatch _spriteBatch;
        private ContentManager Content;
        private Texture2D _ninjaGirl;
        private Rectangle animationWindow;
        private int counter = 0;
        

        public ninjaGirl(SpriteBatch spritebatch, ContentManager content)
        {
            _spriteBatch = spritebatch;
            Content = content;
            animationWindow =  new Rectangle(0, 0, 282, 390);
        }

        public void load()
        {
            _ninjaGirl = Content.Load<Texture2D>("girl-running");

        }

        public void update()
        {
            counter++;
                if(counter > 50)
            {
                animationWindow.X += 282;
                if (animationWindow.X > 2820-282)
                {
                    animationWindow.X = 0;
                }
                GameParameters.gamestate = gameState.end;
                counter = 0;
            }
            

        }

        public void draw()
        {
            _spriteBatch.Draw(_ninjaGirl, new Vector2(0, (float)(GameParameters.windowHeight-GameParameters.girlScaledHeight-50)), animationWindow,Color.White, 0f,Vector2.Zero, 0.35f, SpriteEffects.None, 0f);
        }
    }
}
