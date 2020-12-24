namespace lab_oop_7
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
            this.paint_box = new System.Windows.Forms.Panel();
            this.button_del__item_storage = new System.Windows.Forms.Button();
            this.drawellipse = new System.Windows.Forms.Button();
            this.drawline = new System.Windows.Forms.Button();
            this.button_color = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button_group = new System.Windows.Forms.Button();
            this.button_ungroup = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // paint_box
            // 
            this.paint_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paint_box.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.paint_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paint_box.Location = new System.Drawing.Point(12, 12);
            this.paint_box.Name = "paint_box";
            this.paint_box.Size = new System.Drawing.Size(675, 426);
            this.paint_box.TabIndex = 1;
            this.paint_box.MouseClick += new System.Windows.Forms.MouseEventHandler(this.paint_box_MouseClick);
            // 
            // button_del__item_storage
            // 
            this.button_del__item_storage.Location = new System.Drawing.Point(693, 12);
            this.button_del__item_storage.Name = "button_del__item_storage";
            this.button_del__item_storage.Size = new System.Drawing.Size(102, 23);
            this.button_del__item_storage.TabIndex = 4;
            this.button_del__item_storage.Text = "Удалить";
            this.button_del__item_storage.UseVisualStyleBackColor = true;
            this.button_del__item_storage.Click += new System.EventHandler(this.button_del__item_storage_Click);
            this.button_del__item_storage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // drawellipse
            // 
            this.drawellipse.Location = new System.Drawing.Point(693, 41);
            this.drawellipse.Name = "drawellipse";
            this.drawellipse.Size = new System.Drawing.Size(102, 23);
            this.drawellipse.TabIndex = 6;
            this.drawellipse.Text = "Круг";
            this.drawellipse.UseVisualStyleBackColor = true;
            this.drawellipse.Click += new System.EventHandler(this.drawellipse_Click);
            this.drawellipse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // drawline
            // 
            this.drawline.Location = new System.Drawing.Point(693, 70);
            this.drawline.Name = "drawline";
            this.drawline.Size = new System.Drawing.Size(102, 23);
            this.drawline.TabIndex = 7;
            this.drawline.Text = "Линия";
            this.drawline.UseVisualStyleBackColor = true;
            this.drawline.Click += new System.EventHandler(this.drawline_Click);
            this.drawline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // button_color
            // 
            this.button_color.Location = new System.Drawing.Point(693, 99);
            this.button_color.Name = "button_color";
            this.button_color.Size = new System.Drawing.Size(102, 23);
            this.button_color.TabIndex = 10;
            this.button_color.Text = "Цвет";
            this.button_color.UseVisualStyleBackColor = true;
            this.button_color.Click += new System.EventHandler(this.button_color_Click);
            this.button_color.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.White;
            // 
            // button_group
            // 
            this.button_group.Location = new System.Drawing.Point(693, 128);
            this.button_group.Name = "button_group";
            this.button_group.Size = new System.Drawing.Size(102, 23);
            this.button_group.TabIndex = 11;
            this.button_group.Text = "Группировка";
            this.button_group.UseVisualStyleBackColor = true;
            this.button_group.Click += new System.EventHandler(this.button_group_Click);
            this.button_group.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // button_ungroup
            // 
            this.button_ungroup.Location = new System.Drawing.Point(693, 157);
            this.button_ungroup.Name = "button_ungroup";
            this.button_ungroup.Size = new System.Drawing.Size(102, 23);
            this.button_ungroup.TabIndex = 12;
            this.button_ungroup.Text = "Разгруппировка";
            this.button_ungroup.UseVisualStyleBackColor = true;
            this.button_ungroup.Click += new System.EventHandler(this.button_ungroup_Click);
            this.button_ungroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(693, 186);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(102, 23);
            this.button_save.TabIndex = 13;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            this.button_save.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(693, 215);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(102, 23);
            this.button_load.TabIndex = 14;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            this.button_load.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 450);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_ungroup);
            this.Controls.Add(this.button_group);
            this.Controls.Add(this.button_color);
            this.Controls.Add(this.drawline);
            this.Controls.Add(this.drawellipse);
            this.Controls.Add(this.button_del__item_storage);
            this.Controls.Add(this.paint_box);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paint_box;
        private System.Windows.Forms.Button button_del__item_storage;
        private System.Windows.Forms.Button drawellipse;
        private System.Windows.Forms.Button drawline;
        private System.Windows.Forms.Button button_color;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_group;
        private System.Windows.Forms.Button button_ungroup;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_load;
    }
}

