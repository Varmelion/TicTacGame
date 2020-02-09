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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (player1.TextLength <= 0 || player2.TextLength <= 0)
            {
                MessageBox.Show("Te fields with names can't be empty", "Alert!");
            } else
            {
                Form1.setPlayersName(player1.Text, player2.Text);
                this.Close();
            }

        }

        private void player2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //dodałem psewdo autofocus po naciśnięciu w polu 2 na Enter
            if(e.KeyChar.ToString() == "\r")
            {
                button1.PerformClick();
            }
        }
    }
}
