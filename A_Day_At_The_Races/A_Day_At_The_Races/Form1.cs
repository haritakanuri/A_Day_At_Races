using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_At_The_Races
{
    public partial class Form1 : Form
    {
        Greyhound[] GreyhoundArray = new Greyhound[4]; // creates one array of 4 greyhounds objects 
        Guy[] GuysArray = new Guy[3]; // creates one array of 3 guy objects
        Random MyRandomizer = new Random();

        public Form1()
        {
            InitializeComponent();
            joeRadioButton.Checked = true;
            // initialize minimum bet label
            minimumBetLabel.Text = "Minimum Bet : " + numericUpDown1.Minimum.ToString() + " pounds";

            // initialize all 4 elements of the GreyhoundArray
            GreyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RaceTrackLenght = racetrackPicturebox.Width - pictureBox1.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RaceTrackLenght = racetrackPicturebox.Width - pictureBox2.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RaceTrackLenght = racetrackPicturebox.Width - pictureBox3.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RaceTrackLenght = racetrackPicturebox.Width - pictureBox4.Width,
                Randomizer = MyRandomizer
            };

            //initialize all 3 elements of the GuysArray
            GuysArray[0] = new Guy()
            {
                Name = "Joe",
                MyBet = null,
                Cash = 50,
                MyRadioButton = joeRadioButton,
                MyLabel = joeBetLabel
            };

            GuysArray[1] = new Guy()
            {
                Name = "Bob",
                MyBet = null,
                Cash = 75,
                MyRadioButton = bobRadioButton,
                MyLabel = bobBetLabel
            };

            GuysArray[2] = new Guy()
            {
                Name = "Al",
                MyBet = null,
                Cash = 45,
                MyRadioButton = alRadioButton,
                MyLabel = alBetLabel
            };

            for (int i = 0; i <= 2; i++)
            {
                GuysArray[i].UpdateLabels();
                GuysArray[i].MyBet = new Bet();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void raceButton_Click(object sender, EventArgs e)
        {
            //Dogs take start position
            GreyhoundArray[0].TakeStartingPosition();
            GreyhoundArray[1].TakeStartingPosition();
            GreyhoundArray[2].TakeStartingPosition();
            GreyhoundArray[3].TakeStartingPosition();

            //disable race button till the end of the race
            bettingParlor.Enabled = false;

            //start timer
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (GreyhoundArray[i].Run())
                {
                    timer1.Stop();
                    bettingParlor.Enabled = true;
                    i++;
                    MessageBox.Show("Dog " + i + " won the race");
                    for (int j = 0; j <= 2; j++)
                    {
                        GuysArray[j].Collect(i);
                        GuysArray[j].ClearBet();
                    }
                    break;
                }
            }
        }

        private void betsButton_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                if (GuysArray[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    joeBetLabel.Text = GuysArray[0].MyBet.GetDescription();
                }
            }
            else if (bobRadioButton.Checked)
            {
                if (GuysArray[1].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    bobBetLabel.Text = GuysArray[1].MyBet.GetDescription();
                }
            }
            else if (alRadioButton.Checked)
            {
                if (GuysArray[2].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value))
                {
                    alBetLabel.Text = GuysArray[2].MyBet.GetDescription();
                }
            }
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Bob";
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Al";
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Joe";
        }
    }
}
