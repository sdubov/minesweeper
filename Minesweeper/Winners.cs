using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Winners : Form
    {
        public Winners()
        {
            InitializeComponent();
        }

        public void UpdateWinnersTable()
        {
            Winner[] winners = Winner.GetWinnersList().OrderBy(a => a.Time).Take(10).ToArray<Winner>();

            int timerValue = int.Parse(Game.GameInstance.TimerValue);
            int index = -1;

            // Store index of passed element.
            for (int i = 0; i < winners.Length; i++)
            {
                if (timerValue <= winners[i].Time)
                {
                    index = i;
                    break;
                }
            }


            // Change size of Winners form and position of OK button.
            this.Size = new Size(300, winners.Length * 30 + 107);
            this.okPictureBox.Location = new Point(220, winners.Length * 30 + 41);


            Label[] labelsArray = new Label[] 
            { 
                this.winnerOneLabel, 
                this.winnerTwoLabel, 
                this.winnerThreeLabel, 
                this.winnerForeLabel, 
                this.winnerFiveLabel, 
                this.winnerSixLabel, 
                this.winnerSevenLabel,
                this.winnerEightLabel,
                this.winnerNineLabel,
                this.winnerTenLabel
            };

            int winIndex = 0;

            for (int i = 0; i < winners.Length + 1; i++)
            {
                if (i == index)
                {
                    labelsArray[i].Text = string.Format("{0}.                          {1} sec", (i + 1).ToString(), timerValue);
                    
                    this.winnerTextBox.Location = new Point(95, i * 25 + 40);
                    this.winnerTextBox.Visible = true;
                }
                else
                {
                    labelsArray[i].Text = string.Format("{0}.  {1}      {2} sec", (i + 1).ToString(), winners[winIndex].Name, winners[winIndex].Time);
                    winIndex++;
                }
            }
        }

        public void ShowWinners()
        {
            Winner[] winners = Winner.GetWinnersList().OrderBy(a => a.Time).Take(10).ToArray<Winner>();
            
            // Change size of Winners form and position of OK button.
            this.Size = new Size(300, winners.Length * 30 + 107);
            this.okPictureBox.Location = new Point(220, winners.Length * 30 + 41);

            Label[] labelsArray = new Label[] 
            { 
                this.winnerOneLabel, 
                this.winnerTwoLabel, 
                this.winnerThreeLabel, 
                this.winnerForeLabel, 
                this.winnerFiveLabel, 
                this.winnerSixLabel, 
                this.winnerSevenLabel,
                this.winnerEightLabel,
                this.winnerNineLabel,
                this.winnerTenLabel
            };

            for (int i = 0; i < winners.Length; i++)
            {
                labelsArray[i].Text = string.Format("{0}.  {1}      {2} sec", (i + 1).ToString(), winners[i].Name, winners[i].Time);
            }
        }

        private void okPictureBox_Click(object sender, EventArgs e)
        {
            if (this.winnerTextBox.Text != string.Empty && Game.GameInstance.TimerValue != null)
            {
                Winner.AddWinner(new Winner(this.winnerTextBox.Text, int.Parse(Game.GameInstance.TimerValue)));
            }

            else if (this.winnerTextBox.Text == string.Empty && Game.GameInstance.TimerValue != null)
            {
 
            }
            
            this.Close();
        }
    }
}
