using System;
using System.Collections.Generic;
using System.Text;

namespace Krig
{
    public static class DeckCreator
    {

        public static Queue<Card> CreateCards()
        {
            Queue<Card> cards = new Queue<Card>();

            for (int i = 1; i < 14; i++)
            {
                foreach(Suite suit in Enum.GetValues(typeof(Suit)))
                {

                }
            }
        }
    }
}
