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
        private Dictionary<string, Frame> frames = new Dictionary<string, Frame>();

        public Form1()
        {
            InitializeComponent();
        }

        #region The info windows
        private void showError(string nameOfError, string textOfError)
        {
            MessageBox.Show(textOfError, nameOfError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void getInfoAboutProgram(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
        #endregion
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

        private void showSlotAddSettings(object sender, EventArgs e)
        {
            if (framesListBox.SelectedItem == null)
            {
                showError("Ошибка добавления слота!", "Для того, чтобы добавить слот, выберите кадр из списка!");
                return;
            }

            SlotAddSettings window = new SlotAddSettings();
            DialogResult result = window.ShowDialog();
            if (result == DialogResult.No || result == DialogResult.Cancel) return;

            List<string> slotSettings = window.getDatasFromForm();

            if (slotSettings[2] == "FRAME")
            {
                for (int i = 0; i < framesListBox.Items.Count; i++)
                {
                    if (framesListBox.Items[i].ToString() == slotSettings.Last<string>())
                    {
                        Slot slotForFrame = Slot.createSlot(slotSettings[0], slotSettings[1], slotSettings[2], slotSettings[3]);
                        frames[framesListBox.SelectedItem.ToString()].setSlot(slotForFrame);
                        return;
                    }
                }

                showError("Ошибка добавления слота!", "Такого кадра нету в списке!");
            }
        }

        private void deleteSlotFromFrame(object sender, EventArgs e)
        {
            if(frameInfoView.SelectedItems.Count == 0)
            {
                showError("Ошибка удаления слота!", "Выберите слот для удаления из кадра в информации о кадре!");
                return;
            }
        }

        #region The actions to frame
        private void addFrame(object sender, EventArgs e)
        {
            if (nameOfFrameTextBox.Text.Length == 0)
            {
                showError("Ошибка добавления кадра!", "Поле с названием кадра пустое!");
                return;
            }

            foreach (char ch in nameOfFrameTextBox.Text)
            {
                if (ch != ' ' && !Char.IsLetter(ch))
                {
                    showError("Ошибка ввода!", "Присутствуют посторонние символы в названии кадра");
                    return;
                }
            }

            List<string> splitNameOfFrame = new List<string>(nameOfFrameTextBox.Text.Split(' '));
            while (splitNameOfFrame.IndexOf("") != -1) splitNameOfFrame.Remove("");

            string nameOfFrame = getConnectedString(ref splitNameOfFrame);

            frames.Add(nameOfFrame, Frame.createFrame());
            framesListBox.Items.Add(nameOfFrame);

            nameOfFrameTextBox.Clear();
        }
        private void deleteFrame(object sender, EventArgs e)
        {
            if (framesListBox.SelectedItems.Count == 0)
            {
                showError("Ошибка удаления!", "Не был выбран кадр!");
                return;
            }
        }
        private void showInfoAboutFrame(object sender, EventArgs e)
        {
            if (framesListBox.SelectedItem == null)
            {
                showError("Ошибка отображения!", "Не был выбран кадр!");
                return;
            }

            frameInfoView.Items.Clear();

            string nameOfFrame = framesListBox.SelectedItem.ToString();
            Frame selectedFrame = frames[nameOfFrame];

            frameNameText.Text = nameOfFrame;
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
        #endregion
    }
}
