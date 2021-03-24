using Cell_life.Cell_Control;
using Cell_life.Cell_Model;
using Cell_life.Cell_Model.Cell_Base;
using Cell_life.Model.Game_Model;
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
            panel_color.BackColor = Color.Green;
            control = new Cell_Conrol();
            button_color.Click += Button_color_Click;
            DoubleBuffered = true;
            pen_life = new Pen(panel_color.BackColor,3);
            pen_die = new Pen(Color.Red,3);
            panel_game.MouseClick += Panel_game_MouseClick;
            panel_game.Paint += Panel_game_Paint;

            Timer timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 100;
            timer.Start();


            
        }

       

        private void Timer_Tick(object sender, EventArgs e)
        {
            panel_game.Refresh();
            control.Old();
            control.Mowe();
            control.Get_child();

        }

        private void Panel_game_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { }
            control.Create_genom(panel_color.BackColor, panel_game.PointToClient(MousePosition));
        }

        private void Panel_game_Paint(object sender, PaintEventArgs e)// => Cell_Genoms.genus.ForEach(i => i.cells_genom.ForEach(q => e.Graphics.DrawRectangle(q.Age < q.time_life - 1 ? (myPen.Color = q.color_leve) : diePen, new Rectangle(q.location, q.size))));
        {
            foreach (Cell_Genome genome in Cell_Genoms.genus)
            {
                foreach (Cell cell in genome.cells_genom)
                {
                    pen_life.Color = cell.color_leve;
                    pen_die.Color = cell.color_died;
                    e.Graphics.DrawRectangle(cell.Age < cell.time_life - 20 ? pen_life : pen_die, new Rectangle(cell.location, cell.size));
                }
            }
        }

     

        private void Button_color_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            { panel_color.BackColor = dialog.Color; pen_life.Color = dialog.Color; }
        }
    }
}
