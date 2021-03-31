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
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_life
{
    public partial class Form1 : Form
    {
        //Dispatcher dispatcher;

         Color color_paint;
        private SolidBrush Brash_life;

        private SolidBrush Brash_foot;      
        Cell_Conrol control;

        public Form1()
        {
            InitializeComponent();



            DoubleBuffered = true;

            panel_game.MouseClick += Panel_game_MouseClick;
            panel_game.Paint += Panel_game_Paint;
            button_stop.Click += button_stop_Click;
            button_pause.Click += Button_pause_Click;
            button_start.Click += Button_start_Click;
            Load += Form1_Load;

            System.Windows.Forms.Timer timer_move = new  System.Windows.Forms.Timer();
            timer_move.Tick += Timer_move_Tick;
            timer_move.Interval = 100;


            System.Windows.Forms.Timer timer_FPS = new System.Windows.Forms.Timer();
            timer_FPS.Tick += Timer_FPS_Tick; ;
            timer_FPS.Interval = 100;
            timer_FPS.Start();


            System.Windows.Forms.Timer timer_leave = new System.Windows.Forms.Timer();
            timer_leave.Tick += Timer_leave_Tick;
            timer_leave.Interval = 1000;
            Text = $"Пройденое время : {Cell_Conrol.time_game}     Возможность дратся : {Cell_Conrol.fight}     Дратся с : {Cell_Conrol.fight_time}ти секунд";

            control = new Cell_Conrol(panel_game.PointToScreen(panel_game.Location), panel_game.Size, timer_move, timer_leave);

        }

        private void Timer_FPS_Tick(object sender, EventArgs e) => panel_game.Refresh();

        private void Form1_Load(object sender, EventArgs e)
        {
            Color_Box.Items.AddRange(new string[] { "Черный", "Красный", "Зеленый", "Синий" });
            Color_Box.SelectedIndex = 0;
            switch (Color_Box.SelectedItem.ToString())
            {
                case "Черный":
                    color_paint = Color.Black;
                    break;
                case "Красный":
                    color_paint = Color.Red;
                    break;
                case "Зеленый":
                    color_paint = Color.Green;
                    break;
                case "Синий":
                    color_paint = Color.Blue;
                    break;
                default:
                    break;
            }
            Color_Box.SelectedIndexChanged += Color_Box_SelectedIndexChanged;
            Brash_life = new SolidBrush(color_paint);
            Brash_foot = new SolidBrush(Color.Green);
        }

        private void Color_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Color_Box.SelectedItem.ToString())
            {
                case "Черный":
                    color_paint = Color.Black;
                    break;
                case "Красный":
                    color_paint = Color.Red;
                    break;
                case "Зеленый":
                    color_paint = Color.Green;
                    break;
                case "Синий":
                    color_paint = Color.Blue;
                    break;
                default:
                    break;
            }
        }

        private void Button_start_Click(object sender, EventArgs e) => control.Start();
        private void Button_pause_Click(object sender, EventArgs e) => control.Pause();
        private void button_stop_Click(object sender, EventArgs e) => control.Stop();
        private void Timer_leave_Tick(object sender, EventArgs e)
        {
            Text = $"Пройденое время : {Cell_Conrol.time_game}     Возможность дратся : {Cell_Conrol.fight}     Дратся с : {Cell_Conrol.fight_time}ти секунд";
            control.Old();
        }
        private void Timer_move_Tick(object sender, EventArgs e)
        { lock (this) { control.Mowe(panel_game.PointToScreen(panel_game.Location), panel_game.Size); } }
        private void Panel_game_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Cells.cells.Add(new Cell (Cells.cells.Count + 1, color_paint, panel_game.PointToClient(Cursor.Position)));
            if (e.Button == MouseButtons.Right)
                control.Get_Cell_Info(panel_game.PointToClient(Cursor.Position));
            if (e.Button == MouseButtons.Middle)
                Cells.foods.Add(new Food(panel_game.PointToClient(Cursor.Position)));
        }
        private  void Panel_game_Paint(object sender, PaintEventArgs e)
        {

            foreach (Food eat in Cells.foods)
            {
                e.Graphics.FillEllipse(Brash_foot, new Rectangle(eat.location, eat.size));
            }
            foreach (Cell cell in Cells.cells)
            {
                Brash_life.Color = cell.color;
                e.Graphics.FillEllipse(Brash_life, new Rectangle(cell.location, cell.size));
            }
           
        }     
    }
}
