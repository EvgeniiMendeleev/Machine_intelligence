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

            string nameOfFrame = framesListBox.SelectedItem.ToString();
            for (int j = 0; j < frames[nameOfFrame].getCountSlots(); j++)
            {
                if (slotSettings[0] == frames[nameOfFrame].getSlot(j).getName())
                {
                    showError("Ошибка добавления слота!", "Такой слот уже определён в кадре!");
                    return;
                }
            }

            if (slotSettings[2] != "FRAME")
            {
                Slot slotForFrame = Slot.createSlot(slotSettings[0], slotSettings[2], slotSettings[1], slotSettings[3]);
                frames[nameOfFrame].setSlot(slotForFrame);
                return;
            }

            for (int i = 0; i < framesListBox.Items.Count; i++)
            {
                if (framesListBox.Items[i].ToString() != slotSettings.Last<string>()) continue;

                Slot slotForFrame = Slot.createSlot(slotSettings[0], slotSettings[2], slotSettings[1], slotSettings[3]);
                frames[nameOfFrame].setSlot(slotForFrame);
                return;
            }

            showError("Ошибка добавления слота!", "Такого кадра нету в списке!");
        }

        private void deleteSlotFromFrame(object sender, EventArgs e)
        {
            if(frameInfoView.SelectedItems.Count == 0)
            {
                showError("Ошибка удаления слота!", "Выберите слот для удаления из кадра в информации о кадре!");
                return;
            }

            string nameOfFrame = frameNameText.Text;
            frames[nameOfFrame].deleteSlot(frameInfoView.SelectedItems[0].Text);

            showInfoAboutFrameOnName(nameOfFrame);
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

            if (framesListBox.Items.Contains(nameOfFrame))
            {
                showError("Ошибка добавления кадра!", "Такой кадр уже определён в списке кадров!");
                return;
            }

            frames.Add(nameOfFrame, Frame.createFrame());
            framesListBox.Items.Add(nameOfFrame);

            nameOfFrameTextBox.Clear();
        }
        //TODO: Не написнаа функция удаления кадра!
        private void deleteFrame(object sender, EventArgs e)
        {
            if (framesListBox.SelectedItems.Count == 0)
            {
                showError("Ошибка удаления!", "Не был выбран кадр!");
                return;
            }

            string nameOfFrame = framesListBox.SelectedItem.ToString();
            List<string> keys = new List<string>(frames.Keys);

            for (int i = 0; i < keys.Count; i++)
            {
                string keyName = keys[i];
                for (int j = 0; j < frames[keyName].getCountSlots(); j++)
                {
                    Slot slot = frames[keyName].getSlot(j);

                    if (slot.getData() == nameOfFrame)
                    {
                        frames[keyName].deleteSlot(slot.getName());
                    }
                }
            }

            frames.Remove(nameOfFrame);
            framesListBox.Items.Remove(nameOfFrame);
        }
        private void showInfoAboutFrameOnName(string name)
        {
            frameInfoView.Items.Clear();
            Frame selectedFrame = frames[name];

            frameNameText.Text = name;
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
        private void showInfoAboutFrame(object sender, EventArgs e)
        {
            if (framesListBox.SelectedItem == null)
            {
                showError("Ошибка отображения!", "Не был выбран кадр!");
                return;
            }

            string nameOfFrame = framesListBox.SelectedItem.ToString();
            showInfoAboutFrameOnName(nameOfFrame);
        }
        #endregion
    }
}
