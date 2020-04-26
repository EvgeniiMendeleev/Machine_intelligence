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
    public partial class Form1 : Form
    {
        private List<Frame> frames = new List<Frame>();

        public Form1()
        {
            InitializeComponent();
        }

        private void showError(string nameOfError, string textOfError)
        {
            MessageBox.Show(textOfError, nameOfError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void getInfoAboutProgram(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void enterANameFrame(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addFrame(sender, e);
            }
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

        private void showFrameAddSettings(object sender, EventArgs e)
        {
            SlotAddSettings window = new SlotAddSettings();

            if (window.ShowDialog() == DialogResult.Yes)
            {
                foreach (string str in window.getDatasFromForm())
                {
                }
            }
        }

        private void addFrame(object sender, EventArgs e)
        {
            if (nameOfFrameTextBox.Text.Length == 0)
            {
                showError("Ошибка", "Какая - то ошибка!");
                return;
            }

            foreach (char ch in nameOfFrameTextBox.Text)
            {
                if (ch != ' ' && !Char.IsLetter(ch))
                {
                    showError("Ошибка ввода!", "Присутствуют посторонние символы в названии кадра");
                }
            }

            List<string> splitNameOfFrame = new List<string>(nameOfFrameTextBox.Text.Split(' '));
            while (splitNameOfFrame.IndexOf("") != -1) splitNameOfFrame.Remove("");

            string nameOfFrame = getConnectedString(ref splitNameOfFrame);

            frames.Add(Frame.createFrame(nameOfFrame));
            framesListBox.Items.Add(nameOfFrame);

            nameOfFrameTextBox.Clear();
        }

        private void deleteFrame(object sender, EventArgs e)
        {
            /*if (framesListBox.SelectedItems.Count == 0)
            {
                showError("Ошибка удаления!", "Не был выбран кадр!");
                return;
            }

            Console.WriteLine("*****************ДО**************************");
            foreach (Frame frame in frames)
            {
                Console.WriteLine(frame.getName());
            }

            string deleteNameFrame = framesListBox.SelectedItem.ToString();
            
            for (int i = 0; i < frames.Count; i++)
            {
                if (frames[i].getName() == deleteNameFrame)
                {
                    frames.RemoveAt(i);
                    framesListBox.Items.Remove(framesListBox.SelectedItem);
                    break;
                }
            }

            for (int i = 0; i < frames.Count; i++)
            {
                frames[i].deleteSlot(deleteNameFrame);
            }

            Console.WriteLine("*****************ПОСЛЕ***********************");
            foreach (Frame frame in frames)
            {
                Console.WriteLine(frame.getName());
            }*/
        }

        private void showInfoAboutFrame(object sender, EventArgs e)
        {
            if (framesListBox.SelectedItems.Count == 0)
            {
                showError("Ошибка отображения!", "Не был выбран кадр!");
                return;
            }

            Frame selectedFrame = frames.Find(frame => frame.getName() == framesListBox.SelectedItem.ToString());

            frameNameText.Text = selectedFrame.getName();
            for (int i = 0; i < selectedFrame.getCountSlots(); i++)
            {
                Slot slot = selectedFrame.getSlot(i);
                
                ListViewItem item = new ListViewItem();
                item.Text = slot.getName();
                item.SubItems.Add(slot.getPtrToInheritance());
                item.SubItems.Add(slot.getPtrToType());
                item.SubItems.Add(slot.getData().ToString());

                frameInfoView.Items.Add(item);
            }
        }
    }
}
