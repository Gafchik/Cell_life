
namespace Cell_life.Cell_View
{
    partial class Form_InfoCell
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_data = new System.Windows.Forms.Panel();
            this.Time_to_Dead_textBox = new System.Windows.Forms.TextBox();
            this.Cout_Child_textBox = new System.Windows.Forms.TextBox();
            this.Id_Child_textBox = new System.Windows.Forms.TextBox();
            this.color_textBox = new System.Windows.Forms.TextBox();
            this.time_live_textBox = new System.Windows.Forms.TextBox();
            this.Id_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_KILL = new System.Windows.Forms.Button();
            this.button_Eat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_Child = new System.Windows.Forms.Button();
            this.HP_Bar = new System.Windows.Forms.ProgressBar();
            this.panel_data.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_data
            // 
            this.panel_data.Controls.Add(this.HP_Bar);
            this.panel_data.Controls.Add(this.Time_to_Dead_textBox);
            this.panel_data.Controls.Add(this.Cout_Child_textBox);
            this.panel_data.Controls.Add(this.Id_Child_textBox);
            this.panel_data.Controls.Add(this.color_textBox);
            this.panel_data.Controls.Add(this.time_live_textBox);
            this.panel_data.Controls.Add(this.Id_textBox);
            this.panel_data.Location = new System.Drawing.Point(150, 12);
            this.panel_data.Name = "panel_data";
            this.panel_data.Size = new System.Drawing.Size(189, 280);
            this.panel_data.TabIndex = 36;
            // 
            // Time_to_Dead_textBox
            // 
            this.Time_to_Dead_textBox.Location = new System.Drawing.Point(15, 123);
            this.Time_to_Dead_textBox.Name = "Time_to_Dead_textBox";
            this.Time_to_Dead_textBox.ReadOnly = true;
            this.Time_to_Dead_textBox.Size = new System.Drawing.Size(152, 20);
            this.Time_to_Dead_textBox.TabIndex = 22;
            this.Time_to_Dead_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Cout_Child_textBox
            // 
            this.Cout_Child_textBox.Location = new System.Drawing.Point(15, 154);
            this.Cout_Child_textBox.Name = "Cout_Child_textBox";
            this.Cout_Child_textBox.ReadOnly = true;
            this.Cout_Child_textBox.Size = new System.Drawing.Size(152, 20);
            this.Cout_Child_textBox.TabIndex = 37;
            this.Cout_Child_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Id_Child_textBox
            // 
            this.Id_Child_textBox.Location = new System.Drawing.Point(15, 190);
            this.Id_Child_textBox.Multiline = true;
            this.Id_Child_textBox.Name = "Id_Child_textBox";
            this.Id_Child_textBox.ReadOnly = true;
            this.Id_Child_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Id_Child_textBox.Size = new System.Drawing.Size(152, 76);
            this.Id_Child_textBox.TabIndex = 21;
            // 
            // color_textBox
            // 
            this.color_textBox.Location = new System.Drawing.Point(15, 71);
            this.color_textBox.Name = "color_textBox";
            this.color_textBox.ReadOnly = true;
            this.color_textBox.Size = new System.Drawing.Size(152, 20);
            this.color_textBox.TabIndex = 18;
            this.color_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // time_live_textBox
            // 
            this.time_live_textBox.Location = new System.Drawing.Point(15, 45);
            this.time_live_textBox.Name = "time_live_textBox";
            this.time_live_textBox.ReadOnly = true;
            this.time_live_textBox.Size = new System.Drawing.Size(152, 20);
            this.time_live_textBox.TabIndex = 16;
            this.time_live_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Id_textBox
            // 
            this.Id_textBox.Location = new System.Drawing.Point(15, 19);
            this.Id_textBox.Name = "Id_textBox";
            this.Id_textBox.ReadOnly = true;
            this.Id_textBox.Size = new System.Drawing.Size(152, 20);
            this.Id_textBox.TabIndex = 15;
            this.Id_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(12, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Id каждого из потомков";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(14, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Время до смерти";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(16, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "HP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(16, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Цвет поколения ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Время жизни клетки";
            // 
            // button_KILL
            // 
            this.button_KILL.BackColor = System.Drawing.Color.Red;
            this.button_KILL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_KILL.Location = new System.Drawing.Point(256, 311);
            this.button_KILL.Name = "button_KILL";
            this.button_KILL.Size = new System.Drawing.Size(94, 43);
            this.button_KILL.TabIndex = 29;
            this.button_KILL.Text = "KILL";
            this.button_KILL.UseVisualStyleBackColor = false;
            // 
            // button_Eat
            // 
            this.button_Eat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button_Eat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Eat.Location = new System.Drawing.Point(35, 311);
            this.button_Eat.Name = "button_Eat";
            this.button_Eat.Size = new System.Drawing.Size(94, 43);
            this.button_Eat.TabIndex = 28;
            this.button_Eat.Text = "Кормить";
            this.button_Eat.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Id Клетки";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(14, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Количество потомков";
            // 
            // button_Child
            // 
            this.button_Child.BackColor = System.Drawing.Color.Magenta;
            this.button_Child.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Child.Location = new System.Drawing.Point(146, 311);
            this.button_Child.Name = "button_Child";
            this.button_Child.Size = new System.Drawing.Size(94, 43);
            this.button_Child.TabIndex = 40;
            this.button_Child.Text = "Сделать детей";
            this.button_Child.UseVisualStyleBackColor = false;
            // 
            // HP_Bar
            // 
            this.HP_Bar.Location = new System.Drawing.Point(15, 100);
            this.HP_Bar.Name = "HP_Bar";
            this.HP_Bar.Size = new System.Drawing.Size(152, 17);
            this.HP_Bar.TabIndex = 38;
            // 
            // Form_InfoCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 363);
            this.Controls.Add(this.button_Child);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel_data);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_KILL);
            this.Controls.Add(this.button_Eat);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form_InfoCell";
            this.Text = "Form_InfoCell";
            this.panel_data.ResumeLayout(false);
            this.panel_data.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.TextBox Time_to_Dead_textBox;
        private System.Windows.Forms.TextBox Cout_Child_textBox;
        private System.Windows.Forms.TextBox Id_Child_textBox;
        private System.Windows.Forms.TextBox color_textBox;
        private System.Windows.Forms.TextBox time_live_textBox;
        private System.Windows.Forms.TextBox Id_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_KILL;
        private System.Windows.Forms.Button button_Eat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Child;
        private System.Windows.Forms.ProgressBar HP_Bar;
    }
}