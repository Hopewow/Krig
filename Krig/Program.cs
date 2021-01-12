using System;

namespace Krig
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Game game = new Game("Anders", "Jesper"); // Starts game.
            while (!game.IsEndOfGame()) // Checks if game is over.
            {
                game.PlayTurn(); // Runs each turn.
            }
            Console.Read();
        }
    }
}
