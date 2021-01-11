using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krig
{
    public static class DeckCreator
    {

        // Create 52 Cards
        public static Queue<Card> CreateCards()
        {
            Queue<Card> cards = new Queue<Card>();

            // Create 14 cards for each suit
            for (int i = 2; i <= 14; i++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    // Enqueue adds to the end of the list.
                    cards.Enqueue(new Card()
                    {
                        Suit = suit,
                        Value = i,
                        DisplayName = FormatDisplayName(i, suit)
                    });
                }
            }
            return Shuffle(cards);
        }

        private static Queue<Card> Shuffle(Queue<Card> Cards)
        {
            Random rnd = new Random();
            List<Card> QueueToList = Cards.ToList();

            for (int i = QueueToList.Count - 1; i > 0; i--)
            {
                // First: Pick a random card that has not been already picked
                int c = rnd.Next(i + 1);

                // Second: Swap random card pick with the last "unselected" in the collection
                // Note: i is the last in line.
                Card temp = QueueToList[i];
                QueueToList[i] = QueueToList[c];
                QueueToList[c] = temp;
            }

            // Adds the shuffled cards back to queue following Card object.
            Queue<Card> ShuffledCards = new Queue<Card>();
            foreach (var card in QueueToList)
            {
                ShuffledCards.Enqueue(card);
            }
            return ShuffledCards;
        }

        // Formats the int values to string and display J,Q,K & A correctly.
        private static string FormatDisplayName(int value, Suit suit)
        {
            string Display = "";
            if (value >= 2 && value <= 10)
            {
                Display = value.ToString();
            }
            else if (value == 11)
            {
                Display = "J";
            }
            else if (value == 12)
            {
                Display = "Q";
            }
            else if (value == 13)
            {
                Display = "K";
            }
            else if (value == 14)
            {
                Display = "A";
            }

            return Display + Enum.GetName(typeof(Suit), suit)[0];
        }
    }
}
