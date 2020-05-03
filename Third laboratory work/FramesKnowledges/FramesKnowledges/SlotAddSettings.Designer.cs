namespace FramesKnowledges
{
    partial class SlotAddSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.slotNameText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ptrToInheritanceComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ptrToTypeComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(100, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавление слота";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя слота:";
            // 
            // slotNameText
            // 
            this.slotNameText.Location = new System.Drawing.Point(85, 33);
            this.slotNameText.Name = "slotNameText";
            this.slotNameText.Size = new System.Drawing.Size(267, 20);
            this.slotNameText.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Указатель наследования:";
            // 
            // ptrToInheritanceComboBox
            // 
            this.ptrToInheritanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ptrToInheritanceComboBox.FormattingEnabled = true;
            this.ptrToInheritanceComboBox.Items.AddRange(new object[] {
            "Unique",
            "Same"});
            this.ptrToInheritanceComboBox.Location = new System.Drawing.Point(171, 59);
            this.ptrToInheritanceComboBox.Name = "ptrToInheritanceComboBox";
            this.ptrToInheritanceComboBox.Size = new System.Drawing.Size(181, 21);
            this.ptrToInheritanceComboBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(7, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Указатель типа данных:";
            // 
            // ptrToTypeComboBox
            // 
            this.ptrToTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ptrToTypeComboBox.FormattingEnabled = true;
            this.ptrToTypeComboBox.Items.AddRange(new object[] {
            "BOOL",
            "FRAME",
            "LISP",
            "TEXT"});
            this.ptrToTypeComboBox.Location = new System.Drawing.Point(171, 86);
            this.ptrToTypeComboBox.Name = "ptrToTypeComboBox";
            this.ptrToTypeComboBox.Size = new System.Drawing.Size(181, 21);
            this.ptrToTypeComboBox.TabIndex = 6;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(196, 169);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.acceptAddSlot);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(277, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.exitFromSettings);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(7, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Значение:";
            // 
            // dataTextBox
            // 
            this.dataTextBox.Location = new System.Drawing.Point(85, 113);
            this.dataTextBox.Name = "dataTextBox";
            this.dataTextBox.Size = new System.Drawing.Size(267, 20);
            this.dataTextBox.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(342, 30);
            this.label6.TabIndex = 11;
            this.label6.Text = "(Примечание: если данные не являются простыми типами, то \r\nнапишите название конт" +
    "ейнера)";
            // 
            // SlotAddSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 201);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.ptrToTypeComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ptrToInheritanceComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.slotNameText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SlotAddSettings";
            this.Text = "Окно добавления слота";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox slotNameText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ptrToInheritanceComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ptrToTypeComboBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dataTextBox;
        private System.Windows.Forms.Label label6;
    }
}