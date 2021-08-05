 using IronManGame.Animaties;
using IronManGame;
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
using System.Diagnostics;

namespace IronManGame
{
    public class Gamecharacter_hero 
    {
    
       
        
        private Texture2D herotexture;
        private Animatie runAnimatie;
        private Animatie standingAnimatie;
        private Animatie gekozenAnimatie;
        
        private SpriteEffects spriterichting;
        private Vector2 _positie;
        private KeyboardReader input;





        public Gamecharacter_hero(Texture2D texture, GraphicsDevice graphics, List<Rectangle> platforms)
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

            

            input = new KeyboardReader(game.ground, platforms);
            
        

        }
        public void resetPosition()
        {
            input.setposition(game.heroStartPos);
        }

        public void Update(GameTime gameTime, List<Rectangle> platforms)
        {
            input.readInput(platforms);


            _positie = input.positie;
           
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
            
            _spriteBatch.Draw(herotexture, _positie, gekozenAnimatie.currentframe, Color.White, 0f, new Vector2(80,160),0.5f, spriterichting, 0f);
        }

    }
}