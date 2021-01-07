using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IronManGame.Interfaces
{
    interface IBtn
    {
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void update(GameTime gameTime);



    }
}
