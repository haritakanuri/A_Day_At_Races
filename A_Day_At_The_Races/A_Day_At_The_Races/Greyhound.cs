using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace A_Day_At_The_Races
{
    public class Greyhound
    {
        public int StartingPosition; // where my PictureBox Starts
        public int RaceTrackLenght; //How long the racetrack is
        public PictureBox MyPictureBox = null; //My PictureBox object
        public Random Randomizer; //An integer random
        public int Location = 0; //My Location on the track

        public bool Run()
        {
            Location += Randomizer.Next(1,5);
            MyPictureBox.Left = Location;
            if (MyPictureBox.Left >= RaceTrackLenght)
	            {
                    return true;
	            }
            else
            {
                return false;
            }
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
    }
}
