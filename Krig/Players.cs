using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krig
{
    public class Player
    {
        public string Name { get; set; }
        public Queue<Card> Deck { get; set; }
        public Player(){ }

        public Player(string PlayerName)
        {
            Name = PlayerName;
        }

        public Queue<Card> Deal(Queue<Card> cards)
        {
            Queue<Card> player1cards = new Queue<Card>();
            Queue<Card> player2cards = new Queue<Card>();

            int counter = 2;
            while (cards.Any()) // This runs until there is no cards left in cards variable.
            {
                if (counter % 2 == 0) // Everytime we hit an even number that card goes into player2's deck
                {
                    player2cards.Enqueue(cards.Dequeue());
                }
                else // Everytime we are on an uneven number that card goes into player1's deck
                {
                    player1cards.Enqueue(cards.Dequeue());
                }
                counter++;
            }

            Deck = player1cards;
            return player2cards;
        }
    }
}
