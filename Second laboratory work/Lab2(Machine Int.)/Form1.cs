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
        enum TypeOfError { another_symbol, empty_cell, nothing_errors }
        public Form1()
        {
            InitializeComponent();
        }
        #region The functions for work with strings
        private string getConnectedSubstrings(ref List<string> substrings)
        {
            string connectedString = "";
            if (substrings.Count == 1)
            {
                connectedString = substrings[0];
            }
            else
            {
                for (int i = 0; i < substrings.Count - 1; i++)
                {
                    connectedString += substrings[i] + ' ';
                }
                connectedString += substrings.Last<string>();
            }

            return connectedString;
        }
        #endregion
        #region The functions for show information for user
        private void showError(string text)
        {
            MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
        private void showCompleteInfo(string text)
        {
            MessageBox.Show(text, "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Продукционная модель представления знаний\n       Разработано Менделеевым Е.А. гр.7091", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
        #endregion
        #region The functions for check datas
        private TypeOfError checkInputStringsFromCell(ref List<string> inputStrings)
        {
            if (inputStrings.Count <= 0)
            {
                return TypeOfError.empty_cell;
            }
            else if (!checkAnotherSymbols(ref inputStrings))
            {
                return TypeOfError.another_symbol;
            }

            return TypeOfError.nothing_errors;
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
        private bool checkAnotherSymbols(ref List<string> inputStrings)
        {
            foreach (string str in inputStrings)
            {
                foreach (char ch in str)
                {
                    if (!Char.IsLetter(ch))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion
        #region The functions for open DAT files
        private void openCharacterFile(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFile = new OpenFileDialog();
            standartSettingsForFile(openFile, "dat files (*.dat)|*.dat", 2, true);

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
            standartSettingsForFile(openFile, "dat files (*.dat)|*.dat", 2, true);

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
        #endregion
        #region The functions for save DAT files
        private void saveCharacter_Click(object sender, EventArgs e)
        {
            if (characteristicBox.Items.Count <= 0)
            {
                showError("В блоке с признаками нету никаких данных!");
                return;
            }

            Stream myStream;
            SaveFileDialog saveFile = new SaveFileDialog();
            standartSettingsForFile(saveFile, "dat files (*.dat)|*.dat", 2, true);

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
            standartSettingsForFile(saveFile, "dat files (*.dat)|*.dat", 2, true);

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
        #endregion
        #region The functions for work with characteristics
        private void addCharacter_Click(object sender, EventArgs e)
        {
            List<string> splitInputStrings = new List<string>(characterInputBox.Text.Split(' '));
            while (splitInputStrings.IndexOf("") != -1) splitInputStrings.Remove("");

            switch (checkInputStringsFromCell(ref splitInputStrings))
            {
                case TypeOfError.empty_cell:
                    showError("Не был введён признак!");
                    return;

                case TypeOfError.another_symbol:
                    showError("В поле ввода признака присутствуют посторонние символы!");
                    return;
            }

            string character = getConnectedSubstrings(ref splitInputStrings);

            characteristicBox.Items.Add(character);
            characterInputBox.Clear();
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
        #endregion
        #region The functions for work with rules
        private void addRule_Click(object sender, EventArgs e)
        {
            if (ifInputBox.Text.Length > 0 && thenInputBox.Text.Length > 0)
            {
                List<string> splitIfRule = new List<string>(ifInputBox.Text.Split(' '));
                List<string> splitThenRule = new List<string>(thenInputBox.Text.Split(' '));

                while (splitIfRule.IndexOf("") != -1) splitIfRule.Remove("");
                while (splitThenRule.IndexOf("") != -1) splitThenRule.Remove("");

                switch (checkInputStringsFromCell(ref splitIfRule))
                {
                    case TypeOfError.another_symbol:
                        showError("В поле ввода ЕСЛИ присутствуют посторонние символы!");
                        return;
                }

                switch (checkInputStringsFromCell(ref splitThenRule))
                {
                    case TypeOfError.another_symbol:
                        showError("В поле ввода ТО присутствуют посторонние символы!");
                        return;
                }

                ifInputBox.Clear();
                thenInputBox.Clear();

                string ifRule = getConnectedSubstrings(ref splitIfRule);
                string thenRule = getConnectedSubstrings(ref splitThenRule);

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
        #endregion
        #region The MAIN FUNCTION of work application
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

            List<string> state = new List<string>(stateInputBox.Text.Split(' '));
            while (state.IndexOf("") != -1) state.Remove("");

            switch (checkInputStringsFromCell(ref state))
            {
                case TypeOfError.empty_cell:
                    showError("Поле ввода состояния пустое!");
                    return;
                case TypeOfError.another_symbol:
                    showError("В поле ввода состояния есть посторонние символы!");
                    return;
            }

            ListBox.ObjectCollection itemsChar = characteristicBox.Items;
            ListView.ListViewItemCollection itemRules = rulesDB.Items;
        }
        #endregion
        #region The another functions for settings apllication
        private void rulesDB_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            rulesDB.ColumnWidthChanged -= rulesDB_ColumnWidthChanged;
            rulesDB.Columns[e.ColumnIndex].Width = 213;
            rulesDB.ColumnWidthChanged += rulesDB_ColumnWidthChanged;
        }
        private void exitFromApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void standartSettingsForFile(FileDialog file, string fileFilter, int fileIndex, bool restoreDirectory)
        {
            file.Filter = fileFilter;
            file.FilterIndex = fileIndex;
            file.RestoreDirectory = restoreDirectory;
        }
        #endregion
    }
}
