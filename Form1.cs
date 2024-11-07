using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ОТУ_РГР
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Master master = new Master() { HintToExit = 1 };
            List<int> Smth = new List<int>() {1,1,1,1,1};
            Player player = new Player(Smth) { };
            int amogus;
            for (int i = 0; i < Smth.Count; i++)
            {
                amogus = master.Hint(player.Current_location);
                richTextBox1.Text += amogus;//+ " " + player.To_react(amogus) + "\n";
                richTextBox1.Text += " " + player.To_react(amogus) + "\n";
            }

        }
    }
}
