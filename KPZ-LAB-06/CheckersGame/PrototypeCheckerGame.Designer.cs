﻿namespace CheckersGame
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
            this.label2 = new System.Windows.Forms.Label();
            this.UpperLabel = new System.Windows.Forms.Label();
            this.LowerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 23);
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
            this.UPColorCB.Location = new System.Drawing.Point(140, 416);
            this.UPColorCB.Name = "UPColorCB";
            this.UPColorCB.Size = new System.Drawing.Size(121, 31);
            this.UPColorCB.TabIndex = 2;
            // 
            // DOWNColorCB
            // 
            this.DOWNColorCB.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DOWNColorCB.FormattingEnabled = true;
            this.DOWNColorCB.Items.AddRange(new object[] {
            "Black",
            "Blue"});
            this.DOWNColorCB.Location = new System.Drawing.Point(276, 416);
            this.DOWNColorCB.Name = "DOWNColorCB";
            this.DOWNColorCB.Size = new System.Drawing.Size(121, 31);
            this.DOWNColorCB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(497, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Сheckers retraction:";
            // 
            // UpperLabel
            // 
            this.UpperLabel.AutoSize = true;
            this.UpperLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpperLabel.Location = new System.Drawing.Point(448, 60);
            this.UpperLabel.Name = "UpperLabel";
            this.UpperLabel.Size = new System.Drawing.Size(111, 23);
            this.UpperLabel.TabIndex = 5;
            this.UpperLabel.Text = "Player 1: 12";
            // 
            // LowerLabel
            // 
            this.LowerLabel.AutoSize = true;
            this.LowerLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LowerLabel.Location = new System.Drawing.Point(610, 60);
            this.LowerLabel.Name = "LowerLabel";
            this.LowerLabel.Size = new System.Drawing.Size(111, 23);
            this.LowerLabel.TabIndex = 6;
            this.LowerLabel.Text = "Player 2: 12";
            // 
            // PrototypeCheckerGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 464);
            this.Controls.Add(this.LowerLabel);
            this.Controls.Add(this.UpperLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DOWNColorCB);
            this.Controls.Add(this.UPColorCB);
            this.Controls.Add(this.label1);
            this.Name = "PrototypeCheckerGame";
            this.Text = "Checkers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox UPColorCB;
        private System.Windows.Forms.ComboBox DOWNColorCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UpperLabel;
        private System.Windows.Forms.Label LowerLabel;
    }
}

