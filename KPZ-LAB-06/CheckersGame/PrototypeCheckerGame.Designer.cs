namespace CheckersGame
{
    partial class PrototypeCheckerGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.UPColorCB = new System.Windows.Forms.ComboBox();
            this.DOWNColorCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(711, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose color";
            // 
            // UPColorCB
            // 
            this.UPColorCB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UPColorCB.FormattingEnabled = true;
            this.UPColorCB.Items.AddRange(new object[] {
            "White",
            "Yellow"});
            this.UPColorCB.Location = new System.Drawing.Point(597, 89);
            this.UPColorCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UPColorCB.Name = "UPColorCB";
            this.UPColorCB.Size = new System.Drawing.Size(160, 37);
            this.UPColorCB.TabIndex = 2;
            this.UPColorCB.SelectedIndexChanged += new System.EventHandler(this.UPColorCB_SelectedIndexChanged);
            // 
            // DOWNColorCB
            // 
            this.DOWNColorCB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DOWNColorCB.FormattingEnabled = true;
            this.DOWNColorCB.Items.AddRange(new object[] {
            "Black",
            "Blue"});
            this.DOWNColorCB.Location = new System.Drawing.Point(803, 89);
            this.DOWNColorCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DOWNColorCB.Name = "DOWNColorCB";
            this.DOWNColorCB.Size = new System.Drawing.Size(160, 37);
            this.DOWNColorCB.TabIndex = 3;
            // 
            // PrototypeCheckerGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 496);
            this.Controls.Add(this.DOWNColorCB);
            this.Controls.Add(this.UPColorCB);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PrototypeCheckerGame";
            this.Text = "Checkers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox UPColorCB;
        private System.Windows.Forms.ComboBox DOWNColorCB;
    }
}

