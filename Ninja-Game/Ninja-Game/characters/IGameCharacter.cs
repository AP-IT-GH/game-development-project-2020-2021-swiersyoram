using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.characters
{
    interface IGameCharacter
    {
        public void load();
        public void update();
        public void draw();

    }
}
