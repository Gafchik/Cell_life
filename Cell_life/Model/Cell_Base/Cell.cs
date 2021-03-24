using Cell_life.Cell_Control;
using Cell_life.Model.Game_Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_life.Cell_Model.Cell_Base
{
    public class Cell
    {
        Cell_Conrol control;
        public Random random;

        public  int id  { get; set; }
        public  int id_genom  { get; set; }
    public Point location { get; set; }
        public Size size { get; set; }
        public int Age { get; private set; }
        public int time_life { get; private set; }
        public int time_to_death { get; set; }
        public int count_genom { get; set; }
        public List<int> id_childs { get; set; }
        public Color color_leve { get; set; }
        public Color color_died { get; set; }
        public int move_step { get; set; }

        public Cell(int id,int id_genom, Color color, Point point)
        {
            this.id_genom = id_genom;
             control = new Cell_Conrol();
            random = new Random();
            size = new Size(5, 5);
            location = new Point(point.X,point.Y);
            this.id = id;
            this.time_life = 50;
            this.time_to_death = 50;
            this.count_genom = 0;
            Age = 0;
            this.id_childs = new List<int>();
            this.color_leve = color;
            color_died = Color.Red;
            move_step = 10;
        }

        public void Die() => control.Kill_My(this);
      

        public void Eat() => time_to_death = time_to_death + 3;



        public int Get_Cout_Generation()
        {
            int rez = random.Next(0, 100);
            if (rez >= 0 && rez <= 88)
                return 0;
            if (rez >= 92 && rez <= 94)
                return 1;
            if (rez >= 95 && rez <= 97)
                return 2;
            if (rez >= 98 && rez <= 100)
                return 3;
            else
                return 4;
        }


        public void Move()
        {
            switch (random.Next(0,3))       
            {
                case 0:              
                    location = new Point(location.X + move_step, location.Y);
                    break;
                case 1:                
                    location = new Point(location.X, location.Y + move_step);
                    break;
                case 2:              
                    location = new Point(location.X - move_step, location.Y);
                    break;
                case 3:              
                    location = new Point(location.X , location.Y - move_step);
                    break;
                    
                default:
                    break;
            }
        }

        public void Old()
        {
            if (time_to_death != 0)
            { time_to_death--; Age++; }
            else
                Die();
        }


    }
 
}
