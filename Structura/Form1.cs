using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Structura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Player player;
        public int X = 0;
        public int Y = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new Player(pictureBox2);
            player.enemies.Add(new Bomb(pictureBox1));
            player.enemies.Add(new Ghost(pictureBox3));
            player.enemies.Add(new Striker(pictureBox4));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.move(new Point(X, Y));
            player.Attack(this);
           progressBar1.Value= player.health;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            X = e.X - pictureBox1.Width / 2;
            Y = e.Y - pictureBox1.Height / 2;
        }
    }
}
