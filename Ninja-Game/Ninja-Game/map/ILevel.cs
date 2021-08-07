using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.map
{
    interface ILevel
    {
        public void load();
        public Dictionary<string, List<Rectangle>> layout();
        public void Draw();


    }
}
