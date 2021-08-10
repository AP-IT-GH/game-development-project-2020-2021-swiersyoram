using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NinjaGame.characters.animation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.animation
{
    class Animation:IAnimation
    {
        public Texture2D Texture { get;  }


        private Rectangle frame;
        public Rectangle Frame { get { return frame; } }
        public Vector2 Origin { get;  }

        public float Scale { get; }

        private bool replay;
        private int width;
        private double speed;
        private double CurrentTime = 0;
        private double PreviousTime = 0;


        public Animation(Texture2D texture, double Speed, int frames, float scale, bool Replay)
        {
            
            Texture = texture;
            Scale = scale;
            Origin = new Vector2(texture.Width / frames / 2, texture.Height);
            width = texture.Width/ frames;
            speed = Speed;
            replay = Replay;
            frame = new Rectangle(0, 0, texture.Width/ frames, texture.Height);
        }
        public void update(GameTime gameTime)
        {
            CurrentTime = gameTime.TotalGameTime.TotalSeconds;
            if(CurrentTime > PreviousTime+ speed)
            {
                frame.X += width;
                if (frame.X > Texture.Width - width)
                {
                    if (replay)
                    {
                        frame.X = 0;

                    }
                    else
                    {
                        frame.X = Texture.Width - width;
                    }
                }
                PreviousTime = CurrentTime;
            }
        }
    }
}
