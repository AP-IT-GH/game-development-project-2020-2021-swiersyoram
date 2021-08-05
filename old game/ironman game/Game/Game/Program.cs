using System;

namespace IronManGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new game())
                game.Run();

        }
    }
}
