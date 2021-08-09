using Microsoft.Xna.Framework;
using NinjaGame.characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.collision
{
    class Objectdetection
    {
        
        private Dictionary<string, List<Rectangle>> layout;
        private IGameCharacter character;



        public Objectdetection(IGameCharacter Character)
        {
            character = Character;

        }

        public void collision( Dictionary<string, List<Rectangle>> Layout)
        {
            
            layout = Layout;
            deurcollision();
            spikecollision();
            


        }

        private void deurcollision()
        {
            foreach (var deur in layout["door"])
            {
                if (character.positie.X > deur.X && character.positie.X < deur.X + deur.Width && character.positie.Y > deur.Y && character.positie.Y < deur.Y + deur.Height + 10)
                {
                    if (GameParameters.activelevel == level.one)
                    {
                        GameParameters.activelevel = level.two;
                        character.positie = new Vector2(50, GameParameters.grond);
                    }
                    else
                    {
                        GameParameters.gamestate = gameState.end;
                        character.positie = new Vector2(0, GameParameters.grond);

                    }
                }
            }
        } 
        private void spikecollision()
        {
            foreach (var spike in layout["spikes"])
            {
                if (character.positie.X > spike.X && character.positie.X < spike.X + spike.Width && character.positie.Y > spike.Y+50 && character.positie.Y < spike.Y + spike.Height + 10)
                {
                    character.Dood = true;
                }
            }

        }

    }
}
