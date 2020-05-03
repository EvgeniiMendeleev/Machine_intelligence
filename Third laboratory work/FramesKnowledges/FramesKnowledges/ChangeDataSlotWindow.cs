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
    public partial class ChangeDataSlotWindow : Form
    {
        private string newDataForSlot = null;
        public ChangeDataSlotWindow()
        {
            InitializeComponent();
        }
        private string getProcessedInputString(string inputStr)
        {
            List<string> splitedInputStr = new List<string>(inputStr.Split(' '));
            while (splitedInputStr.IndexOf("") != -1) splitedInputStr.Remove("");

            string result = splitedInputStr.First<string>();
            for (int i = 1; i < splitedInputStr.Count; i++)
            {

                result += ' ' + splitedInputStr[i];
            }

            return result;
        }

        private void enterAData(object sender, EventArgs e)
        {
            if (newDataTextBox.Text.Length < 0)
            {
                MessageBox.Show("Ошибка изменения значения!", "Вы не ввели никаких данных!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (char ch in newDataTextBox.Text)
            {
                if (ch != ' ' && !Char.IsLetter(ch))
                {
                    MessageBox.Show("Ошибка изменения значения!", "Вы не ввели никаких данных!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            newDataForSlot = getProcessedInputString(newDataTextBox.Text);
            this.DialogResult = DialogResult.OK;
        }

        public string getDataFromForm()
        {
            return newDataForSlot;
        }

        private void closeWindow(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
