using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.animation
{
    class Animation
    {
        
        private int animationWidth;
        private int spriteWidth;
        private Rectangle animationframe;
        private double AnimationSpeed;
        private double CurrentTime = 0;
        private double PreviousTime = 0;
        public Rectangle Frame
        {
            get { return animationframe; }
        }

        public Animation(int width, int height, int framewidth, double animationspeed)
        {

            spriteWidth = width;
            animationWidth = framewidth;
            AnimationSpeed = animationspeed;
            animationframe = new Rectangle(0, 0, (int)framewidth, (int)height);
        }
        public void update(GameTime gameTime)
        {
            CurrentTime = gameTime.TotalGameTime.TotalSeconds;
            if(CurrentTime > PreviousTime+ AnimationSpeed )
            {
                animationframe.X += animationWidth;
                if (animationframe.X > spriteWidth - animationWidth)
                {
                    animationframe.X = 0;
                }
                PreviousTime = CurrentTime;

            }

            

        }
    }
}
