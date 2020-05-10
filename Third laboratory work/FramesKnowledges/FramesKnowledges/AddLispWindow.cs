using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FramesKnowledges
{
    public partial class AddLispWindow : Form
    {
        private string procedureName;
        private string dataFromPrint;
        private List<string> charactersForFind = new List<string>();
        private string nameOfButton;

        public AddLispWindow()
        {
            InitializeComponent();
        }

        private void showError(string nameOfError, string textOfError)
        {
            MessageBox.Show(textOfError, nameOfError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string getConnectedString(ref List<string> substrings)
        {
            string result = substrings.First<string>();
            for (int i = 1; i < substrings.Count; i++)
            {
                result += ' ' + substrings[i];
            }

            return result;
        }
        private string getProcessedInputString(string inputStr)
        {
            List<string> splitedInputStr = new List<string>(inputStr.Split(' '));
            while (splitedInputStr.IndexOf("") != -1) splitedInputStr.Remove("");

            return getConnectedString(ref splitedInputStr);
        }

        private void getDataFromForm(object sender, EventArgs e)
        {
            if (prodNameTextBox.Text.Length == 0)
            {
                showError("Ошибка добавления процедуры!", "Не было введено имя процедуры!");
                return;
            }
            
            procedureName = getProcessedInputString(prodNameTextBox.Text);

            foreach (char ch in procedureName)
            {
                if (ch != ' ' && !Char.IsLetter(ch))
                {
                    showError("Ошибка добавления процедуры!", "В названии процедуры присутствуют посторонние символы!");
                    return;
                }
            }

            nameOfButton = (sender as Button).Name;
            switch (nameOfButton)
            {
                case "btnFind":
                    charactersForFind = new List<string>(charactersTextBox.Text.Split('\r'));
                    for (int i = 0; i < charactersForFind.Count; i++)
                    {
                        int pos;
                        while ((pos = charactersForFind[i].IndexOf('\n')) != -1) charactersForFind[i] = charactersForFind[i].Remove(pos, 1);
                        while ((pos = charactersForFind[i].IndexOf('\t')) != -1) charactersForFind[i] = charactersForFind[i].Remove(pos, 1);
                    }
                    break;
                case "btnPrint":
                    dataFromPrint = textForPrintTextBox.Text;
                    break;
            }

            this.DialogResult = DialogResult.OK;
        }

        public string getNameOfProcedure()
        {
            return procedureName;
        }

        public List<string> getCharactersFromForm()
        {
            return charactersForFind;
        }

        public string getPrintTextFromForm()
        {
            return dataFromPrint;
        }

        public string getNameOfButton()
        {
            return nameOfButton;
        }
    }
}
