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
            //float smth = float.Parse(textBox1.Text);
            //Master master = new Master(smth) {};
            ////List<int> Smth = new List<int>() {};
            //Player player = new Player(textBox3.Text.Select(x => Int32.Parse(x.ToString())).ToList());
            //int amogus;
            //int wins = 0;
            //for (int j = 0; j < Int32.Parse(textBox4.Text); j++)
            //{
            //    for (int i = 0; i < player.Yes_No.Count; i++)
            //    {
            //        amogus = master.Hint(player.Current_location);
            //        if (amogus == 999)
            //        {
            //            wins++;
            //            //richTextBox1.Text += "Победа в точке " + player.Current_location + " за " + i + " ходов";
            //            break;
            //        }
            //        player.Current_location = player.To_react(amogus);
            //        //richTextBox1.Text += amogus;//+ " " + player.To_react(amogus) + "\n";
            //        //richTextBox1.Text += " " + player.To_react(amogus) + "\n";
            //    }
            //}
            //richTextBox1.Text += "Процент побед: " + wins/ Int32.Parse(textBox4.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            float smth = float.Parse(textBox1.Text);
            int wins = 0;
            for (int j = 0; j < Int32.Parse(textBox4.Text); j++)
            {
                Master master = new Master(smth) { };
                //List<int> Smth = new List<int>() {};
                Player player = new Player(textBox3.Text.Select(x => Int32.Parse(x.ToString())).ToList());
                int amogus;
                richTextBox1.Text += "Партия номер: " + j + "\n";
                for (int i = 0; i < player.Yes_No.Count; i++)
                {
                    amogus = master.Hint(player.Current_location);
                    if (amogus == 999)
                    {
                        wins++;
                        richTextBox1.Text += "Победа в точке " + player.Current_location + " за " + i + " ходов\n";
                        break;
                    }
                    else
                        player.Current_location = player.To_react(amogus);
                    //richTextBox1.Text += amogus;//+ " " + player.To_react(amogus) + "\n";
                    //richTextBox1.Text += " " + player.To_react(amogus) + "\n";
                }
            }
            richTextBox1.Text += "Процент побед: " + (float)wins/(float)Int32.Parse(textBox4.Text);

        }
    }
}
