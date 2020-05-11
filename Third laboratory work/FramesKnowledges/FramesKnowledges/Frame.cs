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
        public List<string> getCharacters()
        {
            return characteristics;
        }
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

        private struct State
        {
            public string nameOfFrame;
            public int countOfCharacters;

            public State(string nameOfFrame, int countOfChars)
            {
                this.nameOfFrame = nameOfFrame;
                this.countOfCharacters = countOfChars;
            }
        };

        public void execute()
        {
            Stack<State> vertexs = new Stack<State>();

            vertexs.Push(new State(nameOfRoot, 0));
            while (vertexs.Count > 0)
            {
                State vertex = vertexs.Pop();
                int coincidencedAttr = vertex.countOfCharacters;

                foreach (Slot slot in framesFromDB[vertex.nameOfFrame].getSlots())
                {
                    if (slot.getPtrToType() == "LISP" || slot.getPtrToType() == "FRAME") continue;

                    switch (slot.getPtrToType())
                    {
                        case "TEXT":
                            if (characteristics.Contains(slot.Data)) ++coincidencedAttr;
                            break;
                        case "BOOL":
                            if (characteristics.Contains(slot.getName()) && slot.Data == "true") ++coincidencedAttr;
                            break;
                    }
                }

                if (coincidencedAttr >= characteristics.Count())
                {
                    resultFrame = vertex.nameOfFrame;
                    return;
                }

                foreach (Slot slot in framesFromDB[vertex.nameOfFrame].getSlots())
                {
                    if (slot.getPtrToType() == "FRAME")
                    {
                        vertexs.Push(new State(slot.Data, coincidencedAttr));
                    }
                }
            }

            resultFrame = "NOT_FOUND_FRAME";
        }
    }

    public class PrintLisp : ILisp
    {
        private string textInfo;
        private object textBox;

        public PrintLisp(string text)
        {
            this.textInfo = text;
        }

        public string getText()
        {
            return textInfo;
        }

        public void execute()
        {
            (textBox as TextBox).Text = textInfo;
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

        public List<Slot> getSlots()
        {
            return slots;
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
