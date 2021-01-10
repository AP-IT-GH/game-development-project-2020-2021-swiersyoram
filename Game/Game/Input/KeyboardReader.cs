using IronManGame.Animaties;
using IronManGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace IronManGame.Input
{
    class KeyboardReader : IKeyboard
    {
        private int ground;
        public string keuzeAnimatie;
        public Vector2 direction;
        public Vector2 positie;
        public Vector2 velocity = new Vector2(0,0);
        private bool hasjumped = false;
        private bool jumpkey = false;
        public KeyboardReader(int groundY)
        {
            ground = groundY;
            positie = new Vector2(0, ground);
            direction = new Vector2(0, 0);
        }

        public void readInput()
        {
            
            
            KeyboardState state = Keyboard.GetState();
            positie += velocity;
            if (state.IsKeyDown(Keys.Right))
            {
                positie.X += 10;
                keuzeAnimatie = "runAnimatie";
                direction.X = 1;
            }

            if (state.IsKeyDown(Keys.Left))
            {
                positie.X -= 10;
                keuzeAnimatie = "runAnimatie";
                direction.X = -1;
            }

           if (state.IsKeyDown(Keys.Up) && jumpkey==false)
            {

                positie.Y -= 80f;
                velocity.Y = -5f;
                hasjumped = true;
                jumpkey = true;
            }
            if (state.IsKeyUp(Keys.Up))
            {
                jumpkey = false;
            }

                if (hasjumped == true)
            {
                
                velocity.Y += 0.3f ;

            }

            if (hasjumped == false)
            {
                velocity.Y = 0f;
            }
            if (positie.Y >= ground)
            {
                hasjumped = false;
                positie.Y = ground;
            }


            if (state.GetPressedKeys() == null || state.GetPressedKeys().Length == 0)
            {
                keuzeAnimatie = "standingAnimatie";
            }

            
        }
    }
}
