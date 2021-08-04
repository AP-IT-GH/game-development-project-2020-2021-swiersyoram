using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.gamestates
{
    interface IGameState
    {
        public void load();
        public void update();
        public void draw();
    }
}
