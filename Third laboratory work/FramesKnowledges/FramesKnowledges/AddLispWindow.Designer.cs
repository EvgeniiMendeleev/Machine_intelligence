namespace FramesKnowledges
{
    partial class AddLispWindow
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
            this.prodNameTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.FIND = new System.Windows.Forms.TabPage();
            this.PRINT = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textForPrintTextBox = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.charactersTextBox = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.FIND.SuspendLayout();
            this.PRINT.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(113, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавление процедуры";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дайте название процедуре:";
            // 
            // prodNameTextBox
            // 
            this.prodNameTextBox.Location = new System.Drawing.Point(167, 39);
            this.prodNameTextBox.Name = "prodNameTextBox";
            this.prodNameTextBox.Size = new System.Drawing.Size(221, 20);
            this.prodNameTextBox.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.FIND);
            this.tabControl1.Controls.Add(this.PRINT);
            this.tabControl1.Location = new System.Drawing.Point(15, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(377, 199);
            this.tabControl1.TabIndex = 3;
            // 
            // FIND
            // 
            this.FIND.BackColor = System.Drawing.Color.Silver;
            this.FIND.Controls.Add(this.btnFind);
            this.FIND.Controls.Add(this.charactersTextBox);
            this.FIND.Controls.Add(this.label5);
            this.FIND.Location = new System.Drawing.Point(4, 22);
            this.FIND.Name = "FIND";
            this.FIND.Padding = new System.Windows.Forms.Padding(3);
            this.FIND.Size = new System.Drawing.Size(369, 173);
            this.FIND.TabIndex = 0;
            this.FIND.Text = "FIND";
            // 
            // PRINT
            // 
            this.PRINT.BackColor = System.Drawing.Color.Silver;
            this.PRINT.Controls.Add(this.btnPrint);
            this.PRINT.Controls.Add(this.textForPrintTextBox);
            this.PRINT.Controls.Add(this.label4);
            this.PRINT.Location = new System.Drawing.Point(4, 22);
            this.PRINT.Name = "PRINT";
            this.PRINT.Padding = new System.Windows.Forms.Padding(3);
            this.PRINT.Size = new System.Drawing.Size(369, 173);
            this.PRINT.TabIndex = 1;
            this.PRINT.Text = "PRINT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(140, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выберите тип процедуры";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ввеидите текст, который должна выводить процедура:";
            // 
            // textForPrintTextBox
            // 
            this.textForPrintTextBox.Location = new System.Drawing.Point(6, 33);
            this.textForPrintTextBox.Multiline = true;
            this.textForPrintTextBox.Name = "textForPrintTextBox";
            this.textForPrintTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textForPrintTextBox.Size = new System.Drawing.Size(357, 105);
            this.textForPrintTextBox.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(226, 144);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(137, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Добавить процедуру";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.getDataFromForm);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(358, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "Напишите признаки, по которым хотите найти вирус:\r\n(ПРИМЕЧАНИЕ: на одной строчке " +
    "должен находиться один признак)";
            // 
            // charactersTextBox
            // 
            this.charactersTextBox.Location = new System.Drawing.Point(6, 32);
            this.charactersTextBox.Multiline = true;
            this.charactersTextBox.Name = "charactersTextBox";
            this.charactersTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.charactersTextBox.Size = new System.Drawing.Size(355, 106);
            this.charactersTextBox.TabIndex = 3;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(224, 144);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(137, 23);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "Добавить процедуру";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.getDataFromForm);
            // 
            // AddLispWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 295);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.prodNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddLispWindow";
            this.Text = "Настройка добавления процедуры";
            this.tabControl1.ResumeLayout(false);
            this.FIND.ResumeLayout(false);
            this.FIND.PerformLayout();
            this.PRINT.ResumeLayout(false);
            this.PRINT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox prodNameTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage FIND;
        private System.Windows.Forms.TabPage PRINT;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox textForPrintTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox charactersTextBox;
        private System.Windows.Forms.Label label5;
    }
}