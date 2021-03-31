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
            color = cell.color;

            damag_textBox.Text = This_cell.damage.ToString();
            Cout_Child_textBox.Text = This_cell.id_childs.Count.ToString();
            Id_Child_textBox.Text = "";
            This_cell.id_childs.ForEach(i => Id_Child_textBox.Text += i.ToString() + " ");
            color_textBox.Text = color.ToString();
            eat_food_textBox.Text = This_cell.count_food.ToString();
            Id_textBox.Text = This_cell.id.ToString();


            button_KILL.Click += Button_KILL_Click;
            button_Eat.Click += Button_Eat_Click;
            button_Child.Click += Button_Child_Click;

          
            try { HP_Bar.Value = This_cell.HP; } catch (Exception) { HP_Bar.Value = 0; }
            HP_Bar.Maximum = This_cell.Max_HP;
            HP_Bar.Minimum = 0;

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
           
            damag_textBox.Text = This_cell.damage.ToString();
            Cout_Child_textBox.Text = This_cell.id_childs.Count.ToString();
            Id_Child_textBox.Text = "";
            This_cell.id_childs.ForEach(i => Id_Child_textBox.Text += i.ToString() + " ");
            color_textBox.Text = color.ToString();
            eat_food_textBox.Text = This_cell.count_food.ToString();
            Id_textBox.Text = This_cell.id.ToString();
            HP_Bar.Maximum = This_cell.Max_HP;          
            try { HP_Bar.Value = This_cell.HP; } catch (Exception) { HP_Bar.Value = 0; }
            if (HP_Bar.Value < HP_Bar.Maximum / 2)
                HP_Bar.ForeColor = Color.Orange;
        }

      

      
    }
}
