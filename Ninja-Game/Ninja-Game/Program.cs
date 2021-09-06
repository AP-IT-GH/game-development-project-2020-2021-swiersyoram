using System;

namespace NinjaGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new NinjaGame())
                game.Run();
        }
    }
}
