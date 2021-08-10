using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.map
{
    interface IMap
    {
        public ILevel ActiveLevel { get; set; }


        public void Load();
        
        public void Update(GameTime gameTime);
        public void Draw();
        
    }
}
