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

        public Animatie()
        {
            animatieFrames = new List<Rectangle>();
        }

        public void addFrame(Rectangle rectangleFrame)
        {
            animatieFrames.Add(rectangleFrame);
        }

        public void Update()
        {
            currentframe = animatieFrames[counter];
            counter++;
            if(counter == animatieFrames.Count)
            {
                counter = 0;
            }
        }

    }
}
