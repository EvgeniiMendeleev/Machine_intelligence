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

        private string getProcessedInputString(string inputStr)
        {
            List<string> splitedInputStr = new List<string>(inputStr.Split(' '));
            while (splitedInputStr.IndexOf("") != -1) splitedInputStr.Remove("");

            return getConnectedString(ref splitedInputStr);
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

            List<string> slotSettings;
            using (SlotAddSettings window = new SlotAddSettings())
            {
                DialogResult result = window.ShowDialog();
                if (result == DialogResult.No || result == DialogResult.Cancel) return;

                slotSettings = window.getDatasFromForm();
            }

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

            if (nameOfFrame == slotSettings[3])
            {
                showError("Ошибка добавления слота!", "Нельзя хранить в кадре указатель на себя самого!");
                return;
            }

            for (int i = 0; i < framesListBox.Items.Count; i++)
            {
                if (framesListBox.Items[i].ToString() != slotSettings.Last<string>()) continue;

                Slot slotForFrame = Slot.createSlot(slotSettings[0], slotSettings[2], slotSettings[1], slotSettings[3]);
                string dautherFrameName = slotSettings[3];

                for (int j = 0; j < frames[nameOfFrame].getCountSlots(); j++)
                {
                    Slot slot = frames[nameOfFrame].getSlot(j);
                    if (slot.getPtrToType() == "FRAME") continue;
                    if (frames[dautherFrameName].isContaine(slot.getName())) continue;

                    string dataFromSlot = slot.getPtrToInheritance() == "Unique"? null : slot.Data;
                    frames[dautherFrameName].setSlot(Slot.createSlot(slot.getName(), slot.getPtrToType(), slot.getPtrToInheritance(), dataFromSlot));
                }

                frames[nameOfFrame].setSlot(slotForFrame);
                return;
            }

            showError("Ошибка добавления слота!", "Такого кадра нету в списке!");
        }
        private void showChangeDataSlotWindow(object sender, EventArgs e)
        {
            if (framesListBox.SelectedItem == null)
            {
                showError("Ошибка изменения значения!", "Не был выбран кадр!");
                return;
            }
            if (frameInfoView.SelectedItems.Count == 0)
            {
                showError("Ошибка изменения значения!", "Не выбран слот, в котором будет меняться значение!");
                return;
            }

            Slot slot = frames[framesListBox.SelectedItem.ToString()].getSlot(frameInfoView.SelectedItems[0].Text);
            if (slot.getPtrToInheritance() == "Same")
            {
                showError("Ошибка изменения значения!", "Слот с типом наследования \"Same\" изменить нельзя!");
                return;
            }

            string newData = null;
            using (ChangeDataSlotWindow window = new ChangeDataSlotWindow())
            {
                DialogResult result = window.ShowDialog();
                if (result == DialogResult.Cancel) return;

                newData = window.getDataFromForm();
            }

            switch (slot.getPtrToType())
            {
                case "FRAME":
                    if (!framesListBox.Items.Contains(newData) && newData != "")
                    {
                        showError("Ошибка изменения значения!", "Такого кадра нету в списке!");
                        return;
                    }

                    if (newData == "") break;

                    string dautherFrameName = newData;
                    string nameOfFrame = frameNameText.Text;
                    for (int j = 0; j < frames[nameOfFrame].getCountSlots(); j++)
                    {
                        Slot mySlot = frames[nameOfFrame].getSlot(j);
                        if (mySlot.getPtrToType() == "FRAME") continue;
                        if (frames[dautherFrameName].isContaine(mySlot.getName())) continue;

                        string dataFromSlot = mySlot.getPtrToInheritance() == "Unique" ? null : mySlot.Data;
                        frames[dautherFrameName].setSlot(Slot.createSlot(mySlot.getName(), mySlot.getPtrToType(), mySlot.getPtrToInheritance(), dataFromSlot));
                    }

                    break;
                case "BOOL":
                    if(newData != "true" && newData != "false" && newData != "")
                    {
                        showError("Ошибка изменения значения!", "В случае BOOL значение может быть или true, или false");
                        return;
                    }
                    break;
            }

            slot.Data = newData;
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

            frameInfoView.Items.Clear();
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

            string nameOfFrame = getProcessedInputString(nameOfFrameTextBox.Text);
            if (framesListBox.Items.Contains(nameOfFrame))
            {
                showError("Ошибка добавления кадра!", "Такой кадр уже определён в списке кадров!");
                return;
            }

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

            string nameOfFrame = framesListBox.SelectedItem.ToString();
            List<string> keys = new List<string>(frames.Keys);

            for (int i = 0; i < keys.Count; i++)
            {
                string keyName = keys[i];
                for (int j = 0; j < frames[keyName].getCountSlots(); j++)
                {
                    Slot slot = frames[keyName].getSlot(j);

                    if (slot.Data == nameOfFrame)
                    {
                        frames[keyName].deleteSlot(slot.getName());
                    }
                }
            }

            frames.Remove(nameOfFrame);
            framesListBox.Items.Remove(nameOfFrame);

            if (frameNameText.Text == nameOfFrame)
            { 
                frameInfoView.Items.Clear();
                frameNameText.Text = "";
            }
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
                item.SubItems.Add(slot.Data);

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
