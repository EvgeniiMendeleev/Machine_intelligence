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
        public SlotAddSettings()
        {
            InitializeComponent();
            ptrToInheritanceComboBox.SelectedIndex = 0;
            ptrToTypeComboBox.SelectedIndex = 0;
        }

        private void exitFromSettings(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
