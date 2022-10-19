using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class TicTacToe : Form
    {
        private bool _turn = true; //true for X, false for O
        private int _turnCount = 0;

        public TicTacToe()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Made by Kostas Chrysovergis", @"About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            var b = (Button)sender;
            b.Text = _turn ? "X" : "O";
            _turn = !_turn;
            b.Enabled = false;
            _turnCount++;
            CheckPlayerWon();
            
        }

        private void CheckPlayerWon()
        {
            var weHaveWinner = ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled)) ||
                               ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled)) ||
                               ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled)) ||
                               ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled)) ||
                               ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled)) ||
                               ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled)) ||
                               ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled)) ||
                               ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled));

            switch (weHaveWinner)
            {
                case false when _turnCount == 9:
                    MessageBox.Show(@"Draw");
                    DisableButtons();
                    return;
                case false when _turnCount != 9:
                    return;
            }

            MessageBox.Show(!_turn ? @"X wins" : @"O wins");
            DisableButtons();
        }

        private void DisableButtons()
        {
            foreach (Control c in Controls)
            {
                if (c is Button b) b.Enabled = false;
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (!(c is Button b)) continue;
                b.Enabled = true;
                b.Text = "";

            }
        }
    }
}
