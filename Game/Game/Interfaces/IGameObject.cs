using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace IronManGame.Interfaces
{
    interface IGameObject
    {
        void Update();
        
        void Draw(SpriteBatch _spriteBatch);
    }
}
