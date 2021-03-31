
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
            this.button_pause = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.Color_Box = new System.Windows.Forms.ComboBox();
            this.label_color = new System.Windows.Forms.Label();
            this.checkBox_fight = new System.Windows.Forms.CheckBox();
            this.panel_config.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_game
            // 
            this.panel_game.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_game.AutoSize = true;
            this.panel_game.BackColor = System.Drawing.Color.White;
            this.panel_game.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_game.Location = new System.Drawing.Point(0, 0);
            this.panel_game.Name = "panel_game";
            this.panel_game.Size = new System.Drawing.Size(1184, 561);
            this.panel_game.TabIndex = 0;
            // 
            // panel_config
            // 
            this.panel_config.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_config.AutoSize = true;
            this.panel_config.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel_config.Controls.Add(this.checkBox_fight);
            this.panel_config.Controls.Add(this.button_pause);
            this.panel_config.Controls.Add(this.button_start);
            this.panel_config.Controls.Add(this.button_stop);
            this.panel_config.Controls.Add(this.Color_Box);
            this.panel_config.Controls.Add(this.label_color);
            this.panel_config.Location = new System.Drawing.Point(0, 0);
            this.panel_config.Name = "panel_config";
            this.panel_config.Size = new System.Drawing.Size(155, 561);
            this.panel_config.TabIndex = 1;
            // 
            // button_pause
            // 
            this.button_pause.BackColor = System.Drawing.Color.Yellow;
            this.button_pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_pause.Location = new System.Drawing.Point(24, 210);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(94, 48);
            this.button_pause.TabIndex = 7;
            this.button_pause.Text = "Пауза";
            this.button_pause.UseVisualStyleBackColor = false;
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.Location = new System.Drawing.Point(24, 140);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(94, 48);
            this.button_start.TabIndex = 6;
            this.button_start.Text = "Старт";
            this.button_start.UseVisualStyleBackColor = false;
            // 
            // button_stop
            // 
            this.button_stop.BackColor = System.Drawing.Color.Red;
            this.button_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_stop.Location = new System.Drawing.Point(24, 279);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(94, 48);
            this.button_stop.TabIndex = 5;
            this.button_stop.Text = "Стоп";
            this.button_stop.UseVisualStyleBackColor = false;
            // 
            // Color_Box
            // 
            this.Color_Box.FormattingEnabled = true;
            this.Color_Box.Location = new System.Drawing.Point(12, 47);
            this.Color_Box.Name = "Color_Box";
            this.Color_Box.Size = new System.Drawing.Size(121, 21);
            this.Color_Box.TabIndex = 4;
            // 
            // label_color
            // 
            this.label_color.AutoSize = true;
            this.label_color.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_color.ForeColor = System.Drawing.Color.Blue;
            this.label_color.Location = new System.Drawing.Point(21, 18);
            this.label_color.Name = "label_color";
            this.label_color.Size = new System.Drawing.Size(99, 13);
            this.label_color.TabIndex = 1;
            this.label_color.Text = "Выбраный цвет";
            // 
            // checkBox_fight
            // 
            this.checkBox_fight.AutoSize = true;
            this.checkBox_fight.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_fight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_fight.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_fight.Location = new System.Drawing.Point(5, 95);
            this.checkBox_fight.Name = "checkBox_fight";
            this.checkBox_fight.Size = new System.Drawing.Size(136, 17);
            this.checkBox_fight.TabIndex = 8;
            this.checkBox_fight.Text = "Разрешить дратся";
            this.checkBox_fight.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.panel_config);
            this.Controls.Add(this.panel_game);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel_config.ResumeLayout(false);
            this.panel_config.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_game;
        private System.Windows.Forms.Panel panel_config;
        private System.Windows.Forms.Label label_color;
        private System.Windows.Forms.ComboBox Color_Box;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.CheckBox checkBox_fight;
    }
}

