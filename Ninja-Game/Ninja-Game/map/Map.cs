using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame.map
{
    class Map:IMap
    {

        private ILevel level1;
        private ILevel activelevel;
        public Map(SpriteBatch spritebatch, ContentManager content)
        {

            List<Rectangle> crateslvl1 =  new List<Rectangle>();
            crateslvl1.Add(new Rectangle(600, 600, 80, 80));
            crateslvl1.Add(new Rectangle(600 + 80, 600, 80, 80));
            level1 = new Level(spritebatch, content, crateslvl1);
            
            activelevel = level1;

        }
        public void load()
        {
            activelevel.load();
        }

        public void switchlevel(level lvl)
        {
            switch (lvl)
            {
                case level.one:
                    activelevel = level1;
                    break;
                case level.two:
                    break;
                default:
                    break;
            }
        }
        public List<Rectangle> layout()
        {

            return activelevel.layout();
        }

        public void Draw()
        {
            level1.Draw();

        }
    }
}
