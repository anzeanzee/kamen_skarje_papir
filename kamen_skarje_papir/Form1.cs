using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace kamen_skarje_papir
{
    public partial class Form1 : Form
    {
        int rounds = 3;
        int timerPerRound = 6;
        bool gameover = false;
        string[] CompchoiseList = { "rock", "paper","scissor", "rock", "paper", "scissor" };

        int randomNumber = 0;

        Random rnd = new Random();

        string CompChoise;

        string JazChoise;

        int JazScore;
        int CompScore;

        public Form1()
        {
            InitializeComponent();
            countDownTimer.Enabled = true;

            JazChoise = "none";

            txtCountDown.Text = "5";
        }

        private void izbere_comp_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            JazScore = 0;
            CompScore = 0;
            rounds = 3;
            txtScore.Text = "Jaz:" + JazScore + " - " + "Comp:" + CompScore;
            JazChoise = "none";
            countDownTimer.Enabled = true;
            izbere_igralec.Image = Properties.Resources.vprasaj;
            izbere_comp.Image = Properties.Resources.vprasaj;
            gameover = false;
        }

        private void countDownTimerEvent(object sender, EventArgs e)
        {
            timerPerRound -= 1;
            txtCountDown.Text = timerPerRound.ToString();
            txtRounds.Text = "Rounds: " + rounds;

            if (timerPerRound < 1)
            {
                countDownTimer.Enabled = false;
                timerPerRound = 6;
                randomNumber = rnd.Next(0, CompchoiseList.Length);
                CompChoise = CompchoiseList[randomNumber];

                switch (CompChoise)
                {
                    case "rock":
                        izbere_comp.Image = Properties.Resources.rock;
                        break;
                    case "paper":
                        izbere_comp.Image = Properties.Resources.paper;
                        break;
                    case "scissor":
                        izbere_comp.Image = Properties.Resources.Screenshot_2;
                        break;
                }

                if (rounds > 0)
                {
                    checkGame();
                }
                else
                {
                    if (JazScore > CompScore)
                    {
                        MessageBox.Show("Zmagal si igro!");
                    }
                    else
                    {
                        MessageBox.Show("Comp je zmagal igro");
                    }
                    gameover = true;
                }                             
                
            }
        }

        private void checkGame()
        {
            if (JazChoise == "rock" && CompChoise == "paper")
            {
                CompScore += 1;
                rounds -= 1;

                MessageBox.Show("Zmaga Comp, papir premaga škarje");
            }
            else if (JazChoise == "scissor" && CompChoise == "rock")
            {
                CompScore += 1;
                rounds -= 1;

                MessageBox.Show("Zmaga Comp, škarje zgubijo proti kamnu");
            }
            else if (JazChoise == "paper" && CompChoise == "scissor")
            {
                CompScore += 1;
                rounds -= 1;

                MessageBox.Show("Zmaga Comp, papir zgubi proti škarjam");
            }
            else if (JazChoise == "paper" && CompChoise == "rock")
            {
                JazScore += 1;
                rounds -= 1;

                MessageBox.Show("Zmaga igralec, papir zmaga kamen");
            }
            else if (JazChoise == "scissor" && CompChoise == "paper")
            {
                JazScore += 1;
                rounds -= 1;

                MessageBox.Show("Zmaga igralec, škarje zmagajo papir");
            }
            else if (JazChoise == "rock" && CompChoise == "scissor")
            {
                JazScore += 1;
                rounds -= 1;

                MessageBox.Show("Zmaga igralec, kamen zmaga škarje");
            }
            else if (JazChoise == "none")
            {
                MessageBox.Show("izberi nekaj");
            }
            else
            {
                MessageBox.Show("izenačeno");
            }
            startNextRound();

        }

        private void startNextRound()
        {
            if(gameover == true)
            {
                return;
            }
            txtScore.Text = "Jaz:" + JazScore + " - " + "Comp:" + CompScore;
            JazChoise = "none";
            countDownTimer.Enabled = true;
            izbere_igralec.Image = Properties.Resources.vprasaj;
            izbere_comp.Image = Properties.Resources.vprasaj;
        }


        private void btnRock_Click(object sender, EventArgs e)
        {
            izbere_igralec.Image = Properties.Resources.rock;
            JazChoise = "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            izbere_igralec.Image = Properties.Resources.paper;
            JazChoise = "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            izbere_igralec.Image = Properties.Resources.Screenshot_2;
            JazChoise = "scissor";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SoundPlayer splayer = new SoundPlayer(@"C:\Users\uroš\Downloads\ShBoom.wav");
            splayer.Play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SoundPlayer splayer = new SoundPlayer(@"C:\Users\uroš\Downloads\ShBoom.wav");
            splayer.Stop();
        }
    }
}
