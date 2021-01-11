using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Krig
{
    public class Player
    {
        public string Name { get; set; }
        public Queue<Card> Deck { get; set; }
    }
}
