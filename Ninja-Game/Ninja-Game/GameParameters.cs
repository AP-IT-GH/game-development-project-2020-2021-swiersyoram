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
        public static int girlHeight = 390;
        public static double girlScale = 0.35;
        public static double girlScaledHeight = girlHeight * girlScale;

    }
}
