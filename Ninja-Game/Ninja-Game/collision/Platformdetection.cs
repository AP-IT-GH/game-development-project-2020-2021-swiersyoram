using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.collision
{
    class Platformdetection
    {

        public Tuple<bool, int> collision(Vector2 positie,  Vector2 lastpos,Dictionary<string, List<Rectangle>> layout)
        {
            
            
                foreach (var crate in layout["crates"])
                {
                    if (positie.X > crate.X && positie.X < crate.X + crate.Width + 10)
                    {
                        if (positie.Y > crate.Y && lastpos.Y <= crate.Y)
                        {
                            return Tuple.Create(true, crate.Y);
                            
                        }
                    }
                }
                return Tuple.Create(false, 0);

        }
    }
}
