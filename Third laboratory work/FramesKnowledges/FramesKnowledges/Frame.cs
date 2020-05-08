using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramesModel
{
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

        delegate void connectedProcedure();

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
        public bool isContaine(string nameOfSlot)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].getName() == nameOfSlot) return true;
            }
            return false;
        }
    }
}
