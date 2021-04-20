using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kolkoikrzyzyk
{
    enum CurrentPlayer
    {
        Cross,
        Circle
    }
    public partial class Form1 : Form
    {
        CurrentPlayer currentPlayer;
        public Form1()
        {
            InitializeComponent();
            currentPlayer = CurrentPlayer.Cross;
            changeLabel();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Mark(object sender, EventArgs e)
        {
            Button senderButton = (Button)sender;
            if (currentPlayer == CurrentPlayer.Cross)
            {
                senderButton.Text = "X";
                currentPlayer = CurrentPlayer.Circle;
            }
            else
            {
                senderButton.Text = "O";
                currentPlayer = CurrentPlayer.Cross;
            }
            if (checkForWinner())
                showWinner();
            changeLabel();
        }
        public void changeLabel()
        {
            if (currentPlayer == CurrentPlayer.Cross)
            {
                currentPlayerLabel.Text = "Krzyżyk";
            }
            else
            {
                currentPlayerLabel.Text = "Kolko";
            }
        }
        public bool checkForWinner()
        {
            if (String.Compare(tl.Text, cl.Text) == 0 && String.Compare(cl.Text, bl.Text) == 0)
            {
                return true;
            }
            return false;
        }

        public void showWinner()
        {
            Form2 victoryScreen = new Form2();
            victoryScreen.winner = tl.Text;
            victoryScreen.Show();
        }
        public void clearBoard();
        {
             TableLayoutControlCollection buttons = tableLayoutPanel1.Controls;

             for(int i = 0; i < buttons.Count; i ++)
            {
            if(buttons[i] is Button)
               buttons[i].Text = "";
            }
          currentPlayer = CurrentPlayer.Cross;
        }
    }
}
