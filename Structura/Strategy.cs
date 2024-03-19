using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Structura
{
  
    public interface AttackStrategy
    {
        void Attack(Player player, Enemies bomb, Form1 f);
    }

    public class BombStrategy : AttackStrategy
    {
        int j=0;
       
            public void Attack(Player player, Enemies bomb, Form1 f)
            {
            int bomb_X= bomb.picture.Location.X;
            int bomb_Y = bomb.picture.Location.Y;
            int player_X = player.picture.Location.X;
            int player_Y = player.picture.Location.Y;
            Size size;
            if (Math.Sqrt(((bomb_X - player_X) * (bomb_X - player_X))+((bomb_Y - player_Y) * (bomb_Y - player_Y)))<=15 && player.health > 25) {
                f.Controls.Remove(bomb.picture);
                size = player.picture.Size;
                player.picture.Size = new Size(150, 110);
                Timer timer = new Timer();
                timer.Interval =125;
                timer.Tick += timer1_Tick;
                player.picture.Image = (Image)Properties.Resources.ResourceManager.GetObject("Vibuh");
                timer.Start();
               void timer1_Tick(object sender, EventArgs e)
                {
                   
                    if (j >= 3)
                    {
                        timer.Stop();
                       
                        player.picture.Size = size;
                        player.picture.Image = (Image)Properties.Resources.ResourceManager.GetObject("player");
                       
                        timer.Dispose();
                        j = 0;
                        
                    }
                    j++;
                }
                player.enemies.Remove(bomb);
                player.health -= 25;
                bomb.picture.Location = new Point(0, 0);
                bomb.picture = null;
                bomb = null;
            }
      }
    }
    public class GhostStrategy : AttackStrategy
    {
        public void Attack(Player player, Enemies ghost, Form1 f)
        {
            int ghost_X = ghost.picture.Location.X;
            int ghost_Y = ghost.picture.Location.Y;
            int player_X = player.picture.Location.X;
            int player_Y = player.picture.Location.Y;
            if (Math.Sqrt(((ghost_X - player_X) * (ghost_X - player_X)) + ((ghost_Y - player_Y) * (ghost_Y - player_Y))) <= 20 && player.health >=10)
            {
                player.health -= 10;
            }
        }
    }
    public class StrikerStrategy : AttackStrategy
    {
        public void Attack(Player player, Enemies striker, Form1 f)
        {
            int striker_X = striker.picture.Location.X;
            int striker_Y = striker.picture.Location.Y;
            int player_X = player.picture.Location.X;
            int player_Y = player.picture.Location.Y;
            if (Math.Sqrt(((striker_X - player_X) * (striker_X - player_X)) + ((striker_Y - player_Y) * (striker_Y - player_Y))) <= 40 && player.health >= 35)
            {
                player.health -= 35;
            }
        }
    }
}
