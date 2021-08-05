using IronManGame.Animaties;
using IronManGame.Input;
using IronManGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using IronManGame.Animaties;

namespace IronManGame.Characters
{
    class Gamecharacter_enemy : IGameObject
    {
        Gamecharacter_enemy enemy;
        Texture2D charactertexture;
        Animatie runAnimatie;
       
        private Animatie gekozenAnimatie;
        private int ground;
        private SpriteEffects spriterichting;
        private Vector2 positie = new Vector2(600,game.ground);
        private SpriteEffects richting;
        private KeyboardReader input;
        






        public Gamecharacter_enemy(Texture2D texture, GraphicsDevice graphics)
        {
            charactertexture = texture;
            richting = SpriteEffects.None;

            //animatieframes bepalen 
            //lopen
            runAnimatie = new Animatie();
            runAnimatie.addFrame(new Rectangle(0, 0, 55, 67));
            runAnimatie.addFrame(new Rectangle(55, 0, 55, 67));
            runAnimatie.addFrame(new Rectangle(110, 0, 55, 67));
            runAnimatie.addFrame(new Rectangle(165, 0, 55, 67));
            runAnimatie.addFrame(new Rectangle(220, 0, 55, 67));
            runAnimatie.addFrame(new Rectangle(275, 0, 55, 67));
            runAnimatie.addFrame(new Rectangle(330, 0, 55, 67));
            runAnimatie.addFrame(new Rectangle(385, 0, 55, 67));
            

            //spriterichting = new SpriteEffects();

            //ground = graphics.Viewport.Height - 100;

            //input = new KeyboardReader(ground);



        }

        public void Update(GameTime gameTime)
        {
            /* input.readInput();


             positie = input.positie;

             if (input.keuzeAnimatie == "runAnimatie")
                 gekozenAnimatie = runAnimatie;
             if (input.keuzeAnimatie == "standingAnimatie")
                 gekozenAnimatie = standingAnimatie;

             
             if (input.direction.X == -1)
                 spriterichting = SpriteEffects.FlipHorizontally;*/
            //input.readInput();
            //if (input.direction.X == 1)
            //{
            //    frame++;
            //    if (frame > 7)
            //    {
            //        frame = 0;
            //    }
            //    Console.WriteLine("werkt") ;
            //}
            
            if(positie.X >= (game.windowWidth-55))
            {
                richting = SpriteEffects.FlipHorizontally;
                positie.X -= 2;
            }
            if(positie.X < 500)
            {
                richting = SpriteEffects.None;
                positie.X += 2;
            }
            if (richting == 0)
            {
                positie.X += 2;

            }
            else positie.X -= 2;
            runAnimatie.Update(gameTime);


        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            //_spriteBatch.Draw(charactertexture, positie, gekozenAnimatie.currentframe, Color.White, 0f, Vector2.Zero, 0.5f, spriterichting, 0f);
            _spriteBatch.Draw(charactertexture, positie,runAnimatie.currentframe,Color.White,0f,new Vector2(0,67),1.3f,richting,0f);
        }
    }
        
}
