using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FramesModel;

namespace FramesKnowledges
{
    public partial class ResultWindow : Form
    {
        public ResultWindow(string nameOfVirus, PrintLisp lisp)
        {
            InitializeComponent();
            virusNameTextBox.Text = nameOfVirus;
            if (lisp == null)
            {
                decriptionProblemTextBox.Text = "Решения проблемы не найдено!";
            }
            else
            {
                lisp.setTextBox(decriptionProblemTextBox);
                lisp.execute();
            }
        }

        public void closeWindow(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
