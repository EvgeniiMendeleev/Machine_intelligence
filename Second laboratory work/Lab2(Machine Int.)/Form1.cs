using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab2_Machine_Int._
{
    public partial class Form1 : Form
    {
        enum TypeOfFile { rules, characteristics }
        public Form1()
        {
            InitializeComponent();
        }

        private void showError(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void showCompleteInfo(string text)
        {
            MessageBox.Show(text, "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void openCharacterFile(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.FileName = "characteristics";
            openFile.Filter = "dat files (*.dat)|*.dat";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() != DialogResult.OK) return;

            if ((myStream = openFile.OpenFile()) == null)
            {
                showError("Не удалось открыть файл!");
                return;
            }

            using (BinaryReader binaryStream = new BinaryReader(myStream))
            {
                TypeOfFile typeReadFile = (TypeOfFile)binaryStream.ReadInt32();

                if (typeReadFile != TypeOfFile.characteristics)
                {
                    showError("Данный файл не является файлом с признаками!");
                    return;
                }

                characteristicBox.Items.Clear();
                while (binaryStream.PeekChar() > -1)
                {
                    characteristicBox.Items.Add(binaryStream.ReadString());
                }
            }
        }

        private void openRuleFile(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.FileName = "characteristics";
            openFile.Filter = "dat files (*.dat)|*.dat";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() != DialogResult.OK) return;

            if ((myStream = openFile.OpenFile()) == null)
            {
                showError("Не удалось открыть файл!");
                return;
            }

            using (BinaryReader binaryStream = new BinaryReader(myStream))
            {
                TypeOfFile typeReadFile = (TypeOfFile)binaryStream.ReadInt32();

                if (typeReadFile != TypeOfFile.rules)
                {
                    showError("Данный файл не является файлом с правилами!");
                    return;
                }

                rulesDB.Items.Clear();
                while (binaryStream.PeekChar() > -1)
                {
                    ListViewItem item = new ListViewItem();

                    item.Text = binaryStream.ReadString();
                    item.SubItems.Add(binaryStream.ReadString());

                    rulesDB.Items.Add(item);
                }
            }
        }

        private void saveCharacter_Click(object sender, EventArgs e)
        {
            if (characteristicBox.Items.Count <= 0)
            {
                showError("В блоке с признаками нету никаких данных!");
                return;
            }

            Stream myStream;
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = "characteristics";
            saveFile.Filter = "dat files (*.dat)|*.dat";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;

            if (saveFile.ShowDialog() != DialogResult.OK) return;

            if ((myStream = saveFile.OpenFile()) == null)
            {
                showError("Не удалось сохранить файл!");
                return;
            }

            ListBox.ObjectCollection items = characteristicBox.Items;
            using (BinaryWriter binaryStream = new BinaryWriter(myStream))
            {
                binaryStream.Write(Convert.ToInt32(TypeOfFile.characteristics));

                foreach (string data in items)
                {
                    binaryStream.Write(data);
                }
            }

            showCompleteInfo("Файл признаков успешно сохранён!");
        }

        private void saveRule_Click(object sender, EventArgs e)
        {
            if (rulesDB.Items.Count <= 0)
            {
                showError("В таблице с правилами нету никаких данных!");
                return;
            }

            Stream myStream;
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = "rules";
            saveFile.Filter = "dat files (*.dat)|*.dat";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;

            if (saveFile.ShowDialog() != DialogResult.OK) return;

            if ((myStream = saveFile.OpenFile()) == null)
            {
                showError("Не удалось сохранить файл правил!");
                return;
            }

            ListView.ListViewItemCollection items = rulesDB.Items;
            using (BinaryWriter binaryStream = new BinaryWriter(myStream))
            {
                binaryStream.Write(Convert.ToInt32(TypeOfFile.rules));

                for (int i = 0; i < items.Count; i++)
                {
                    binaryStream.Write(items[i].SubItems[0].Text);
                    binaryStream.Write(items[i].SubItems[1].Text);
                }
            }

            showCompleteInfo("Файл правил успешно сохранён!");
        }

        private void rulesDB_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            rulesDB.ColumnWidthChanged -= rulesDB_ColumnWidthChanged;
            rulesDB.Columns[e.ColumnIndex].Width = 213;
            rulesDB.ColumnWidthChanged += rulesDB_ColumnWidthChanged;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tПродукционная модель представления знаний\n\tРазработано Менделеевым Е.А. гр.7091", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void addCharacter_Click(object sender, EventArgs e)
        {
            string strOfCharacteristic = characterInputBox.Text;
            characterInputBox.Clear();

            if (strOfCharacteristic.Length > 0)
            {
                characteristicBox.Items.Add(strOfCharacteristic);
            }
            else
            {
                showError("Не был введён признак!");
            }
        }

        private void deleteCharacter_Click(object sender, EventArgs e)
        {
            if (characteristicBox.SelectedItems.Count > 0)
            {
                ListBox.SelectedObjectCollection selectedItems = characteristicBox.SelectedItems;
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    characteristicBox.Items.Remove(selectedItems[i]);
                }
            }
            else
            {
                showError("Не был выбран признак!");
            }
        }

        private bool checkRule(string ifRule)
        {
            for (int i = 0; i < rulesDB.Items.Count; i++)
            {
                if (rulesDB.Items[i].Text == ifRule)
                {
                    showError("Правило с таким условием уже есть!");
                    return false;
                }
            }

            return true;
        }

        private void addRule_Click(object sender, EventArgs e)
        {
            if (ifInputBox.Text.Length > 0 && thenInputBox.Text.Length > 0)
            {
                string ifRule = ifInputBox.Text;
                string thenRule = thenInputBox.Text;

                ifInputBox.Clear();
                thenInputBox.Clear();

                if (!checkRule(ifRule)) return;

                ListViewItem item = new ListViewItem();
                item.Text = ifRule;
                item.SubItems.Add(thenRule);

                rulesDB.Items.Add(item);
            }
            else
            {
                showError("Не все поля добавления правила заполнены!");
            }
        }

        private void deleteRule_Click(object sender, EventArgs e)
        {
            if (rulesDB.SelectedItems.Count > 0)
            {
                ListView.SelectedListViewItemCollection selectedItems = rulesDB.SelectedItems;
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    rulesDB.Items.Remove(selectedItems[i]);
                }
            }
            else
            {
                showError("Не было выбрано правило!");
            }
        }

        private void identifyVirus_Click(object sender, EventArgs e)
        {
            if (characteristicBox.Items.Count <= 0 && rulesDB.Items.Count <= 0)
            {
                showError("Формы с признаками и правилами пусты!");
                return;
            }
            else if (characteristicBox.Items.Count <= 0)
            {
                showError("Форма с признаками пуста!");
                return;
            }
            else if (rulesDB.Items.Count <= 0)
            {
                showError("Форма с правилами пуста!");
                return;
            }

            Console.WriteLine("*****************ПРИЗНАКИ*******************");
            ListBox.ObjectCollection itemsChar = characteristicBox.Items;
            for (int i = 0; i < itemsChar.Count; i++)
            {
                Console.WriteLine(itemsChar[i]);
            }
            Console.WriteLine("********************************************");

            Console.WriteLine("*****************ПРАВИЛА********************");
            ListView.ListViewItemCollection itemRules = rulesDB.Items;
            for (int i = 0; i < itemRules.Count; i++)
            {
                Console.WriteLine("ЕСЛИ " + itemRules[i].Text + " ТО " + itemRules[i].SubItems[1].Text);
            }
            Console.WriteLine("********************************************");
        }

        private void exitFromApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
