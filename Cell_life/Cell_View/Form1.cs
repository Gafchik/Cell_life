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
using System.Reflection;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Cell_life
{
    public partial class Form1 : Form
    {
      
        System.Drawing.Color r_color;
        System.Drawing.Color color_paint;
        private SolidBrush Brash_life;
        Random r;
        private SolidBrush Brash_foot;      
        Cell_Conrol control;

        public Form1()
        {
            InitializeComponent();


            r = new Random();
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
            timer_FPS.Interval = 50;
            timer_FPS.Start();


            System.Windows.Forms.Timer timer_leave = new System.Windows.Forms.Timer();
            timer_leave.Tick += Timer_leave_Tick;
            timer_leave.Interval = 1000;
            Text = $"Пройденое время : {Cell_Conrol.time_game}";

            control = new Cell_Conrol(panel_game.PointToScreen(panel_game.Location), panel_game.Size, timer_move, timer_leave);
            checkBox_fight.CheckState = CheckState.Unchecked;
            checkBox_fight.CheckedChanged += CheckBox_fight_CheckedChanged;

            checkBox_autoFood.CheckState = CheckState.Unchecked;
            checkBox_autoFood.CheckedChanged += CheckBox_autoFood_CheckedChanged;

            checkBox_Child.CheckState = CheckState.Unchecked;
            checkBox_Child.CheckedChanged += CheckBox_Child_CheckedChanged;
        }

        private void CheckBox_Child_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox t = (sender as CheckBox);
            if (t.CheckState == CheckState.Checked)
                Cell_Conrol.is_child = true;
            if (t.CheckState == CheckState.Unchecked)
                Cell_Conrol.is_child = false;
        }

        private void CheckBox_autoFood_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox t = (sender as CheckBox);
            if (t.CheckState == CheckState.Checked)
                Cell_Conrol.is_food = true;
            if (t.CheckState == CheckState.Unchecked)
                Cell_Conrol.is_food = false;
        }

        private void CheckBox_fight_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox t = (sender as CheckBox);
            if (t.CheckState == CheckState.Checked)
                Cell_Conrol.is_fight = true;
            if (t.CheckState == CheckState.Unchecked)
                Cell_Conrol.is_fight = false;
        }
        

        private void Timer_FPS_Tick(object sender, EventArgs e) => panel_game.Refresh();

        private void Form1_Load(object sender, EventArgs e)
        {
            panel_game.BackColor = System.Drawing.Color.Gray;          
            r_color = Color.FromKnownColor((KnownColor)r.Next(0, typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                         .Select(c => (Color)c.GetValue(null, null))
                         .ToList().Count));
            MessageBox.Show("Рандомный цвет не остановить\nон так и будет менятся","Прочти Дибил",MessageBoxButtons.OK,MessageBoxIcon.Information);



            Color_Box.Items.AddRange(new string[] { "Черный", "Красный", "Зеленый", "Синий", $"{r_color}" }); ;
            Color_Box.SelectedIndex = 0;
            switch (Color_Box.SelectedItem.ToString())
            {
                case "Черный":
                    color_paint = System.Drawing.Color.Black;
                    break;
                case "Красный":
                    color_paint = System.Drawing.Color.Red;
                    break;
                case "Зеленый":
                    color_paint = System.Drawing.Color.Green;
                    break;
                case "Синий":
                    color_paint = System.Drawing.Color.Blue;
                    break;            
                default:
                    color_paint = r_color;
                    break;
            }
            Color_Box.SelectedIndexChanged += Color_Box_SelectedIndexChanged;
            Brash_life = new SolidBrush(color_paint);
            Brash_foot = new SolidBrush(System.Drawing.Color.Orange);
        }

        private void Color_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            r_color = Color.FromKnownColor((KnownColor)r.Next(0, typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                         .Select(c => (Color)c.GetValue(null, null))
                         .ToList().Count));
            switch (Color_Box.SelectedItem.ToString())
            {
                case "Черный":
                    color_paint = System.Drawing.Color.Black;
                    break;
                case "Красный":
                    color_paint = System.Drawing.Color.Red;
                    break;
                case "Зеленый":
                    color_paint = System.Drawing.Color.Green;
                    break;
                case "Синий":
                    color_paint = System.Drawing.Color.Blue;
                    break;
                default:
                    color_paint = r_color;
                    break;
            }
        }

        private void Button_start_Click(object sender, EventArgs e) => control.Start();
        private void Button_pause_Click(object sender, EventArgs e) => control.Pause();
        private void button_stop_Click(object sender, EventArgs e) => control.Stop();
        private void Timer_leave_Tick(object sender, EventArgs e)
        {
           
            Text = $"Пройденое время : {Cell_Conrol.time_game}";
            control.Old();
        }
        private void Timer_move_Tick(object sender, EventArgs e)
        {
            lock (this) 
            { 
                control.Mowe(panel_game.PointToScreen(panel_game.Location), panel_game.Size);
                color_paint = Color.FromKnownColor((KnownColor)r.Next(0, typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                            .Select(c => (Color)c.GetValue(null, null))
                            .ToList().Count));
                Color_Box.Items[4] = color_paint.ToString();
            } }
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
