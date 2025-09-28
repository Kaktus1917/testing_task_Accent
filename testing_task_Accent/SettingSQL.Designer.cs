namespace testing_task_Accent
{
    partial class SettingSQL
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
            this.saveSettingSQLbut = new System.Windows.Forms.Button();
            this.ServerDBtb = new System.Windows.Forms.TextBox();
            this.NameDBtb = new System.Windows.Forms.TextBox();
            this.NameUsertb = new System.Windows.Forms.TextBox();
            this.PasswordUsertb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // saveSettingSQLbut
            // 
            this.saveSettingSQLbut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSettingSQLbut.Location = new System.Drawing.Point(146, 324);
            this.saveSettingSQLbut.MaximumSize = new System.Drawing.Size(300, 40);
            this.saveSettingSQLbut.MinimumSize = new System.Drawing.Size(259, 40);
            this.saveSettingSQLbut.Name = "saveSettingSQLbut";
            this.saveSettingSQLbut.Size = new System.Drawing.Size(259, 40);
            this.saveSettingSQLbut.TabIndex = 0;
            this.saveSettingSQLbut.Text = "Сохранить и войти";
            this.saveSettingSQLbut.UseVisualStyleBackColor = true;
            this.saveSettingSQLbut.Click += new System.EventHandler(this.buttonSaveSettingConnecSQL_Click);
            // 
            // ServerDBtb
            // 
            this.ServerDBtb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerDBtb.Location = new System.Drawing.Point(146, 149);
            this.ServerDBtb.MaximumSize = new System.Drawing.Size(300, 22);
            this.ServerDBtb.MinimumSize = new System.Drawing.Size(259, 22);
            this.ServerDBtb.Name = "ServerDBtb";
            this.ServerDBtb.Size = new System.Drawing.Size(259, 22);
            this.ServerDBtb.TabIndex = 1;
            // 
            // NameDBtb
            // 
            this.NameDBtb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameDBtb.Location = new System.Drawing.Point(146, 192);
            this.NameDBtb.MaximumSize = new System.Drawing.Size(300, 22);
            this.NameDBtb.MinimumSize = new System.Drawing.Size(259, 22);
            this.NameDBtb.Name = "NameDBtb";
            this.NameDBtb.Size = new System.Drawing.Size(259, 22);
            this.NameDBtb.TabIndex = 2;
            // 
            // NameUsertb
            // 
            this.NameUsertb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameUsertb.Location = new System.Drawing.Point(146, 235);
            this.NameUsertb.MaximumSize = new System.Drawing.Size(300, 22);
            this.NameUsertb.MinimumSize = new System.Drawing.Size(259, 22);
            this.NameUsertb.Name = "NameUsertb";
            this.NameUsertb.Size = new System.Drawing.Size(259, 22);
            this.NameUsertb.TabIndex = 3;
            // 
            // PasswordUsertb
            // 
            this.PasswordUsertb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordUsertb.Location = new System.Drawing.Point(146, 276);
            this.PasswordUsertb.MaximumSize = new System.Drawing.Size(300, 22);
            this.PasswordUsertb.MinimumSize = new System.Drawing.Size(259, 22);
            this.PasswordUsertb.Name = "PasswordUsertb";
            this.PasswordUsertb.Size = new System.Drawing.Size(259, 22);
            this.PasswordUsertb.TabIndex = 4;
            this.PasswordUsertb.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Настройки подключения к БД";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Сервер базы данных";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Имя базы данных";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Имя пользователя";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Пароль";
            // 
            // SettingSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 458);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordUsertb);
            this.Controls.Add(this.NameUsertb);
            this.Controls.Add(this.NameDBtb);
            this.Controls.Add(this.ServerDBtb);
            this.Controls.Add(this.saveSettingSQLbut);
            this.Name = "SettingSQL";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveSettingSQLbut;
        private System.Windows.Forms.TextBox ServerDBtb;
        private System.Windows.Forms.TextBox NameDBtb;
        private System.Windows.Forms.TextBox NameUsertb;
        private System.Windows.Forms.TextBox PasswordUsertb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

