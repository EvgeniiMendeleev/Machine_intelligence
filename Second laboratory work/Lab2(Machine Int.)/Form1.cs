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
using Expert_System_Namespace_;
using About_Box_Namespace_;

namespace Lab2_Machine_Int._
{
    public partial class Form1 : Form
    {
        enum TypeOfFile { rules, characteristics }
        enum TypeOfError { another_symbol, empty_cell, not_pair_for_AND, not_pair_for_OR, nothing_errors }
        private const string OR = "или";
        private const string AND = "и";
        public Form1()
        {
            InitializeComponent();
        }
        #region The MAIN FUNCTION of work application
        private void identifyVirus_Click(object sender, EventArgs e)
        {
            if (characteristicBox.Items.Count <= 0 && rulesDB.Items.Count <= 0)
            {
                showError("Формы с признаками и правилами пусты!", "Ошибка запроса");
                return;
            }
            else if (characteristicBox.Items.Count <= 0)
            {
                showError("Форма с признаками пуста!", "Ошибка запроса");
                return;
            }
            else if (rulesDB.Items.Count <= 0)
            {
                showError("Форма с правилами пуста!", "Ошибка запроса");
                return;
            }

            List<string> state = new List<string>(stateInputBox.Text.Split(' '));
            while (state.IndexOf("") != -1) state.Remove("");

            switch (checkInputStringsFromCell(ref state))
            {
                case TypeOfError.empty_cell:
                    showError("Поле ввода состояния пустое!", "Ошибка запроса");
                    return;
                case TypeOfError.another_symbol:
                    showError("В поле ввода состояния есть посторонние символы!", "Ошибка запроса");
                    return;
                case TypeOfError.not_pair_for_AND:
                    showError("Для оператора \"И\" нету второго операнда!", "Ошибка запроса");
                    return;
                case TypeOfError.not_pair_for_OR:
                    showError("Для оператора \"ИЛИ\" нету второго операнда!", "Ошибка запроса");
                    return;
            }

            if (!isCharacter(ref state, "Ошибка запроса")) return;

            List<string> itemsChar = new List<string>();
            List<string> ifRuleList = new List<string>();
            List<string> thenRuleList = new List<string>();

            for (int i = 0; i < characteristicBox.Items.Count; i++) itemsChar.Add((string)characteristicBox.Items[i]);
            for (int i = 0; i < rulesDB.Items.Count; i++)
            {
                ifRuleList.Add((string)rulesDB.Items[i].SubItems[0].Text);
                thenRuleList.Add((string)rulesDB.Items[i].SubItems[1].Text);
            }

            int COUNT_OF_RULE = rulesDB.Items.Count;

            //TODO: Разработать основной алгоритм программы с прямым выводом.
            
            List<string> request;
            getSplitCharacteristics(out request, ref state);

            for (int i = 1; i < request.Count - 1; i++)
            {
                if (request[i] != AND) continue;
                string ifPart = request[i - 1] + " " + AND + " " + request[i + 1];

                int searchResult = ifRuleList.IndexOf(ifPart); 
                if (searchResult == -1)
                {
                    showError("К сожалению, невозможно сделать заключение по данному запросу!", "Заключение");
                    return;
                }
                else
                {
                    request.RemoveRange(i, 3);
                    request.Insert(i, thenRuleList[searchResult]);
                }
            }
        }
        #endregion
        #region The functions for enter datas to forms
        private void enterCharacteristic(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addCharacter_Click(sender, e);
            }
        }
        private void enterRule(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addRule_Click(sender, e);
            }
        }
        private void enterRequest(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                identifyVirus_Click(sender, e);
            }
        }
        #endregion
        #region The functions for work with strings
        private string getConnectedSubstring(ref List<string> substrings)
        {
            string connectedString = "";
            if (substrings.Count > 1)
            {
                for (int i = 0; i < substrings.Count - 1; i++)
                {
                    connectedString += substrings[i] + ' ';
                }
                connectedString += substrings.Last<string>();
            }
            else connectedString = substrings[0];

            return connectedString;
        }

        private void getSplitCharacteristics(out List<string> listOut, ref List<string> listIn)
        {
            listOut = new List<string>();

            string connectedString = listIn[0];
            for (int i = 1; i < listIn.Count; i++)
            {
                if (listIn[i] == OR || listIn[i] == AND)
                {
                    listOut.Add(connectedString);
                    listOut.Add(listIn[i]);
                    connectedString = "";

                    continue;
                }

                if (connectedString == "")
                {
                    connectedString += listIn[i];
                }
                else
                {
                    connectedString += ' ' + listIn[i];
                }
            }

            if (connectedString != "") listOut.Add(connectedString);
        }
        #endregion
        #region The functions for show information for user
        private void showError(string text, string nameOfError)
        {
            MessageBox.Show(text, nameOfError, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
        private void showCompleteInfo(string text)
        {
            MessageBox.Show(text, "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }
        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox programInfo = new AboutBox();
            programInfo.ShowDialog();
        }
        #endregion
        #region The functions for check datas
        private TypeOfError checkInputStringsFromCell(ref List<string> inputStrings)
        {
            for (int i = 1; i < inputStrings.Count - 1; i++)
            {
                bool isLogicOp = inputStrings[i + 1] == AND || inputStrings[i + 1] == OR;

                if (inputStrings[i] == OR && isLogicOp) return TypeOfError.not_pair_for_OR;
                else if (inputStrings[i] == AND && isLogicOp) return TypeOfError.not_pair_for_AND;
            }

            if (inputStrings.Count <= 0)
            {
                return TypeOfError.empty_cell;
            }
            else if (!checkAnotherSymbols(ref inputStrings))
            {
                return TypeOfError.another_symbol;
            }
            else if (inputStrings[0] == OR || inputStrings[inputStrings.Count - 1] == OR)
            {
                return TypeOfError.not_pair_for_OR;
            }
            else if (inputStrings[0] == AND || inputStrings[inputStrings.Count - 1] == AND)
            {
                return TypeOfError.not_pair_for_AND;
            }

            return TypeOfError.nothing_errors;
        }
        private bool checkRule(string ifRule)
        {
            for (int i = 0; i < rulesDB.Items.Count; i++)
            {
                if (rulesDB.Items[i].Text == ifRule)
                {
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
        private bool isCharacter(ref List<string> ifRule, string errorName)
        {
            List<string> characteristicsFromRule;
            getSplitCharacteristics(out characteristicsFromRule, ref ifRule);

            foreach (string ifPart in characteristicsFromRule)
            {
                if (ifPart == OR || ifPart == AND) continue;
                if (characteristicBox.Items.IndexOf(ifPart) == -1)
                {
                    showError("Признак \"" + ifPart + "\" отсутствует в базе признаков!", errorName);
                    return false;
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
                showError("Не удалось открыть файл!", "Ошибка открытия файла");
                return;
            }

            //Проверка на наличие количества информации в начале файла,
            //чтобы в идентифицировать файл: файл признаков или файл правил.
            if (myStream.Length < 4)
            {
                showError("Файл меньше 4 байт!", "Ошибка размера файла");
                return;
            }

            using (BinaryReader binaryStream = new BinaryReader(myStream))
            {
                TypeOfFile typeReadFile = (TypeOfFile)binaryStream.ReadInt32();
                if (typeReadFile != TypeOfFile.characteristics)
                {
                    showError("Данный файл не является файлом с признаками!", "Ошибка типа файла");
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
                showError("Не удалось открыть файл!", "Ошибка открытия файла");
                return;
            }

            //Проверка на наличие количества информации в начале файла,
            //чтобы в идентифицировать файл: файл признаков или файл правил.
            if (myStream.Length < 4)
            {
                showError("Файл меньше 4 байт!", "Ошибка размера файла");
                return;
            }

            using (BinaryReader binaryStream = new BinaryReader(myStream))
            {
                TypeOfFile typeReadFile = (TypeOfFile)binaryStream.ReadInt32();
                if (typeReadFile != TypeOfFile.rules)
                {
                    showError("Данный файл не является файлом с правилами!", "Ошибка типа файла");
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
                showError("В блоке с признаками нету никаких данных!", "Ошибка сохранения признака");
                return;
            }

            Stream myStream;
            SaveFileDialog saveFile = new SaveFileDialog();
            standartSettingsForFile(saveFile, "dat files (*.dat)|*.dat", 2, true);

            if (saveFile.ShowDialog() != DialogResult.OK) return;
            if ((myStream = saveFile.OpenFile()) == null)
            {
                showError("Не удалось сохранить файл!", "Ошибка сохранения файла признаков");
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
                showError("В таблице с правилами нету никаких данных!", "Ошибка сохранения правил");
                return;
            }

            Stream myStream;
            SaveFileDialog saveFile = new SaveFileDialog();
            standartSettingsForFile(saveFile, "dat files (*.dat)|*.dat", 2, true);

            if (saveFile.ShowDialog() != DialogResult.OK) return;
            if ((myStream = saveFile.OpenFile()) == null)
            {
                showError("Не удалось сохранить файл правил!", "Ошибка сохранения правил");
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
                    showError("Не был введён признак!", "Ошибка добавления признака");
                    return;

                case TypeOfError.another_symbol:
                    showError("В поле ввода признака присутствуют посторонние символы!", "Ошибка добавления признака");
                    return;
            }

            string character = getConnectedSubstring(ref splitInputStrings);

            characteristicBox.Items.Add(character);
            characterInputBox.Clear();

            ExpertSystemResult window = new ExpertSystemResult();
            window.showWindow("Ты думал, что это был вирус, но это я - Дио!");
        }
        private void deleteCharacter_Click(object sender, EventArgs e)
        {
            if (characteristicBox.SelectedItems.Count > 0)
            {
                List<string> rules = new List<string>();
                for (int i = 0; i < rulesDB.Items.Count; i++)
                {
                    rules.Add(rulesDB.Items[i].Text);
                }

                ListBox.SelectedObjectCollection selectedItems = characteristicBox.SelectedItems;
                for (int i = 0; i < rules.Count; i++)
                {
                    foreach (string str in rules[i].Split(' '))
                    {
                        if (str == OR || str == AND) continue;
                        if (selectedItems.IndexOf(str) != -1)
                        {
                            showError("Прежде, чем удалить признак, удалите правила,\nв которых присутствуют удаляемые признаки в части ЕСЛИ", "Ошибка удаления признака");
                            return;
                        }
                    }
                }

                for (int i = 0; i < selectedItems.Count; i++)
                {
                    characteristicBox.Items.Remove(selectedItems[i]);
                }
            }
            else
            {
                showError("Не был выбран признак!", "Ошибка удаления признака");
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
                        showError("В поле ввода ЕСЛИ присутствуют посторонние символы!", "Ошибка добавления правила");
                        return;
                    case TypeOfError.not_pair_for_AND:
                        showError("Для оператора \"И\" нету второго операнда!", "Ошибка добавления правила");
                        return;
                    case TypeOfError.not_pair_for_OR:
                        showError("Для оператора \"ИЛИ\" нету второго операнда!", "Ошибка добавления правила");
                        return;
                }

                switch (checkInputStringsFromCell(ref splitThenRule))
                {
                    case TypeOfError.another_symbol:
                        showError("В поле ввода ТО присутствуют посторонние символы!", "Ошибка добавления правила");
                        return;
                }

                if (!isCharacter(ref splitIfRule, "Ошибка добавления правила")) return;

                ifInputBox.Clear();
                thenInputBox.Clear();

                string ifRule = getConnectedSubstring(ref splitIfRule);
                string thenRule = getConnectedSubstring(ref splitThenRule);

                if (!checkRule(ifRule))
                {
                    showError("Правило с таким условием уже есть!", "Ошибка добавления правила");
                    return;
                }

                ListViewItem item = new ListViewItem();
                item.Text = ifRule;
                item.SubItems.Add(thenRule);

                rulesDB.Items.Add(item);
            }
            else
            {
                showError("Не все поля добавления правила заполнены!", "Ошибка добавления правила");
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
                showError("Не было выбрано правило!", "Ошибка удаления правила");
            }
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
