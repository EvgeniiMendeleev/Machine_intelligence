using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Non_Result_System
{
    public partial class NoneResultSystem: Form
    {
        public NoneResultSystem()
        {
            InitializeComponent();
        }

        public void showWindow()
        {
            this.ShowDialog();
        }

        private void close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
