using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_App_v._2
{
    class Hand
    {
        public List<Card> HandComp;
        public int HandValue; 
        public int Aces;
        Dictionary<string, int> Values = new Dictionary<string, int>();

        public Hand()
        {
            UpdateValues();
            this.HandComp = new List<Card>();
            this.HandValue = 0;
            this.Aces = 0;
        }


        public void AddCard(Card card)
        {
            HandComp.Add(card);
            HandValue += Values[card.Rank];

            if (card.Rank == "A")
            {
                Aces += 1;
            }

            if (Aces > 1)
            {
                HandValue -= 10;
            }
                        

        }

        public void UpdateValues()
        {
            Values["2"] = 2;
            Values["3"] = 3;
            Values["4"] = 4;
            Values["5"] = 5;
            Values["6"] = 6;
            Values["7"] = 7;
            Values["8"] = 8;
            Values["9"] = 9;
            Values["10"] = 10;
            Values["J"] = 10;
            Values["Q"] = 10;
            Values["K"] = 10;
            Values["A"] = 11;
        }

        public string BustCheck()
        {
            //bool bust = false;
            string bustCheck = "";

            if (this.HandValue > 21)
            {
                bustCheck = "Bust";
            }
            else if (this.HandValue == 21)
            {
                bustCheck = "Blackjack";
            }           
            
            //add blackjack option; perhaps change bust to string and set value within if

            return bustCheck;
        }


    }
}
