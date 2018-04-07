using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Day_At_The_Races
{
    public class Bet
    {
        public int Amount; //The amount of cash that was bet
        public int Dog; //The number of the dog the bet is on
        public Guy Bettor; //the guy who placed the bet

        public string GetDescription()
        {
            string description = "";
            description = this.Bettor.Name + " bets " + this.Amount + " quids on dog #" + Dog;
            return description;
        }

        public int PayOut(int winner)
        {
            if (Dog == winner)
            {
                return this.Amount;
            }
            else
            {
                return -this.Amount;
            }
        }
    }
}
