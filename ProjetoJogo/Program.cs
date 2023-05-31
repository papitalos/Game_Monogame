using ProjetoJogo;
using System;
namespace ProjetoJogo
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            using var game = new Game1();
            game.Run();
        }
    }
}