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
using System.Text;

namespace IronManGame
{
    public class IronMan : IGameObject
    {
    
       
        IronMan hero;
        Texture2D herotexture;
        Animatie runAnimatie;
        Animatie standingAnimatie;
        private Animatie gekozenAnimatie;
        private int ground;
        private SpriteEffects spriterichting;
        private Vector2 positie;
        private KeyboardReader input;





        public IronMan(Texture2D texture, GraphicsDevice graphics)
        {
            herotexture = texture;


            //animatieframes bepalen 
            //lopen
            runAnimatie = new Animatie();
            runAnimatie.addFrame(new Rectangle(160, 0, 160, 160));
            runAnimatie.addFrame(new Rectangle(320, 0, 160, 160));
            runAnimatie.addFrame(new Rectangle(480, 0, 160, 160));
            runAnimatie.addFrame(new Rectangle(320, 0, 160, 160));
            //stilstaan
            standingAnimatie = new Animatie();
            standingAnimatie.addFrame(new Rectangle(0, 0, 160, 160));

            spriterichting = new SpriteEffects();

            ground = graphics.Viewport.Height - 100;

            input = new KeyboardReader(ground);
            
        

        }

        public void Update(GameTime gameTime)
        {
            input.readInput();
 
            
            positie = input.positie;
           
            if (input.keuzeAnimatie == "runAnimatie")
                gekozenAnimatie = runAnimatie;
            if (input.keuzeAnimatie == "standingAnimatie")
                gekozenAnimatie = standingAnimatie;

            if (input.direction.X == 1)
                spriterichting = SpriteEffects.None;
            if (input.direction.X == -1)
                spriterichting = SpriteEffects.FlipHorizontally;
            gekozenAnimatie.Update(gameTime);


        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(herotexture, positie, gekozenAnimatie.currentframe, Color.White, 0f, Vector2.Zero, 0.5f, spriterichting, 0f);
        }

    }
}