using Cell_life.Cell_Control;
using Cell_life.Model.Game_Model;
using Cell_life.Properties;
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
        public int id { get; set; }
        public int id_genom { get; set; }
        public Point location { get; set; }
        public Size size { get; set; }
        public int Age { get; private set; }
        public int time_life { get; private set; }
        public int time_to_death { get; set; }
        public int count_genom { get; set; }
        public List<int> id_childs { get; set; }
        public List<int> id_parent { get; set; }
        public Color color_leve { get; set; }
        public Color color_died { get; set; }
        public int move_step { get; set; }


        public Cell(int id, int id_genom, Color color, Point point)
        {
            this.id_genom = id_genom;
            control = new Cell_Conrol();
            random = new Random();
            size = new Size(10, 10);
            location = new Point(point.X, point.Y);
            this.id = id;
            time_to_death = this.time_life = 20;
            count_genom = 0;
            Age = 0;
            id_childs = new List<int>();
            id_parent = new List<int>();
            color_leve = color;
            color_died = Color.Red;
            move_step = 5;
        }


        public void Die() => control.Kill_My(this);
        public void Eat() { time_life += 3; time_to_death +=3; }
        public int Get_Cout_Generation()
        {
            int rez = random.Next(0, 100);
            if (rez >= 0 && rez <= 90)
                return 0;
            if (rez >= 91 && rez <= 93)
                return 1;
            if (rez >= 94 && rez <= 96)
                return 2;
            if (rez >= 97 && rez <= 100)
                return 3;
            else
                return 0;
        }
        public void Move(Point point_zero_to_fild, Size size_field)
        {
            switch (random.Next(0, 3))
            {
                case 0:
                    if (location.X + move_step <= point_zero_to_fild.X + size_field.Width - 100)
                        location = new Point(location.X + move_step, location.Y);
                    else
                        location = new Point(location.X - move_step, location.Y);
                    break;
                case 1:
                    if (location.Y + move_step <= point_zero_to_fild.Y + size_field.Height - 120)
                        location = new Point(location.X, location.Y + move_step);
                    else
                        location = new Point(location.X, location.Y - move_step);
                    break;
                case 2:
                    if (location.X - move_step >= point_zero_to_fild.X + 70)
                        location = new Point(location.X - move_step, location.Y);
                    else
                        location = new Point(location.X + move_step, location.Y);
                    break;
                case 3:
                    if (location.Y - move_step >= point_zero_to_fild.Y + 50)
                        location = new Point(location.X, location.Y - move_step);
                    else
                        location = new Point(location.X, location.Y + move_step);
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
