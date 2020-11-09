using System;

namespace _10op20
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
