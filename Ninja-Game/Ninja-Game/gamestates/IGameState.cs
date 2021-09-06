using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.gamestates
{
    interface IGameState
    {
        public void load();
        public void update(GameTime gameTime);
        public void draw();
    }
}
