using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IronManGame.Animaties
{
    public class Animatie
    {
        public Rectangle currentframe { get; set; }
        private List<Rectangle> animatieFrames;
        private int counter = 0;
        private double frameMovement = 0;

        public Animatie()
        {
            animatieFrames = new List<Rectangle>();
        }

        public void addFrame(Rectangle rectangleFrame)
        {
            animatieFrames.Add(rectangleFrame);
        }

        public void Update(GameTime gameTime)
        {
            currentframe = animatieFrames[counter];
            frameMovement += currentframe.Width * gameTime.ElapsedGameTime.TotalSeconds;
            if(frameMovement >= currentframe.Width/10)
            {
                counter++;
                frameMovement = 0;
            }

            if(counter >= animatieFrames.Count)
            {
                counter = 0;
            }
        }

    }
}
