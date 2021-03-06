using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_App_v._2
{
    class Chips
    {
        public int CurrentBet = 0;
        public int Total = 100;


        public Chips()
        {
            
        }

        public void Bet(int bet)
        {
            CurrentBet += bet;
            Total -= bet;
        }

        public void AddFunds()
        {
           Total += CurrentBet;
        }


    }
}
