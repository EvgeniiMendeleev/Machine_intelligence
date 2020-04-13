namespace Lab2_Machine_Int._
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлПризнаковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлПравилToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.addCharacter = new System.Windows.Forms.Button();
            this.characterInputBox = new System.Windows.Forms.TextBox();
            this.deleteCharacter = new System.Windows.Forms.Button();
            this.saveCharacter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rulesDB = new System.Windows.Forms.ListView();
            this.ifColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ThenColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ifInputBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.thenInputBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addRule = new System.Windows.Forms.Button();
            this.deleteRule = new System.Windows.Forms.Button();
            this.saveRule = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.stateInputBox = new System.Windows.Forms.TextBox();
            this.identifyVirus = new System.Windows.Forms.Button();
            this.characteristicBox = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(746, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьФайлПризнаковToolStripMenuItem,
            this.открытьФайлПравилToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьФайлПризнаковToolStripMenuItem
            // 
            this.открытьФайлПризнаковToolStripMenuItem.Name = "открытьФайлПризнаковToolStripMenuItem";
            this.открытьФайлПризнаковToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.открытьФайлПризнаковToolStripMenuItem.Text = "Открыть файл признаков";
            this.открытьФайлПризнаковToolStripMenuItem.Click += new System.EventHandler(this.openCharacterFile);
            // 
            // открытьФайлПравилToolStripMenuItem
            // 
            this.открытьФайлПравилToolStripMenuItem.Name = "открытьФайлПравилToolStripMenuItem";
            this.открытьФайлПравилToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.открытьФайлПравилToolStripMenuItem.Text = "Открыть файл правил";
            this.открытьФайлПравилToolStripMenuItem.Click += new System.EventHandler(this.openRuleFile);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.exitFromApplication);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem});
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(134, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(457, 50);
            this.label4.TabIndex = 8;
            this.label4.Text = "Продукционная модель представления знаний.\r\n  Экспертная система по определению в" +
    "ируса.";
            // 
            // addCharacter
            // 
            this.addCharacter.Location = new System.Drawing.Point(12, 389);
            this.addCharacter.Name = "addCharacter";
            this.addCharacter.Size = new System.Drawing.Size(131, 23);
            this.addCharacter.TabIndex = 10;
            this.addCharacter.Text = "Добавить";
            this.addCharacter.UseVisualStyleBackColor = true;
            this.addCharacter.Click += new System.EventHandler(this.addCharacter_Click);
            // 
            // characterInputBox
            // 
            this.characterInputBox.Location = new System.Drawing.Point(12, 363);
            this.characterInputBox.Name = "characterInputBox";
            this.characterInputBox.Size = new System.Drawing.Size(272, 20);
            this.characterInputBox.TabIndex = 11;
            this.characterInputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enterCharacteristic);
            // 
            // deleteCharacter
            // 
            this.deleteCharacter.Location = new System.Drawing.Point(149, 389);
            this.deleteCharacter.Name = "deleteCharacter";
            this.deleteCharacter.Size = new System.Drawing.Size(135, 23);
            this.deleteCharacter.TabIndex = 12;
            this.deleteCharacter.Text = "Удалить";
            this.deleteCharacter.UseVisualStyleBackColor = true;
            this.deleteCharacter.Click += new System.EventHandler(this.deleteCharacter_Click);
            // 
            // saveCharacter
            // 
            this.saveCharacter.Location = new System.Drawing.Point(12, 418);
            this.saveCharacter.Name = "saveCharacter";
            this.saveCharacter.Size = new System.Drawing.Size(272, 23);
            this.saveCharacter.TabIndex = 13;
            this.saveCharacter.Text = "Сохранить";
            this.saveCharacter.UseVisualStyleBackColor = true;
            this.saveCharacter.Click += new System.EventHandler(this.saveCharacter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(89, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Признаки вирусов";
            // 
            // rulesDB
            // 
            this.rulesDB.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.rulesDB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ifColumn,
            this.ThenColumn});
            this.rulesDB.FullRowSelect = true;
            this.rulesDB.GridLines = true;
            this.rulesDB.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.rulesDB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rulesDB.Location = new System.Drawing.Point(304, 146);
            this.rulesDB.MultiSelect = false;
            this.rulesDB.Name = "rulesDB";
            this.rulesDB.Size = new System.Drawing.Size(430, 213);
            this.rulesDB.TabIndex = 15;
            this.rulesDB.UseCompatibleStateImageBehavior = false;
            this.rulesDB.View = System.Windows.Forms.View.Details;
            // 
            // ifColumn
            // 
            this.ifColumn.Text = "ЕСЛИ";
            this.ifColumn.Width = 213;
            // 
            // ThenColumn
            // 
            this.ThenColumn.Text = "ТО";
            this.ThenColumn.Width = 213;
            // 
            // ifInputBox
            // 
            this.ifInputBox.Location = new System.Drawing.Point(351, 365);
            this.ifInputBox.Name = "ifInputBox";
            this.ifInputBox.Size = new System.Drawing.Size(171, 20);
            this.ifInputBox.TabIndex = 16;
            this.ifInputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enterRule);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(301, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Если:";
            // 
            // thenInputBox
            // 
            this.thenInputBox.Location = new System.Drawing.Point(563, 364);
            this.thenInputBox.Name = "thenInputBox";
            this.thenInputBox.Size = new System.Drawing.Size(171, 20);
            this.thenInputBox.TabIndex = 18;
            this.thenInputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enterRule);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(528, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "То:";
            // 
            // addRule
            // 
            this.addRule.Location = new System.Drawing.Point(304, 391);
            this.addRule.Name = "addRule";
            this.addRule.Size = new System.Drawing.Size(218, 23);
            this.addRule.TabIndex = 20;
            this.addRule.Text = "Добавить";
            this.addRule.UseVisualStyleBackColor = true;
            this.addRule.Click += new System.EventHandler(this.addRule_Click);
            // 
            // deleteRule
            // 
            this.deleteRule.Location = new System.Drawing.Point(528, 391);
            this.deleteRule.Name = "deleteRule";
            this.deleteRule.Size = new System.Drawing.Size(206, 23);
            this.deleteRule.TabIndex = 21;
            this.deleteRule.Text = "Удалить";
            this.deleteRule.UseVisualStyleBackColor = true;
            this.deleteRule.Click += new System.EventHandler(this.deleteRule_Click);
            // 
            // saveRule
            // 
            this.saveRule.Location = new System.Drawing.Point(304, 419);
            this.saveRule.Name = "saveRule";
            this.saveRule.Size = new System.Drawing.Size(430, 23);
            this.saveRule.TabIndex = 22;
            this.saveRule.Text = "Сохранить";
            this.saveRule.UseVisualStyleBackColor = true;
            this.saveRule.Click += new System.EventHandler(this.saveRule_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(483, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Правила";
            // 
            // stateInputBox
            // 
            this.stateInputBox.Location = new System.Drawing.Point(12, 93);
            this.stateInputBox.Name = "stateInputBox";
            this.stateInputBox.Size = new System.Drawing.Size(610, 20);
            this.stateInputBox.TabIndex = 24;
            this.stateInputBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enterRequest);
            // 
            // identifyVirus
            // 
            this.identifyVirus.Location = new System.Drawing.Point(628, 90);
            this.identifyVirus.Name = "identifyVirus";
            this.identifyVirus.Size = new System.Drawing.Size(106, 23);
            this.identifyVirus.TabIndex = 25;
            this.identifyVirus.Text = "Опознать вирус";
            this.identifyVirus.UseVisualStyleBackColor = true;
            this.identifyVirus.Click += new System.EventHandler(this.identifyVirus_Click);
            // 
            // characteristicBox
            // 
            this.characteristicBox.FormattingEnabled = true;
            this.characteristicBox.HorizontalScrollbar = true;
            this.characteristicBox.Location = new System.Drawing.Point(12, 146);
            this.characteristicBox.Name = "characteristicBox";
            this.characteristicBox.Size = new System.Drawing.Size(272, 212);
            this.characteristicBox.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 460);
            this.Controls.Add(this.characteristicBox);
            this.Controls.Add(this.identifyVirus);
            this.Controls.Add(this.stateInputBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.saveRule);
            this.Controls.Add(this.deleteRule);
            this.Controls.Add(this.addRule);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.thenInputBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ifInputBox);
            this.Controls.Add(this.rulesDB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveCharacter);
            this.Controls.Add(this.deleteCharacter);
            this.Controls.Add(this.characterInputBox);
            this.Controls.Add(this.addCharacter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Laba 2 by Mendeleev Evgenii";
            this.Enter += new System.EventHandler(this.addCharacter_Click);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addCharacter;
        private System.Windows.Forms.TextBox characterInputBox;
        private System.Windows.Forms.Button deleteCharacter;
        private System.Windows.Forms.Button saveCharacter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView rulesDB;
        private System.Windows.Forms.ColumnHeader ThenColumn;
        private System.Windows.Forms.ColumnHeader ifColumn;
        private System.Windows.Forms.TextBox ifInputBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox thenInputBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addRule;
        private System.Windows.Forms.Button deleteRule;
        private System.Windows.Forms.Button saveRule;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox stateInputBox;
        private System.Windows.Forms.Button identifyVirus;
        private System.Windows.Forms.ListBox characteristicBox;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлПризнаковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлПравилToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;

    }
}

