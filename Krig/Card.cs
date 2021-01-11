using System;
using System.Collections.Generic;
using System.Text;

namespace Krig
{
    public enum Suite
    {
        Clubs,
        Diamonds,
        Spades,
        Hearts
    }

    public class Card
    {
        public string DisplayName { get; set; }
        public string Suite { get; set; }
        public int Value { get; set; }

        public Card(String name, int value)
        {
            Suite = name;
            Value = value;
        }
        
    }
}
