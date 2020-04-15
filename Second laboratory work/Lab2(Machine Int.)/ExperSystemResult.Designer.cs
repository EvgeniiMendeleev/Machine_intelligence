namespace Expert_System_Namespace_
{
    partial class ExpertSystemResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpertSystemResult));
            this.label2 = new System.Windows.Forms.Label();
            this.virusNameBox = new System.Windows.Forms.TextBox();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(30, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Заключение экспертной системы";
            // 
            // virusNameBox
            // 
            this.virusNameBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.virusNameBox.CausesValidation = false;
            this.virusNameBox.Location = new System.Drawing.Point(12, 62);
            this.virusNameBox.Name = "virusNameBox";
            this.virusNameBox.Size = new System.Drawing.Size(378, 20);
            this.virusNameBox.TabIndex = 2;
            // 
            // descriptionBox
            // 
            this.descriptionBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.descriptionBox.CausesValidation = false;
            this.descriptionBox.Location = new System.Drawing.Point(12, 103);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ReadOnly = true;
            this.descriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionBox.Size = new System.Drawing.Size(378, 88);
            this.descriptionBox.TabIndex = 4;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(296, 213);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(94, 23);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Закрыть";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.close);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Вирусом, исходя из запроса, оказался:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Правило, по которому был получен результат:";
            // 
            // ExpertSystemResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 248);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.virusNameBox);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExpertSystemResult";
            this.Text = "Результат работы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox virusNameBox;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}