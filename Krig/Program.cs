using System;

namespace Krig
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Game game = new Game("Anders", "Jesper");
            while (!game.IsEndOfGame())
            {
                game.PlayTurn();
            }
            Console.Read();
        }
    }
}
