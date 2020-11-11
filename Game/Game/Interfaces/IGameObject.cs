using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IronManGame.Interfaces
{
    interface IGameObject
    {
        void Update(GameTime gameTime);
        
        void Draw(SpriteBatch _spriteBatch);
    }
}
