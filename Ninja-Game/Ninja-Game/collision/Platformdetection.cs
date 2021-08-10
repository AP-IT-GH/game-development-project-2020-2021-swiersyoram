using Microsoft.Xna.Framework;
using NinjaGame.map;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.collision
{
    class Platformdetection
    {
        private IMap layout;
        public Platformdetection(IMap Layout)
        {
            layout = Layout;

        }

        public Tuple<bool, int> collision(Vector2 positie,  Vector2 lastpos)
        {
            
            
                foreach (var crate in layout.ActiveLevel.Crates)
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
