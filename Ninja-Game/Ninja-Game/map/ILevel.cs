using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.map
{
    interface ILevel
    {
        public List<Rectangle> Crates { get; set; }

        public List<Rectangle> Spikes { get; set; }
        public List<Vector2> Coins { get; set; }
        public List<Rectangle> Rotatedspikes { get; set; }

        public Rectangle Deur { get; set; }
        public void Load();
        public void Update(GameTime gameTime);
        public void Draw();


    }
}
