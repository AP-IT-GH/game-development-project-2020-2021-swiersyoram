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
        private ILevel level2;
        private ILevel activelevel;
        public Map(SpriteBatch spritebatch, ContentManager content)
        {

            level1 = new Level(spritebatch, content, GameParameters.crateslvl1, GameParameters.spikeslvl1, GameParameters.deurlvl1);
            level2 = new Level(spritebatch, content, GameParameters.crateslvl2, GameParameters.spikeslvl2,GameParameters.deurlvl2);
            activelevel = level1;

        }
        public void load()
        {
            level1.load();
            level2.load();

        }

        public void Activelevel()
        {
            switch (GameParameters.activelevel)
            {
                case level.one:
                    activelevel = level1;
                    break;
                case level.two:
                    activelevel = level2;

                    break;
                default:
                    break;
            }
        }
        public Dictionary<string, List<Rectangle>> layout()
        {

            return activelevel.layout();
        }

        public void Draw()
        {
            activelevel.Draw();

        }
    }
}
