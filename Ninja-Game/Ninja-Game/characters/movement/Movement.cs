using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.characters.movement
{
    class Movement
    {
        
        private SpriteEffects direction;
        public SpriteEffects Direction
        {
            get { return direction; }
        }

        private Vector2 positie;    

        public Vector2 Positie
        {
            get { return positie; }
        }


        private Vector2 snelheid;
        public Vector2 Snelheid
        {
            get { return positie; }
        }

        private characterState state;

        public characterState State
        {
            get { return state; }
        }
        private int maxsnelheid;
        private float snelheidstap = 0.5f;
        public Movement(int Maxsnelheid)
        {
            positie = new Vector2(0, (float)(GameParameters.windowHeight - GameParameters.girlScaledHeight - 50));
            state = characterState.idle;
            maxsnelheid = Maxsnelheid;
        }

     
        public void move(Vector2 richting)
        {
            if(richting.X==1||richting.X == -1)
            {
                if (richting.X == 1)
                {
                    direction = SpriteEffects.None;
                    if(snelheid.X < maxsnelheid)
                    {
                        snelheid.X+= snelheidstap;
                    }
                }
               else
                {
                    direction = SpriteEffects.FlipHorizontally;
                    if (snelheid.X > -maxsnelheid)
                    {
                        snelheid.X -= snelheidstap;
                    }
                }

            }
            else
            {
                snelheid = new Vector2(0, 0);
            }
            positie += snelheid;
        }


        public void movestate()
        {
            if (snelheid.X == 0)
            {
                state = characterState.idle;
            }
            else
            {
                state = characterState.running;
            }
        }

        
    }
}
