using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ОТУ_РГР
{
    public partial class Form1 : Form
    {
        int wins;
        int amogus;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Properties.Resources.MazeImage;
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
            wins = 0;
            List<int> Total_moves = new List<int>();
            for (int j = 0; j < Int32.Parse(textBox4.Text); j++)
            {
                List<int> way = new List<int>();
                Master master = new Master(smth) { };
                Player player = new Player(textBox3.Text.Select(x => Int32.Parse(x.ToString())).ToList());
                for (int i = 0; i < player.Yes_No.Count + 1; i++)
                {
                    amogus = master.Hint(player.Current_location);
                    if (amogus == 999)
                    {
                        richTextBox2.Text += "Партия номер " +(j+1) + ". Победа в точке " + player.Current_location + " за " + i + "\n";
                        wins++;
                        Total_moves.Add(i);
                        break;
                    }
                    else
                    {
                        if (i == player.Yes_No.Count)
                        {
                            richTextBox1.Text += "Патрия номер: "+(j+1)+" Проигрыш\n";
                            foreach (int x in way)
                            {
                                richTextBox2.Text += x + "->";
                            }
                            richTextBox2.Text += '\n';
                            break;
                        }
                        //player.Current_location = player.To_react(amogus);
                        //way.Add(player.Current_location);
                    }
                    player.Current_location = player.To_react(amogus);
                    way.Add(player.Current_location);
                }
            }
            richTextBox1.Text += "Испытаний проведено: " + Int32.Parse(textBox4.Text) + "\n";
            richTextBox1.Text += "Процент побед: " + (float)wins/(float)(Int32.Parse(textBox4.Text)) * 100.0f +"%\n";
            richTextBox1.Text += "Среднее количество шагов в победных партиях: " + Total_moves.Average();
        }
    }
}
