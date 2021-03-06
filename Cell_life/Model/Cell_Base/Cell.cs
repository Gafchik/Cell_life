using Cell_life.Cell_Control;
using Cell_life.Model.Eat_Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Cell_life.Cell_Model.Cell_Base
{
    public enum Eirection { up,up_right,right,right_down,down,down_left,left,left_up}
    public class Cell
    {
        public int max_count_child { get; set; }
        public int count_child { get; set; }
        public int HP { get; set; }
        public int Max_HP { get; set; }
        public int damage { get; set; }
        private Random random;
        public int id { get; set; }
        public Point location { get; set; }
        public Size size { get; set; }
        public int count_food { get; private set; }
        public List<int> id_childs { get; set; }
        public Color color { get; set; }
        public int move_step { get; set; }
        public int vision { get; set; }
        public Food found_food { get; set; }
        public Cell cell_enemy { get; set; }
        public Eirection eirection { get; set; }
      

        public Cell(int id, Color color, Point point)
        {
             Max_HP = HP = 100;
            random = new Random();
            max_count_child = random.Next(0, 4);
            damage = random.Next(2,7);
            eirection = (Eirection)random.Next(7);
            size = new Size(10, 10);
            location = new Point(point.X, point.Y);
            this.id = id;
            count_food = 0;
            count_child = 0;
            id_childs = new List<int>();
            this.color = color;
            move_step = 5;
            vision = 500;
            found_food = null;
            cell_enemy = null;


        }

        public Cell(Cell n_cell)
        {
            HP = n_cell.HP;
            Max_HP = n_cell.Max_HP;
            this.damage = n_cell.damage;
            this.random = n_cell.random;
            this.id = n_cell.id;
            this.location = n_cell.location;
            this.size = n_cell.size;
            this.count_food = n_cell.count_food;
            this.id_childs = n_cell.id_childs;
            this.color = n_cell.color;
            this.move_step = n_cell.move_step;
            this.vision = n_cell.vision;
            this.found_food = n_cell.found_food;
            this.cell_enemy = n_cell.cell_enemy;
            this.eirection = n_cell.eirection;
        }
        public void Next_Move()=> eirection = (Eirection) random.Next(7);
        public void Get_Child()
        {
            lock (this)
            {
                if (count_child <= max_count_child)
                {
                    try
                    {
                        for (int i = 0; i < Get_Cout_Generation(); i++)
                        {
                            Cells.cells.Add(new Cell(Cells.cells.Count + 1, color, new Point(location.X + 1, location.Y + 1)));
                            id_childs.Add(Cells.cells.Count);
                        }
                        count_child++;
                    }
                    catch (Exception) { }
                }
            }
        }     
        public void Feed()
        {
            Max_HP += 10;
            HP += 20;
            if (HP > Max_HP)
                HP = Max_HP;
            damage += 1;
           
            size = new Size(size.Width + 1, size.Height + 1);
        }
        public void Move(Point point_zero_to_fild, Size size_field)
        {
            if (Cell_Conrol.is_fight)
            {
                Search_Enemy();
                if (this.cell_enemy != null)
                {
                    if (this.location.Equals(cell_enemy.location))
                        Fight(cell_enemy);
                    else

                        Move_to_Point(cell_enemy.location);
                }
                else
                {
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
            else
            {
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
            found_food = null;
            cell_enemy = null;
        }
        private void Fight(Cell cell_enemy)
        {
            Hit(cell_enemy);
            if (HP < 0)
                Die();          
        }
        public void Hit(Cell enemy) => enemy.HP -= damage;           
        public void Die()
        {                      
            Cells.foods.Add(new Food(new Point(this.location.X - 10, this.location.Y + 10)));
            Cells.cells.Remove(this);
        }
        private void Eat(Food food)
        {
            Cells.foods.Remove(food);
            count_food++;
            Max_HP += food.growth_HP;
            HP += food.regen_HP;
            if (HP > Max_HP)
                HP = Max_HP;
            damage += food.growth_damage;
            found_food = null;
            size = new Size(size.Width + 1, size.Height + 1);
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
                var t = Cells.cells.FindAll(i => i.Step_to_Cell(location) < vision).
                 FindAll(i => i.GetHashCode() != this.GetHashCode()&&
                  i.color != color);
               t.ForEach(i => steps.Add(i.Step_to_Cell(location)));
                int min_step = steps.Min<int>();
                cell_enemy = t.Find(i => i.Step_to_Cell(location) <= min_step);
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
