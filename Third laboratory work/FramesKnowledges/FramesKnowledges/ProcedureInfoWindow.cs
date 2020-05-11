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
    public partial class ProcedureInfoWindow : Form
    {
        public ProcedureInfoWindow(string name, List<string> param)
        {
            InitializeComponent();
            prodNameTextBox.Text = name;

            string result = param.First<string>();
            for (int i = 1; i < param.Count; i++)
            {
                result += ", " + param[i];
            }

            paramsTextBox.Text = result;
        }

        public void closeWindow(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
