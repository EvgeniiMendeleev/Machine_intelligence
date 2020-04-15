using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Non_Result_System;

namespace Expert_System_Namespace_
{
    public partial class ExpertSystemResult : Form
    {
        public ExpertSystemResult()
        {
            InitializeComponent();
        }

        public void showWindow(string nameOfVirus, string descriptionOfVirus)
        {
            virusNameBox.Text = nameOfVirus;
            descriptionBox.Text = descriptionOfVirus;
            this.ShowDialog();
        }

        public void close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
