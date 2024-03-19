using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Structura
{
    public abstract class Enemies
    {
        public int speed;
        public PictureBox picture;
        public abstract void move(Point point);
        public abstract void Attack(Form1 f, Player p=null, Enemies b=null);
    }
    public class Bomb:Enemies
    {
        public Bomb(PictureBox p)
        {
            picture = p;
            speed = 10;
            attackStrategy = new BombStrategy();
        }
        AttackStrategy attackStrategy;

        public override void Attack(Form1 f, Player p=null, Enemies b=null)
        {
            attackStrategy.Attack(p, b, f);
        }
        public override void move(Point point)
        {
           
            if (this.picture.Right - (this.picture.Width / 2) <= point.X)
            {
                this.picture.Left += speed;
            }
            if (this.picture.Left + (this.picture.Width / 2) >= point.X)
            {
                this.picture.Left -= speed;
            }

            if (this.picture.Bottom - (this.picture.Height / 2) <= point.Y)
            {
                this.picture.Top += speed;
            }
            if (this.picture.Top + (this.picture.Height / 2) >= point.Y)
            {
                this.picture.Top -= speed;
            }
        }
    }
    public class Ghost : Enemies
    {
        public Ghost(PictureBox p)
        {
            picture = p;
            speed = 5;
            attackStrategy = new GhostStrategy();
        }
        AttackStrategy attackStrategy;

        public override void Attack(Form1 f, Player p = null, Enemies b = null)
        {
            attackStrategy.Attack(p, b, f);
        }
        public override void move(Point point)
        {

            if (this.picture.Right - (this.picture.Width / 2) <= point.X)
            {
                this.picture.Left += speed;
            }
            if (this.picture.Left + (this.picture.Width / 2) >= point.X)
            {
                this.picture.Left -= speed;
            }

            if (this.picture.Bottom - (this.picture.Height / 2) <= point.Y)
            {
                this.picture.Top += speed;
            }
            if (this.picture.Top + (this.picture.Height / 2) >= point.Y)
            {
                this.picture.Top -= speed;
            }
        }
    }
    public class Striker : Enemies
    {
        public Striker(PictureBox p)
        {
            picture = p;
            speed = 1;
            attackStrategy = new StrikerStrategy();
        }
        AttackStrategy attackStrategy;

        public override void Attack(Form1 f, Player p = null, Enemies b = null)
        {
            attackStrategy.Attack(p, b, f);
        }
        public override void move(Point point)
        {

            if (this.picture.Right - (this.picture.Width / 2) <= point.X)
            {
                this.picture.Left += speed;
            }
            if (this.picture.Left + (this.picture.Width / 2) >= point.X)
            {
                this.picture.Left -= speed;
            }
            if (this.picture.Bottom - (this.picture.Height / 2) <= point.Y)
            {
                this.picture.Top += speed;
            }
            if (this.picture.Top + (this.picture.Height / 2) >= point.Y)
            {
                this.picture.Top -= speed;
            }
        }
    }
    public class Player:Enemies
    {
        public Player(PictureBox p)
        {
            picture = p;
            speed = 7;
        }
        public int health = 100;
        int AttackRadius = 500;
        public List<Enemies> enemies = new List<Enemies>();
        public override void Attack(Form1 f, Player p=null, Enemies b=null) {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Attack( f, this, enemies[i]);
            }
    }
        public override void move(Point point)
        {
            this.picture.Left = point.X;
            this.picture.Top = point.Y;
            

            for(int i=0 ; i < enemies.Count; i++)
            {
                if (new Rectangle(this.picture.Location.X + ((this.picture.Width - AttackRadius) / 2), this.picture.Location.Y + ((this.picture.Height - AttackRadius) / 2), AttackRadius, AttackRadius).Contains( enemies[i].picture.Location))
                {
                     enemies[i].move(new Point(point.X + (this.picture.Width / 2), point.Y + (this.picture.Height / 2)));
                }
            }
        }
    }
}
