using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacGame
{
    public partial class Form1 : Form
    {
        private const bool disBut = false; // disabled button po każdym kliknięciu
        bool turn = true; // sprawdzamy kto teraz robi wybór, gdzie true == x; false == y
        int turn_count = 0; // liczba kroków, max 9
        static String playerOne, playerTwo;

        public Form1() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            label1.Text = playerOne;
            label2.Text = playerTwo;
        }

        public static void setPlayersName(String n1, String n2)
        {
            playerOne = n1;
            playerTwo = n2;
        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Dmytro Mytysh and some stackOverflow guys...", "Autor of app info");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = disBut;
            turn_count++;

            checkForWinner();
        }

        private void checkForWinner()
        {
            bool winer = false;
            //horizontal
            if((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                winer = true;
            }
           else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                winer = true;
            }
           else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                winer = true;
            }

            //vertical
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                winer = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                winer = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                winer = true;
            }

            //diagonal
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                winer = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
            {
                winer = true;
            }
            

            if (winer)
            {
                disabledAllButtons();
                String whoWin = "";
                if (turn)
                {
                    whoWin = playerTwo;
                    o_wins_count.Text = (Int32.Parse(o_wins_count.Text) + 1).ToString();
                } else
                { 
                    whoWin = playerOne;
                    x_wins_count.Text = (Int32.Parse(x_wins_count.Text) + 1).ToString();
                }
                MessageBox.Show(whoWin + " wins!", "You the lucky!");
            } else
            {
                if(turn_count == 9)
                {
                    draw_wins_count.Text = (Int32.Parse(draw_wins_count.Text) + 1).ToString();
                    MessageBox.Show("Try again!", "Upps!");
                }
            }
        }
        private void disabledAllButtons()
        {
            try
            {
                System.Collections.IList list = Controls;
                for (int i = 0; i < list.Count; i++)
                {
                    Control c = (Control)list[i];
                    Button b = (Button)c;
                    b.Enabled = disBut;
                }
            }
            catch
            {
                //doadłem bo krzyczało o jakieś dziwactwa
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
           
                System.Collections.IList list = Controls;
                for (int i = 0; i < list.Count; i++)
                {
                try
                {
                    Control c = (Control)list[i];
                    Button b = (Button)c;
                    b.Enabled = !disBut;
                    b.Text = "";
                }
                catch
                {

                }
            }
         
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                {
                    b.Text = "X";
                }else
                {
                    b.Text = "O";
                }
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                 b.Text = "";
            }
        }

        private void draw_wins_count_Click(object sender, EventArgs e)
        {

        }

        private void resetWinsCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_wins_count.Text = "0";
            x_wins_count.Text = "0";
            draw_wins_count.Text = "0";

        }
    }
}
