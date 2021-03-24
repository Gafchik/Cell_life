
namespace Cell_life
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_game = new System.Windows.Forms.Panel();
            this.panel_config = new System.Windows.Forms.Panel();
            this.button_color = new System.Windows.Forms.Button();
            this.label_color = new System.Windows.Forms.Label();
            this.panel_color = new System.Windows.Forms.Panel();
            this.panel_config.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_game
            // 
            this.panel_game.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel_game.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_game.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_game.Location = new System.Drawing.Point(0, 0);
            this.panel_game.Name = "panel_game";
            this.panel_game.Size = new System.Drawing.Size(905, 407);
            this.panel_game.TabIndex = 0;
            // 
            // panel_config
            // 
            this.panel_config.BackColor = System.Drawing.Color.Silver;
            this.panel_config.Controls.Add(this.panel_color);
            this.panel_config.Controls.Add(this.label_color);
            this.panel_config.Controls.Add(this.button_color);
            this.panel_config.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_config.Location = new System.Drawing.Point(0, 0);
            this.panel_config.Name = "panel_config";
            this.panel_config.Size = new System.Drawing.Size(155, 407);
            this.panel_config.TabIndex = 1;
            // 
            // button_color
            // 
            this.button_color.Location = new System.Drawing.Point(24, 60);
            this.button_color.Name = "button_color";
            this.button_color.Size = new System.Drawing.Size(94, 48);
            this.button_color.TabIndex = 0;
            this.button_color.Text = "Выбрать цвет клеткам";
            this.button_color.UseVisualStyleBackColor = true;
            // 
            // label_color
            // 
            this.label_color.AutoSize = true;
            this.label_color.ForeColor = System.Drawing.Color.Blue;
            this.label_color.Location = new System.Drawing.Point(12, 20);
            this.label_color.Name = "label_color";
            this.label_color.Size = new System.Drawing.Size(86, 13);
            this.label_color.TabIndex = 1;
            this.label_color.Text = "Выбраный цвет";
            // 
            // panel_color
            // 
            this.panel_color.BackColor = System.Drawing.Color.Red;
            this.panel_color.Location = new System.Drawing.Point(104, 12);
            this.panel_color.Name = "panel_color";
            this.panel_color.Size = new System.Drawing.Size(33, 30);
            this.panel_color.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 407);
            this.Controls.Add(this.panel_config);
            this.Controls.Add(this.panel_game);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_config.ResumeLayout(false);
            this.panel_config.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_game;
        private System.Windows.Forms.Panel panel_config;
        private System.Windows.Forms.Panel panel_color;
        private System.Windows.Forms.Label label_color;
        private System.Windows.Forms.Button button_color;
    }
}

