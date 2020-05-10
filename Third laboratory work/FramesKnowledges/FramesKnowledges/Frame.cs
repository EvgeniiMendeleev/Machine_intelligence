using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FramesModel
{
    interface ILisp
    {
        void execute();
    }

    class FindLisp : ILisp
    {
        private List<string> characteristics = new List<string>();
        private Dictionary<string, Frame> framesFromDB;
        private Dictionary<string, ILisp> lispsFromDB;
        private string nameOfRoot;
        private string resultFrame;

        public FindLisp(List<string> characteristics)
        {
            this.characteristics = characteristics;
        }
        public void setRootFrame(string nameOfFrame)
        {
            this.nameOfRoot = nameOfFrame;
        }
        public void setDatabase(ref Dictionary<string, Frame> framesFromDB, ref Dictionary<string, ILisp> lispsFromDB)
        {
            this.framesFromDB = framesFromDB;
            this.lispsFromDB = lispsFromDB;
        }
        public string getResultFrame()
        {
            return this.resultFrame;
        }
        public void execute()
        {
            Stack<string> vertexs = new Stack<string>();

            vertexs.Push(nameOfRoot);
            while (vertexs.Count > 0)
            {
                int coincidencedAttr = 0;
                string vertex = vertexs.Pop();

                for (int i = 0; i < framesFromDB[vertex].getCountSlots(); i++)
                {
                    Slot slot = framesFromDB[vertex].getSlot(i);
                    if (slot.getPtrToType() == "LISP") continue;

                    if (slot.getPtrToType() == "FRAME")
                    {
                        vertexs.Push(slot.Data);
                        continue;
                    }

                    if (characteristics.Contains(slot.Data))
                    {
                        ++coincidencedAttr;
                    }
                }

                if (coincidencedAttr >= characteristics.Count())
                {
                    resultFrame = vertex;
                    return;
                }
            }

            resultFrame = "NOT_FOUND_FRAME";
        }
    }

    class PrintLisp : ILisp
    {
        private string textInfo;
        private object textBox;

        public PrintLisp(string text)
        {
            this.textInfo = text;
        }

        public void execute()
        {
            (textBox as TextBox).AppendText(textInfo);
        }

        public void setTextBox(object textBox)
        {
            this.textBox = textBox;
        }
    }

    class Slot
    {
        private string name;
        private string ptrToType;
        private string ptrToInheritance;
        private string data;
        private Slot(string name, string ptrToType, string ptrToInheritance, string data) 
        {
            this.name = name;
            this.ptrToType = ptrToType;
            this.ptrToInheritance = ptrToInheritance;
            this.Data = data;
        }
        public static Slot createSlot(string name, string ptrToType, string ptrToInheritance, string data)
        {
            return new Slot(name, ptrToType, ptrToInheritance, data);
        }
        public string Data
        {
            set
            {
                if (value == null)
                {
                    ifRemoved();
                    return;
                }
                ifAdded(value);
            }
            get
            {
                if (data == null) ifNeeded(); 
                return data; 
            }
        }

        private void ifAdded(string value)
        {
            data = value;
        }

        private void ifNeeded()
        {
            data = "NOT_VALUE_EXCEPTION";
        }

        private void ifRemoved()
        {
            data = "EMPTY";
        }

        public string getName()
        {
            return this.name;
        }
        public string getPtrToType()
        {
            return this.ptrToType;
        }
        public string getPtrToInheritance()
        {
            return this.ptrToInheritance;
        }
    }

    class Frame
    {
        private List<Slot> slots = new List<Slot>();

        private Frame() { }

        public static Frame createFrame()
        {
            return new Frame();
        }

        public Slot getSlot(string name)
        {
            return slots.Find(nameSlot => nameSlot.getName() == name);
        }

        public void setSlot(Slot slot)
        {
            slots.Add(slot);
        }

        public Slot getSlot(int i)
        {
            return slots[i];
        }

        public int getCountSlots()
        {
            return slots.Count;
        }

        public void deleteSlot(string name)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].getName() == name)
                {
                    slots.RemoveAt(i);
                }
            }
        }
        public bool isContains(string nameOfSlot)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].getName() == nameOfSlot) return true;
            }
            return false;
        }
    }
}
