using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krig
{
    public class Game
    {
        private Player Player1;
        private Player Player2;
        private int TurnCount; // Number of turns elapsed

        public Game(string Player1Name, string Player2Name)
        {
            Player1 = new Player(Player1Name);
            Player2 = new Player(Player2Name);

            var Cards = DeckCreator.CreateCards(); // Returns Queue of shuffled/randomized cards.

            var deck = Player1.Deal(Cards); // Will make player1 hand out cards and return 26 cards to Player2.
            Player2.Deck = deck; // Sets Player2's cards
        }

        public bool IsEndOfGame()
        {
            if (!Player1.Deck.Any()) // Checks if player 1 is out of cards
            {
                Console.WriteLine(Player1.Name + " is out of cards! " + Player2.Name + " Wins!");
                return true;
            }
            else if (!Player2.Deck.Any()) // Checks if player 2 is out of cards
            {
                Console.WriteLine(Player2.Name + " is out of cards! " + Player1.Name + " Wins!");
                return true;
            }
            else if (TurnCount > 10000) // Checks if game is going in an infinite loop.
            {
                Console.WriteLine("Game has taken over 10000 turns. Stopping game");
                return true;
            }
            return false;
        }

        public void PlayTurn()
        {
            Queue<Card> CardsOnTable = new Queue<Card>();
            Console.WriteLine(Player1.Deck.Count);
            Console.WriteLine(Player2.Deck.Count);

            // Players cards:
            var Player1Card = Player1.Deck.Dequeue();
            var Player2Card = Player2.Deck.Dequeue();

            CardsOnTable.Enqueue(Player1Card);
            CardsOnTable.Enqueue(Player2Card);

            // Write what is drawn:
            Console.WriteLine(Player1.Name + " draws a " + Player1Card.DisplayName + " & " + Player2.Name + " draws a " + Player2Card.DisplayName);


            // Check if there is war
            while (Player1Card.Value == Player2Card.Value)
            {
                Console.WriteLine("WAR!");

                // Check if players have enough for WAR
                if (Player1.Deck.Count < 4)
                {
                    Player1.Deck.Clear();
                    return;
                }
                if (Player2.Deck.Count < 4)
                {
                    Player2.Deck.Clear();
                    return;
                }

                // Add 3 cards faced down
                CardsOnTable.Enqueue(Player1.Deck.Dequeue());
                CardsOnTable.Enqueue(Player1.Deck.Dequeue());
                CardsOnTable.Enqueue(Player1.Deck.Dequeue());
                CardsOnTable.Enqueue(Player2.Deck.Dequeue());
                CardsOnTable.Enqueue(Player2.Deck.Dequeue());
                CardsOnTable.Enqueue(Player2.Deck.Dequeue());


                // Fourth card faced up
                Player1Card = Player1.Deck.Dequeue();
                Player2Card = Player2.Deck.Dequeue();

                CardsOnTable.Enqueue(Player1Card);
                CardsOnTable.Enqueue(Player2Card);

                Console.WriteLine(Player1.Name + " draws a " + Player1Card.DisplayName + " & " + Player2.Name + " draws a " + Player2Card.DisplayName);
            }


            // Notes: 
            // 1st Add the won cards to the winning players deck
            // 2nd display winning player that round
            if (Player1Card.Value < Player2Card.Value)
            {
                foreach (var card in CardsOnTable)
                {
                    Player2.Deck.Enqueue(card);
                }

                Console.WriteLine(Player2.Name + " takes the hand!");
            }
            else
            {
                foreach (var card in CardsOnTable)
                {
                    Player1.Deck.Enqueue(card);
                }

                Console.WriteLine(Player1.Name + " takes the hand!");
            }

            TurnCount++;
        }
    }
}
