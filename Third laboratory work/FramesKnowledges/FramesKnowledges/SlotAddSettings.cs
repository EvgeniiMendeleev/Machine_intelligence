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
        public List<string> valuesFromSettings = new List<string>();
        public SlotAddSettings()
        {
            InitializeComponent();
            ptrToInheritanceComboBox.SelectedIndex = 0;
            ptrToTypeComboBox.SelectedIndex = 0;
        }

        public List<string> getValue()
        {
            return valuesFromSettings;
        }

        private void acceptAddSlot(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;

            switch(ptrToTypeComboBox.Text)
            {
                case "FRAME":
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

            valuesFromSettings.Add(slotNameText.Text);
            valuesFromSettings.Add(ptrToInheritanceComboBox.SelectedItem.ToString());
            valuesFromSettings.Add(ptrToTypeComboBox.SelectedItem.ToString());
            valuesFromSettings.Add(dataTextBox.Text);

            this.Close();
        }

        private void exitFromSettings(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
