using Cell_life.Cell_Model;
using Cell_life.Cell_Model.Cell_Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_life.Cell_View
{
    public partial class Form_InfoCell : Form
    {        
        Cell This_cell;
        Color color;
        public Form_InfoCell()
        {
            InitializeComponent();
        }

        public Form_InfoCell( Cell cell)
        {
            InitializeComponent();
            This_cell = cell;
            color = cell.color_leve;

            // Id_Parent_textBox
            Time_to_Dead_textBox.Text = This_cell.time_to_death.ToString();
            Cout_Child_textBox.Text = This_cell.id_childs.Count.ToString();
            This_cell.id_childs.ForEach(i => Id_Child_textBox.Text += i.ToString() + " ");
            //Eat_textBox
            color_textBox.Text = $"R : {color.R}\tG : {color.G}\tB : {color.B}";          
            time_live_textBox.Text = This_cell.time_life.ToString();
            Id_textBox.Text = This_cell.id.ToString();


            button_KILL.Click += Button_KILL_Click;
            button_Eat.Click += Button_Eat_Click;
            button_Child.Click += Button_Child_Click;


            Timer timer_up_data = new Timer();
            timer_up_data.Tick += Timer_up_data_Tick;
            timer_up_data.Interval = 100;
            timer_up_data.Start();

        }

        private void Button_Child_Click(object sender, EventArgs e) => This_cell.Get_Child();
       


        private void Button_Eat_Click(object sender, EventArgs e) => This_cell.Feed();
       

        private void Button_KILL_Click(object sender, EventArgs e) => This_cell.Die();
       

        private void Timer_up_data_Tick(object sender, EventArgs e)
        {
            // Id_Parent_textBox
            Time_to_Dead_textBox.Text = This_cell.time_to_death.ToString();
            Cout_Child_textBox.Text = This_cell.id_childs.Count.ToString();
            Id_Child_textBox.Text = "";
            This_cell.id_childs.ForEach(i => Id_Child_textBox.Text += i.ToString() + " ");
            HP_textBox.Text = This_cell.HP.ToString();
            color_textBox.Text = $"R : {color.R}\tG : {color.G}\tB : {color.B}";
            time_live_textBox.Text = This_cell.time_life.ToString();
            Id_textBox.Text = This_cell.id.ToString();
        }
    }
}
