using IronManGame.Animaties;
using IronManGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using IronManGame.Map;

namespace IronManGame.Input
{
    class KeyboardReader 
    {
        private int ground;
        public string keuzeAnimatie;
        public Vector2 direction;
        public Vector2 positie;
        public Vector2 velocity = new Vector2(0,0);
        private bool hasjumped = false;
        private bool jumpkey = false;
        private List<bool> onplatform;
        private int doublejump = 0;
        private List<Rectangle> layout;
        public KeyboardReader(int groundY, List<Rectangle> platforms)
        {
            ground = groundY;
            positie = game.heroStartPos;
            direction = new Vector2(0, 0);
            layout = platforms;
            onplatform = new List<bool>();
            foreach (var platform in layout)
            {
                onplatform.Add(false);
            }
        }

        public void readInput(List<Rectangle> _platforms)
        {
            layout = _platforms;

            KeyboardState state = Keyboard.GetState();
            positie += velocity;
            if (state.IsKeyDown(Keys.Right))
            {
                positie.X += 5;
                keuzeAnimatie = "runAnimatie";
                direction.X = 1;
            }

            if (state.IsKeyDown(Keys.Left))
            {
                positie.X -= 5;
                keuzeAnimatie = "runAnimatie";
                direction.X = -1;
            }

            if (state.IsKeyDown(Keys.Up) && jumpkey == false && doublejump < 2)
            {

                positie.Y -= 10f;
                velocity.Y = -16f;
                hasjumped = true;
                jumpkey = true;
                doublejump++;
            }
            if (state.IsKeyUp(Keys.Up))
            {
                jumpkey = false;
            }

                if (hasjumped == true)
            {
                velocity.Y += 0.8f ;

            }

            if (hasjumped == false)
            {
                velocity.Y = 0f;
            }

            int i = 0;
            foreach (var platforms in layout)
            {
               
                
                if (positie.Y <= platforms.Y && positie.X > platforms.X && positie.X < platforms.X+platforms.Width)
                {
                   
                    onplatform[i] = true;

                }
                if (onplatform[i] == true && positie.Y >= platforms.Y)
                {
                    if (positie.X > platforms.X && positie.X < platforms.X + platforms.Width)
                    {
                        positie.Y = platforms.Y;
                        hasjumped = false;
                        doublejump = 0;

                    }
                    else
                    {
                        onplatform[i] = false;
                        hasjumped = true;
                    }

                }
                i++;
            }
          

            if (positie.X > Map.Layout.portalposition.X 
                && positie.X < Map.Layout.portalposition.X+50
               && positie.Y > Map.Layout.portalposition.Y - 120
               && positie.Y <= Map.Layout.portalposition.Y 
               )
            {
                game.level++;
                if (game.level > 2)
                {
                    game._gameState = "exit";
                }
                else
                {
                    game._gameState = "start";
                }
                
            }
            



            
            if (positie.Y >= ground)
            {

                    hasjumped = false;
                    positie.Y = ground;
                    doublejump = 0;

            }


            if (state.GetPressedKeys() == null || state.GetPressedKeys().Length == 0)
            {
                keuzeAnimatie = "standingAnimatie";
            }

            
        }

        public void setposition(Vector2 _positie)
        {
            positie = _positie;
            

        }
    }
}
