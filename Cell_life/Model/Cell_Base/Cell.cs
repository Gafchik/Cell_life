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
        public int HP { get; set; }
        public int damage { get; set; }
        private Random random;
        public int id { get; set; }
        public Point location { get; set; }
        public Size size { get; set; }
        public int Age { get; private set; }
        public int time_life { get; private set; }
        public int time_to_death { get; set; }
        public int count_genom { get; private set; }
        public List<int> id_childs { get; set; }
        public List<int> id_parent { get; set; }
        public Color color_leve { get; set; }
        public Color color_medium { get; set; }
        public Color color_died { get; set; }
        public int move_step { get; set; }
        public int vision { get; set; }
        public Food found_food { get; set; }
        public Cell cell_enemy { get; set; }
        public Eirection eirection { get; set; }


        public Cell(int id, Color color, Point point)
        {
            HP = 100;
            damage = 2;
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
            color_medium = Color.Orange;
            color_died = Color.Red;
            move_step = 6;
            vision = 300;
            found_food = null;
            cell_enemy = null;


        }
     
        public void Next_Move()=> eirection = (Eirection) random.Next(7);
        public void Get_Child()
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
        public void Feed() { time_life += 3; time_to_death += 3; }
        public void Move(Point point_zero_to_fild, Size size_field)
        {
            cell_enemy = null;
            Search_Enemy();
            if (cell_enemy != null)
            {
                if (location != cell_enemy.location)
                    Move_to_Point(cell_enemy.location);
                else
                    // Fight(cell_enemy);
                    Cell_Conrol.Fight(this, cell_enemy);

            }
            else
            {
                found_food = null;
                Search_Food();
                if (found_food != null)
                {
                    if (location != found_food.location)
                        Move_to_Point(found_food.location);
                    else
                        Eat(found_food);
                }
                else
                    No_Food_Move(point_zero_to_fild, size_field, eirection);
            }
        }

        private void Fight(Cell cell_enemy)
        {
            Hit(cell_enemy);
            if (HP < 0)
                Die();
           

        }

        public void Hit(Cell enemy) => enemy.HP -= damage;
        public void Old()
        {
            if (time_to_death != 0)
            { time_to_death--; Age++; }
            else
                Die();
        }
        public void Die()
        {
            Cells.foods.Add(new Food(new Point(this.location.X - 10, this.location.Y + 10)));
            Cells.cells.Remove(this);           
        }
        private void Eat(Food food)
        {
            Cells.foods.Remove(food);
            time_life += 3;
            time_to_death += 3;
            found_food = null;
        }
        private int Get_Cout_Generation()
        {
            int rez = random.Next(0, 500);
            if (rez >= 0 && rez <= 400)
                return 0;
            if (rez >= 401 && rez <= 435)
                return 1;
            if (rez >= 436 && rez <= 470)
                return 2;
            if (rez >= 470 && rez <= 500)
                return 3;
            else
                return 0;
        }
        private void No_Food_Move(Point point_zero_to_fild, Size size_field, Eirection eirection)
        {
            switch (eirection)
            {
                case Eirection.up:
                    if (location.Y - move_step >=0)
                        location = new Point(location.X, location.Y - move_step);
                    else
                    {
                        this.eirection = Eirection.down;
                        location = new Point(location.X, location.Y + move_step);
                    }
                    break;

                case Eirection.up_right:
                    if (location.Y - move_step >= 0)
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
                    if (location.Y - move_step >= 0)
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
        private void Move_to_Point(Point p)
        {

            int step_to_food_X, step_to_food_Y, last_step_X, last_step_Y;
            step_to_food_X = step_to_food_Y = last_step_X = last_step_Y = 0;
            //X
            if (location.X > p.X)
            {
                last_step_X = (location.X - p.X) % move_step;
                if ((location.X - p.X) < move_step)
                    step_to_food_X = last_step_X - (last_step_X * 2);
                else
                    step_to_food_X = move_step - (move_step * 2);
            }
            if (location.X < p.X)
            {
                last_step_X = (p.X - location.X) % move_step;
                if ((p.X - location.X) < move_step)
                    step_to_food_X = last_step_X;
                else
                    step_to_food_X = move_step;
            }
            //Y
            if (location.Y > p.Y)
            {
                last_step_Y = (location.Y - p.Y) % move_step;
                if ((location.Y - p.Y) < move_step)
                    step_to_food_Y = last_step_Y - (last_step_Y * 2);
                else
                    step_to_food_Y = move_step - (move_step * 2);
            }
            if (location.Y < p.Y)
            {
                last_step_Y = (p.Y - location.Y) % move_step;
                if ((p.Y - location.Y) < move_step)
                    step_to_food_Y = last_step_Y;
                else
                    step_to_food_Y = move_step;
            }
            location = new Point(location.X + step_to_food_X, location.Y + step_to_food_Y);


        }        
        private void Search_Food()
        {
                List<int> steps = new List<int>();
            try
            {
                Cells.foods.FindAll(i => i.Step_to_Cell(location) < vision).ForEach(i => steps.Add(i.Step_to_Cell(location)));
                int min_step = steps.Min<int>();
                found_food = Cells.foods.Find(i => i.Step_to_Cell(location) <= min_step);                
            }
            catch (Exception)
            {

                found_food = null;

            }
            GC.Collect(GC.GetGeneration(steps));           
        }
        private void Search_Enemy()
        {
            List<int> steps = new List<int>();
            try
            {
                Cells.cells.FindAll(i => i.Step_to_Cell(location) < vision&&
                i.id != id//&&
               /* i.color_leve != color_leve*/).
                ForEach(i => steps.Add(i.Step_to_Cell(location)));
                int min_step = steps.Min<int>();
                cell_enemy = Cells.cells.Find(i => i.Step_to_Cell(location) <= min_step);
            }
            catch (Exception)
            {

                cell_enemy = null;

            }
            GC.Collect(GC.GetGeneration(steps));
        }
        public int Step_to_Cell(Point point) => Convert.ToInt32(Math.Sqrt(
               Math.Pow(Convert.ToDouble(location.X - point.X), 2)
             + Math.Pow(Convert.ToDouble(location.Y - point.Y), 2)));
    }
}
