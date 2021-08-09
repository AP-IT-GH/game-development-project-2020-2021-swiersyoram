using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using NinjaGame.map;
using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaGame
{
    class GameParameters
    {

        //window
        public static int windowHeight = 1000;
        public static int windowWidth = 1800;

        //game states
        public static gameState gamestate = gameState.start;

        //level
        public static level activelevel = level.one;
      


        //ninjaGirl

        public static int girlSpriteWidth = 2820;
        public static int girlSpriteHeight = 390;
        public static int girlWidth = 282;
        public static int girlHeight = 390;


        //map
        public static int grond = 980;

        //layout level one
        public static List<Rectangle> crateslvl1 = new List<Rectangle>()
        {
            new Rectangle(0, 200, 80, 80),
            new Rectangle(100, 800, 80, 80),
            new Rectangle(180, 800, 80, 80),
            new Rectangle(450, 550, 80, 80),
            new Rectangle(530, 550, 80, 80),
            new Rectangle(700, 150, 80, 80),
            new Rectangle(780, 150, 80, 80),
            new Rectangle(1560, 200, 80, 80),
            new Rectangle(1640, 200, 80, 80),
            new Rectangle(1720, 200, 80, 80),

            new Rectangle(700, 600, 80, 80),
            new Rectangle(1100, 650, 80, 80),
            new Rectangle(1600, 700, 80, 80),
        };
        public static List<Rectangle> spikeslvl1 = new List<Rectangle>() {
        new Rectangle(900, GameParameters.grond - 80, 150, 80),
        new Rectangle(1050, GameParameters.grond - 80, 150, 80),
        new Rectangle(1200, GameParameters.grond - 80, 150, 80),
        new Rectangle(1350, GameParameters.grond - 80, 150, 80),
        new Rectangle(1500, GameParameters.grond - 80, 150, 80)
        };
        public static Rectangle deurlvl1 = new Rectangle(1700, 50, 80, 150);

        //layout level two

        public static List<Rectangle> crateslvl2 = new List<Rectangle>()
        {
            new Rectangle(900, 800, 80, 80),
            new Rectangle(980, 800, 80, 80),
            new Rectangle(1700, 600, 80, 80),
            new Rectangle(1450, 250, 80, 80),
            new Rectangle(1530, 250, 80, 80),
            new Rectangle(800, 200, 80, 80),
            new Rectangle(880, 200, 80, 80),
            new Rectangle(0, 350, 80, 80),
            new Rectangle(80, 350, 80, 80),
            new Rectangle(160, 350, 80, 80),
            new Rectangle(240, 350, 80, 80),
        };
       


          public static  List<Rectangle> spikeslvl2 = new List<Rectangle>()
          {
            new Rectangle(350, GameParameters.grond - 80, 150, 80),
            new Rectangle(500, GameParameters.grond - 80, 150, 80),
            new Rectangle(650, GameParameters.grond - 80, 150, 80),

            new Rectangle(900, GameParameters.grond - 80, 150, 80),



          };


        public static Rectangle deurlvl2 = new Rectangle(50, 200, 80, 150);



    }
}
