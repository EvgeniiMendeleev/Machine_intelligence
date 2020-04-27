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
    public partial class SlotAddSettings : Form
    {
        private List<string> valuesFromSettings = new List<string>();
        public SlotAddSettings()
        {
            InitializeComponent();
            ptrToInheritanceComboBox.SelectedIndex = 0;
            ptrToTypeComboBox.SelectedIndex = 0;
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

        public List<string> getDatasFromForm()
        {
            return valuesFromSettings;
        }

        private bool checkFields()
        {
            if (slotNameText.Text.Length == 0 || dataTextBox.Text.Length == 0) return true;
            return false;
        }

        private void acceptAddSlot(object sender, EventArgs e)
        {
            if (slotNameText.Text.Length == 0)
            {
                showError("Ошибка создания слота!", "Не указано имя слота!");
                return;
            }
            else if (dataTextBox.Text.Length == 0)
            {
                showError("Ошибка создания слота!", "Вы не задали значение слота!");
                return;
            }

            this.DialogResult = DialogResult.Yes;

            List<string> splitData = new List<string>(dataTextBox.Text.Split(' '));
            while (splitData.IndexOf("") != -1) splitData.Remove("");

            valuesFromSettings.Add(slotNameText.Text);
            valuesFromSettings.Add(ptrToInheritanceComboBox.SelectedItem.ToString());
            valuesFromSettings.Add(ptrToTypeComboBox.SelectedItem.ToString());

            string data = getConnectedString(ref splitData);

            switch(ptrToTypeComboBox.Text)
            {
                case "FRAME":
                    foreach (char ch in dataTextBox.Text)
                    {
                        if (ch != ' ' && !Char.IsLetter(ch))
                        {
                            MessageBox.Show("Ошибка добавления слота!", "В значении присутствуют сторонние символы!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    valuesFromSettings.Add(data);
                    break;
                case "INTEGER":
                    break;
                case "REAL":
                    break;
                case "BOOL":
                    break;
                case "LISP":
                    break;
                case "TEXT":
                    break;
                case "LIST":
                    break;
            }

        }

        private void exitFromSettings(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
