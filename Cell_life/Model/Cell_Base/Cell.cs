using Cell_life.Cell_Control;
using Cell_life.Model.Eat_Model;
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
    public enum Eirection { up,up_right,right,right_down,down,down_left,left,left_up}
    public class Cell
    {
        Cell_Conrol control;
        public Random random;
        public int id { get; set; }   
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
        public Food found_food { get; set; }
        public Eirection eirection { get; set; }
      private  Timer timer_life ;
        private Timer timer_child ;
        private Timer timer_food;
        private Timer timer_next;


        public Cell(int id,  Color color, Point point)
        {
            control = new Cell_Conrol();
            random = new Random();
            eirection = (Eirection)random.Next(7);
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
            found_food = null;

            timer_life = new Timer();
            timer_life.Tick += Timer_life_Tick;
            timer_life.Interval = 1000;
            timer_life.Start();

            timer_child = new Timer();
            timer_child.Tick += Timer_child_Tick;
            timer_child.Interval = 5000;
            timer_child.Start();

            timer_food = new Timer();
            timer_food.Tick += Timer_food_Tick;
            timer_food.Interval = 100;
            timer_food.Start();

            timer_next = new Timer();
            timer_next.Tick += Timer_next_Tick;
            timer_next.Interval = 3000;
            timer_next.Start();

        }

        private void Timer_next_Tick(object sender, EventArgs e) => eirection = (Eirection)random.Next(7);
        private void Timer_child_Tick(object sender, EventArgs e)
        {
            lock (this)
            {
                try
                {
                    for (int i = 0; i < Get_Cout_Generation(); i++)
                    {
                        Cells.cells.Add(new Cell(Cells.cells.Count + 1, color_leve, new Point(location.X + 1, location.Y + 1)));
                        id_childs.Add(Cells.cells.Count);
                    }
                }
                catch (Exception) { }
            }
        }
     private void Timer_food_Tick(object sender, EventArgs e) => Search_Eat();
        private void Timer_life_Tick(object sender, EventArgs e) => Old();

        public void Die() => control.Kill_Cell(this);
        public void Feed() { time_life += 3; time_to_death +=3; }
        public void Eat(Food food)
        {
            control.Eat(food);
            time_life += 3;
            time_to_death += 3;
            found_food = null;
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
        private void No_Food_Move(Point point_zero_to_fild, Size size_field, Eirection eirection)
        {
            switch (eirection)
            {
                case Eirection.up:
                    if (location.Y - move_step >= point_zero_to_fild.Y + 20)
                        location = new Point(location.X, location.Y - move_step);
                    else
                    {
                      this.eirection = Eirection.down;
                        location = new Point(location.X, location.Y + move_step);
                    }
                    break;

                case Eirection.up_right:
                    if (location.Y - move_step >= point_zero_to_fild.Y + 20)
                        if (location.X + move_step <= point_zero_to_fild.X + size_field.Width - 100)
                        { 
                            location = new Point(location.X + move_step, location.Y - move_step);
                        }
                        else
                        {
                            this.eirection = Eirection.down_left;
                            location = new Point(location.X - move_step, location.Y + move_step);
                        }
                    else
                    {
                        this.eirection = Eirection.down_left;
                        location = new Point(location.X - move_step, location.Y + move_step);
                    }
                    break;
                case Eirection.right:
                    if (location.X + move_step <= point_zero_to_fild.X + size_field.Width - 100)
                        location = new Point(location.X + move_step, location.Y);
                    else
                    {
                        this.eirection = Eirection.left;
                        location = new Point(location.X - move_step, location.Y);
                    }
                    break;
                case Eirection.right_down:
                    if (location.Y + move_step <= point_zero_to_fild.Y + size_field.Height - 120)
                        if (location.X + move_step <= point_zero_to_fild.X + size_field.Width - 100)
                        {
                            location = new Point(location.X + move_step, location.Y + move_step);
                        }
                        else
                        {
                            this.eirection = Eirection.down_left;
                            location = new Point(location.X - move_step, location.Y - move_step);
                        }
                    else
                    {
                        this.eirection = Eirection.down_left;
                        location = new Point(location.X - move_step, location.Y - move_step);
                    }
                    break;
                case Eirection.down:
                    if (location.Y + move_step <= point_zero_to_fild.Y + size_field.Height - 120)
                        location = new Point(location.X, location.Y + move_step);
                    else
                    {
                        this.eirection = Eirection.up;
                        location = new Point(location.X, location.Y - move_step);
                    }
                    break;
                case Eirection.down_left:
                    if (location.Y + move_step <= point_zero_to_fild.Y + size_field.Height - 120)
                        if (location.X - move_step >= point_zero_to_fild.X + 50)
                        {
                            location = new Point(location.X - move_step, location.Y + move_step);
                        }
                        else
                        {
                            this.eirection = Eirection.up_right;
                            location = new Point(location.X + move_step, location.Y - move_step);
                        }
                    else
                    {
                        this.eirection = Eirection.up_right;
                        location = new Point(location.X + move_step, location.Y - move_step);
                    }
                    break;
                case Eirection.left:
                    if (location.X - move_step >= point_zero_to_fild.X + 50)
                        location = new Point(location.X - move_step, location.Y);
                    else
                    {
                        this.eirection = Eirection.right;
                        location = new Point(location.X + move_step, location.Y);
                    }
                    break;
                case Eirection.left_up:
                    if (location.Y - move_step >= point_zero_to_fild.Y + 20)
                        if (location.X - move_step >= point_zero_to_fild.X + 50)
                        {
                            location = new Point(location.X - move_step, location.Y - move_step);
                        }
                        else
                        {
                            this.eirection = Eirection.right_down;
                            location = new Point(location.X + move_step, location.Y + move_step);
                        }
                    else
                    {
                        this.eirection = Eirection.right_down;
                        location = new Point(location.X + move_step, location.Y + move_step);
                    }
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
        public void Search_Eat( )
        {          
            lock (this)
            {
               
                for (int i = vision - (vision * 2); i <= (vision * 2) + 1; i++)
                {
                    for (int j = vision - (vision * 2); j <= (vision * 2) + 1; j++)
                    {
                        if (Cells.foods.Exists(q => q.location.X == location.X + i & q.location.Y == location.Y + j))
                        {    
                            found_food = Cells.foods.Find(q => q.location.X == location.X + i & q.location.Y == location.Y + j);
                            break;
                        }
                    }
                }
               
              
            }
        }
        public void Move(Point point_zero_to_fild, Size size_field)
        {
            lock (this)
            {
                if (found_food != null)
                {
                    if (location != found_food.location)
                        Move_to_food(found_food);
                    else
                        Eat(found_food);
                }
                else
                    No_Food_Move(point_zero_to_fild, size_field, eirection);
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
