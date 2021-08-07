using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.collision
{
    class objectdetection
    {
        private Vector2 positie;
        private Dictionary<string, List<Rectangle>> layout;

        public Vector2 collision(Vector2 Positie, Dictionary<string, List<Rectangle>> Layout)
        {
            positie = Positie;
            layout = Layout;
            deurcollision();
            spikecollision();
            return positie;


        }

        private void deurcollision()
        {
            foreach (var deur in layout["door"])
            {
                if (positie.X > deur.X && positie.X < deur.X + deur.Width && positie.Y > deur.Y && positie.Y < deur.Y + deur.Height + 10)
                {
                    if (GameParameters.activelevel == level.one)
                    {
                        GameParameters.activelevel = level.two;
                        positie = new Vector2(50, GameParameters.grond);
                    }
                    else
                    {
                        GameParameters.gamestate = gameState.end;
                        positie = new Vector2(0, GameParameters.grond);

                    }
                }
            }
        } 
        private void spikecollision()
        {
            foreach (var spike in layout["spikes"])
            {
                if (positie.X > spike.X && positie.X < spike.X + spike.Width && positie.Y > spike.Y+50 && positie.Y < spike.Y + spike.Height + 10)
                {
                    GameParameters.gamestate = gameState.end;
                }
            }

        }

    }
}
