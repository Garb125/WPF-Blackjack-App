using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_App_v._2
{
    class Deck
    {
        readonly string[] Suits = new string[] { "Spades", "Hearts", "Clubs", "Diamonds" };
        readonly string[] Ranks = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        public List<Card> deck { get; } 


        public Deck()
        {
            this.deck = new List<Card> { };
            DeckBuilder();
            //this.Values = Dictionary<string, int>          UpdateValues();

        }
        
        public void DeckBuilder()
        {
            //List<Card> deck = new List<Card> { };

            foreach (string suit in Suits)
            {
                foreach (string rank in Ranks)
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            
            //return deck;
        }

        //private Card Card(string suit, string rank)
        //{
        //    throw new NotImplementedException();
        //}

        

        public Card drawCard()
        {
            
            Random rand = new Random();
            Card drawnCard = this.deck[rand.Next(0, deck.Count)];

            deck.Remove(drawnCard);

            return drawnCard;            
        }



        //public override string ToString()
        //{
        //    List<string> deckStack = new List<string>();

        //    for (int i = 0; i < DeckBuilder().Count; i++)
        //    {
        //        deckStack.Add(DeckBuilder()[i].ToString());                
        //    } 
        //    return deckStack.ToString();
        //}

    }
}
