using Cell_life.Cell_Control;
using Cell_life.Model.Eat_Model;
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
        public int vision { get; set; }


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
            vision = 200;
        }


        public void Die() => control.Kill_Cell(this);
        public void Feed() { time_life += 3; time_to_death +=3; }
        public void Eat(Food food)
        {
            control.Eat(food);
            time_life += 3;
            time_to_death += 3;
        }
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
        private void No_Food_Move(Point point_zero_to_fild, Size size_field)
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
        private void Move_to_food(Food found_food)
        {

            int step_to_food_X, step_to_food_Y, last_step_X, last_step_Y;
            step_to_food_X = step_to_food_Y = last_step_X = last_step_Y = 0;
            //X
            if(location.X>found_food.location.X)
            {
                last_step_X = (location.X - found_food.location.X) % move_step;
                if ((location.X - found_food.location.X) < move_step)
                    step_to_food_X = last_step_X - (last_step_X * 2); 
                else
                    step_to_food_X = move_step-(move_step*2);
            }
            if (location.X < found_food.location.X)
            {
                last_step_X = (found_food.location.X - location.X) % move_step;
                if ((found_food.location.X - location.X) < move_step)
                    step_to_food_X = last_step_X;
                else
                    step_to_food_X = move_step;
            }
            //Y
            if (location.Y > found_food.location.Y)
            {
                last_step_Y = (location.Y - found_food.location.Y) % move_step;
                if ((location.Y - found_food.location.Y) < move_step)
                    step_to_food_Y = last_step_Y - (last_step_Y * 2);
                else
                    step_to_food_Y = move_step - (move_step * 2);
            }
            if (location.Y < found_food.location.Y)
            {
                last_step_Y = (found_food.location.Y - location.Y) % move_step;
                if ((found_food.location.Y - location.Y) < move_step)
                    step_to_food_Y = last_step_Y;
                else
                    step_to_food_Y = move_step;
            }
            location = new Point(location.X+step_to_food_X, location.Y+step_to_food_Y);


        }
        private bool Search_Eat(out Food found_food )
        {
           
            lock (this)
            {
                for (int i = vision - (vision * 2); i <= (vision * 2) + 1; i++)
                {
                    for (int j = vision - (vision * 2); j <= (vision * 2) + 1; j++)
                    {
                        if (Game_elements.foods.Exists(q => q.location.X == location.X + i & q.location.Y == location.Y + j))
                        {
                            found_food = Game_elements.foods.Find(q => q.location.X == location.X + i & q.location.Y == location.Y + j);
                            return true;
                        }
                    }
                }
                found_food = null;
                return false;
            }
        }
        public void Move(Point point_zero_to_fild, Size size_field)
        {
            Food found_food;
            if (Search_Eat(out found_food))
            {
                if (found_food != null)
                {
                    if (location != found_food.location)
                        Move_to_food(found_food);
                    else
                        Eat(found_food);
                }
                else
                    No_Food_Move(point_zero_to_fild, size_field);
            }
            else
                No_Food_Move(point_zero_to_fild, size_field);
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
