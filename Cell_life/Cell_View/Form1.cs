using Cell_life.Cell_Control;
using Cell_life.Cell_Model;
using Cell_life.Cell_Model.Cell_Base;
using Cell_life.Model.Eat_Model;
using Cell_life.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_life
{
    public partial class Form1 : Form
    {

        readonly SolidBrush Brash_life;
        readonly SolidBrush Brash_foot;
        readonly SolidBrush Brash_die;
        Cell_Conrol control;

        public Form1()
        {
            InitializeComponent();
            panel_color.BackColor = Color.Black;
            control = new Cell_Conrol();
            button_color.Click += Button_color_Click;
            //  DoubleBuffered = true;
            Brash_life = new SolidBrush(panel_color.BackColor);
            Brash_die = new SolidBrush(Color.Red);
            Brash_foot = new SolidBrush(Color.Green);
            panel_game.MouseClick += Panel_game_MouseClick;
            panel_game.Paint += Panel_game_Paint;
            button_Kill_All.Click += Button_Kill_All_Click;
           
            Timer timer_move = new Timer();
            timer_move.Tick += Timer_move_Tick;
            timer_move.Interval = 50;
            timer_move.Start();

            Timer timer_life = new Timer();
            timer_life.Tick += Timer_life_Tick;
            timer_life.Interval = 1000;
            timer_life.Start();

            Timer timer_child = new Timer();
            timer_child.Tick += Timer_child_Tick;
            timer_child.Interval = 5000;
            timer_child.Start();

            Timer timer_food = new Timer();
            timer_food.Tick += Timer_food_Tick;
            timer_food.Interval = 100;
            timer_food.Start();

        }

        private void Timer_child_Tick(object sender, EventArgs e) => control.Get_child();
        private void Timer_food_Tick(object sender, EventArgs e) => control.Serch_Food();

        private void Button_Kill_All_Click(object sender, EventArgs e) => control.Kill_All();    
        private  void Timer_life_Tick(object sender, EventArgs e) => control.Old();     
        private  void Timer_move_Tick(object sender, EventArgs e)
        {
            panel_game.Refresh();
            control.Mowe(panel_game.PointToScreen(panel_game.Location), panel_game.Size);
        }
        private void Panel_game_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                control.Create_genom(panel_color.BackColor, panel_game.PointToClient(Cursor.Position));
            if (e.Button == MouseButtons.Right)
                control.Get_Cell_Info(panel_game.PointToClient(Cursor.Position));
            if (e.Button == MouseButtons.Middle)
                Cell_Genome.foods.Add(new Food(panel_game.PointToClient(Cursor.Position)));
        }
        private void Panel_game_Paint(object sender, PaintEventArgs e)
        {
            /*Point p;
            for (int i = 0; i < ClientSize.Height; i++)
            {
                for (int j = 0; j < ClientSize.Width; j++)
                {
                    p = new Point(i, j);
                    var C = Cell_Genome.cells_genom.Find(q => q.location == p);
                    try
                    {
                        Brash_life.Color = C.color_leve;
                        Brash_die.Color = C.color_died;
                        e.Graphics.FillEllipse(C.Age < C.time_life - 2 ? Brash_life : Brash_die, new Rectangle(C.location, C.size));
                    }
                    catch (Exception) { }
                }
            }*/
            foreach (Cell cell in Cell_Genome.cells_genom)
            {
                Brash_life.Color = cell.color_leve;
                Brash_die.Color = cell.color_died;
                e.Graphics.FillEllipse(cell.Age < cell.time_life - 2 ? Brash_life : Brash_die, new Rectangle(cell.location, cell.size));
            }

            foreach (Food eat in Cell_Genome.foods)
            {
                e.Graphics.FillEllipse(Brash_foot, new Rectangle(eat.location, eat.size));
            }

        }   
        private void Button_color_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            { panel_color.BackColor = dialog.Color; Brash_life.Color = dialog.Color; }
            GC.Collect(GC.GetGeneration(dialog));
        }
    }
}
