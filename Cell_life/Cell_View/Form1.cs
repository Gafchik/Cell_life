using Cell_life.Cell_Control;
using Cell_life.Cell_Model;
using Cell_life.Cell_Model.Cell_Base;
using Cell_life.Model.Eat_Model;
using Cell_life.Model.Game_Model;
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
      
        readonly Pen pen_life;
        readonly Pen pen_die;
        Cell_Conrol control;

        public Form1()
        {
            InitializeComponent();
            panel_color.BackColor = Color.Black;
            control = new Cell_Conrol();
            button_color.Click += Button_color_Click;
            DoubleBuffered = true;
            pen_life = new Pen(panel_color.BackColor,3);
            pen_die = new Pen(Color.Red,3);
            panel_game.MouseClick += Panel_game_MouseClick;
            panel_game.Paint += Panel_game_Paint;
            button_Kill_All.Click += Button_Kill_All_Click;
           
            Timer timer_move = new Timer();
            timer_move.Tick += Timer_move_Tick;
            timer_move.Interval = 100;
            timer_move.Start();

            Timer timer_life = new Timer();
            timer_life.Tick += Timer_life_Tick;
            timer_life.Interval = 1000;
            timer_life.Start();

            Timer timer_child = new Timer();
            timer_child.Tick += Timer_child_Tick;
            timer_child.Interval = 2000;
            timer_child.Start();



        }

        private void Timer_child_Tick(object sender, EventArgs e) => control.Get_child();
        
        private void Button_Kill_All_Click(object sender, EventArgs e) => control.Kill_All();    
        private  void Timer_life_Tick(object sender, EventArgs e) => control.Old();     
        private void Timer_move_Tick(object sender, EventArgs e)
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
        }
        private void Panel_game_Paint(object sender, PaintEventArgs e)
        {
            foreach (Cell_Genome genome in Game_elements.genus)
            {
                foreach (Cell cell in genome.cells_genom)
                {                  
                    pen_life.Color = cell.color_leve;
                    pen_die.Color = cell.color_died;
                    e.Graphics.DrawRectangle(cell.Age < cell.time_life - 2 ?new Pen( cell.color_leve,5) : new Pen(cell.color_died,5), new Rectangle(cell.location, cell.size));
                }
            }
            foreach (Eat eat in Game_elements.eats)
            {
                e.Graphics.DrawEllipse(new Pen(eat.color_leve,5),new Rectangle(eat.location, eat.size));
            }

        }   
        private void Button_color_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            { panel_color.BackColor = dialog.Color; pen_life.Color = dialog.Color; }
            GC.Collect(GC.GetGeneration(dialog));
        }
    }
}
