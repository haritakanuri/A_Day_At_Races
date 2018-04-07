using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_At_The_Races
{
    public class Guy
    {
        public string Name; //the guy's name
        public Bet MyBet; //an istance of Bet that has his bet
        public int Cash; //how much cash he has

        //guy's controll on the form

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " has " + Cash + " quids";
            MyLabel.Text = Name + " hasn't place a bet";
        }

        public void ClearBet()
        {
            MyBet.Amount = 0;
            MyBet.Dog = 0;
            MyBet.Bettor = this;
        }
        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if (Cash >= BetAmount)
            {
                MyBet.Amount = BetAmount;
                MyBet.Dog = DogToWin;
                MyBet.Bettor = this;
                return true;
            }
            else return false;

        }
        public void Collect(int winner)
        {
            Cash += MyBet.PayOut(winner);
            this.UpdateLabels();
        }
    }
}
