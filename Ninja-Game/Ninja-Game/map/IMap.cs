using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.map
{
    interface IMap
    {
        public void load()
        {

        }
        public List<Rectangle> layout();

        public void Draw()
        {

        }
    }
}
