using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.characters.animation
{
    class DieAnimation : IAnimation
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

        private bool antimationend;

        public bool Animationend
        {
            get { return antimationend; }
            set { antimationend = value; }
        }

        public DieAnimation(int width, int height, int framewidth, double animationspeed)
        {
            spriteWidth = width;
            animationWidth = framewidth;
            AnimationSpeed = animationspeed;
            animationframe = new Rectangle(0, 0, (int)framewidth, (int)height);

        }

        public void update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
