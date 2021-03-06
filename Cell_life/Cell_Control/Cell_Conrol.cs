using Cell_life.Cell_Model;
using Cell_life.Cell_Model.Cell_Base;
using Cell_life.Cell_View;
using Cell_life.Model.Eat_Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Cell_life.Cell_Control
{
    class Cell_Conrol
    {      
       
        private Random r = new Random();
        public static bool is_fight = false;
        public static bool is_food = false;
        public static bool is_child = false;
        public static int time_game = 0;
        public  static  int fight_time = 30;
        private Timer timer_move;
        private Timer timer_leave;
        private Timer timer_food;
        Point point_zero_to_fild;
        Size size_field;

        public Cell_Conrol(Point point_zero_to_fild, Size size_field, Timer move, Timer leave)
        {
            this.point_zero_to_fild = point_zero_to_fild;
            this.size_field = size_field;

           this.timer_move = move;
           this.timer_leave = leave;
            timer_food = new System.Windows.Forms.Timer();
            timer_food.Interval = 2000;
            timer_food.Tick += Timer_food_Tick;
        }
        private void Timer_food_Tick(object sender, EventArgs e) => Get_food(point_zero_to_fild,size_field);
        private void Get_food(Point point_zero_to_fild, Size size_field)
        {
            End_Game(); Cells.cells.ForEach(i => i.Next_Move());
            if (is_food)
            {
                Cells.foods.Add(new Food(
                    new Point(
                        r.Next(70,point_zero_to_fild.X + size_field.Width - 100),
                        r.Next(point_zero_to_fild.Y + size_field.Height - 120))));
            }               
        }
        public void Create_cell(Color backColor, Point point)
        {
            lock (this)
            {
                Cells.cells.Add(new Cell(Cells.cells.Count + 1, backColor, point));
            }
        }     
        internal void Old()
        { 
            lock (this)
            {
                try                 
                {
                    time_game++;
                    if (is_child)
                        Cells.cells.ForEach(i => i.Get_Child());                
                } 
                catch (Exception) { } 
            }
        }
        internal void Mowe(Point point_zero_to_fild, Size size_field)
        {
            lock (this)
           {
                try
                {
                    Cells.cells.ForEach(i => i.Move(point_zero_to_fild, size_field));                   
                }
                catch (Exception) { }
            }
        }
        internal void Get_Cell_Info(Point mousePosition)
        {
            int radius = 10;
            lock (this)
            {
                for (int i = radius - (radius * 2); i <= (radius * 2) + 1; i++)
                {
                    for (int j = radius - (radius * 2); j <= (radius * 2) + 1; j++)
                    {
                        if (Cells.cells.Exists(q => q.location.X == mousePosition.X + i & q.location.Y == mousePosition.Y + j))
                        {
                            var temp = Cells.cells.Find(q => q.location.X == mousePosition.X + i & q.location.Y == mousePosition.Y + j);
                            new Form_InfoCell(temp).Show();
                        }
                    }
                }
            }
        }
        internal void Start()
        {
            timer_food.Start();
            timer_move.Start();
            timer_leave.Start();
        }
        internal void Pause()
        {
            timer_move.Stop();
            timer_leave.Stop();
        }
        internal void Stop()
        {
           lock (this)
            {
                time_game = 0;
                Cells.cells.Clear();
                Cells.foods.Clear();
                timer_move.Stop();
                timer_leave.Stop();
                timer_food.Stop();

            }
        }
        internal static void Fight(Cell cell, Cell cell_enemy)
        {
            if (cell.HP > 0 && cell_enemy.HP > 0)
            {
                cell.Hit(cell_enemy);
                cell_enemy.Hit(cell);
            }
            else
            {
                if (cell.HP <= 0)
                {

                    cell.Die();
                }
                if (cell_enemy.HP <= 0)
                {

                    cell_enemy.Die();
                }
            }
        }
        private void End_Game()
        {
            try
            {
                Color win_color = Cells.cells.FirstOrDefault().color;
                bool is_win = Cells.cells.All(i => i.color == win_color);
                if (is_win)
                {  
                    Stop();                   
                    MessageBox.Show($"Победили {win_color.ToString().Replace("Color", "")}", "Конец игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }
      
    }
}
