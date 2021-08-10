using Microsoft.Xna.Framework;
using NinjaGame.characters;
using NinjaGame.map;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.collision
{
    class Objectdetection
    {
        
        private IMap layout;
        private IGameCharacter character;



        public Objectdetection(IGameCharacter Character, IMap Layout)
        {
            layout = Layout;

            character = Character;

        }

        public void collision()
        {
            
            deurcollision();
            spikecollision();
            coincollision();


        }

        private void deurcollision()
        {
            Rectangle deur = layout.ActiveLevel.Deur;
            if (character.positie.X > deur.X && character.positie.X < deur.X + deur.Width && character.positie.Y > deur.Y && character.positie.Y < deur.Y + deur.Height + 10 && layout.ActiveLevel.Coins.Count == 0)
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
        private void spikecollision()
        {
            foreach (var spike in layout.ActiveLevel.Spikes)
            {
                if (character.positie.X > spike.X && character.positie.X < spike.X + spike.Width && character.positie.Y > spike.Y+50 && character.positie.Y < spike.Y + spike.Height + 10)
                {
                    character.Dood = true;
                }
            }
            foreach (var spike in layout.ActiveLevel.Rotatedspikes)
            {
                if (character.positie.X > spike.X && character.positie.X < spike.X + spike.Width && character.positie.Y > spike.Y + 50 && character.positie.Y < spike.Y + spike.Height + 10)
                {
                    character.Dood = true;
                }
            }

        }
        private void coincollision()
        {
            List<Vector2> coins = layout.ActiveLevel.Coins;
                for (int i = 0; i < coins.Count; i++)
                {
                if (character.positie.X > coins[i].X && character.positie.X < coins[i].X + 50 && character.positie.Y > coins[i].Y && character.positie.Y < coins[i].Y + 70)
                {
                    layout.ActiveLevel.Coins.RemoveAt(i);
                }
                
            }
                
            
            

        }

    }
}
