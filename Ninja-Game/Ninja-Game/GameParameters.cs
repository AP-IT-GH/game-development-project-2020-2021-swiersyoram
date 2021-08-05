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
        public static gameState gamestate = gameState.running;


        //characters
        //ninjaGirl
        public static int girlSpriteWidth = 2820;
        public static int girlSpriteHeight = 390;
        public static int girlWidth = 282;
        public static int girlHeight = 390;
        public static double girlScale = 0.30;
        public static double girlScaledHeight = girlHeight * girlScale;

    }
}
