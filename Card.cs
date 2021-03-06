using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_App_v._2
{
    class Card
    {
        public string Suit;
        public string Rank;
        public string Source;

        
        public Card(string suit, string rank)
        {
            this.Suit = suit;
            this.Rank = rank;
            this.Source = "C:\\Users\\GG-Code\\Pictures\\cardimages\\" + $"{this.Rank}-{this.Suit}.gif";
        }

        public override string ToString()
        {
            return this.Rank + " of " + this.Suit;
        }

    }
}
