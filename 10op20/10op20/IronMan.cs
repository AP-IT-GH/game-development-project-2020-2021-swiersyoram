using IronManGame.Animaties;
using IronManGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

using System.Text;

namespace IronManGame
{
    public class IronMan : IGameObject
    {
        private Rectangle heroViewRectangle;
       
        IronMan hero;
        Texture2D herotexture;
        Animatie runAnimatie;



        public IronMan(Texture2D texture)
        {
            herotexture = texture;
            runAnimatie = new Animatie();
            runAnimatie.addFrame(new Rectangle(160, 0, 160, 160));
            runAnimatie.addFrame(new Rectangle(320, 0, 160, 160));
            runAnimatie.addFrame(new Rectangle(480, 0, 160, 160));
            runAnimatie.addFrame(new Rectangle(320, 0, 160, 160));
        }

        public void Update()
        {
            runAnimatie.Update();

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(herotexture, new Vector2(10, 400), runAnimatie.currentframe, Color.White);
        }

    }
}