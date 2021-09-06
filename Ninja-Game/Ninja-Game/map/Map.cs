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
        public ILevel ActiveLevel { get; set; }
        public Map(SpriteBatch spritebatch, ContentManager content)
        {

            level1 = new Level(spritebatch, content, GameParameters.crateslvl1, GameParameters.spikeslvl1, GameParameters.rotatedspikeslvl1, GameParameters.coinslvl1, GameParameters.deurlvl1);
            level2 = new Level(spritebatch, content, GameParameters.crateslvl2, GameParameters.spikeslvl2, GameParameters.rotatedspikeslvl2, GameParameters.coinslvl2, GameParameters.deurlvl2);
            ActiveLevel = level1;

        }
        public void Load()
        {
            level1.Load();
            level2.Load();
        }
        public void Update(GameTime gameTime)
        {
            Activelevel();
            ActiveLevel.Update(gameTime);
        }


        private void Activelevel()
        {
            switch (GameParameters.activelevel)
            {
                case level.one:
                    ActiveLevel = level1;
                    break;
                case level.two:
                    ActiveLevel = level2;

                    break;
                default:
                    break;
            }
        }
       

        public void Draw()
        {
            ActiveLevel.Draw();
        }

    }
}
