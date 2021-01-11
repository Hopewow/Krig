using System;
using System.Collections.Generic;
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
            return cards;
        }

        private static Queue<Card> Shuffle(Queue<Card> Cards)
        {

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
