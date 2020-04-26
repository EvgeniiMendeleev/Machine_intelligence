using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramesModel
{
    enum TypeOfData { FRAME, INTEGER, REAL, BOOL, LISP, ТЕХТ, LIST }
    enum TypeOfInheritance { Unique, Same, Range, Override }
    class Slot
    {
        private string name;
        TypeOfData ptrToType;
        TypeOfInheritance ptrToInheritance;
        private object data
        {
            set
            {
                if (value.ToString() == "null")
                {
                    ifRemoved();
                    return;
                }
                if (value.ToString() == "") return;

                ifAdded();
                data = value;
            }

            get
            {
                if (data == null) ifNeeded(); 
                return data; 
            }
        }

        private void ifAdded()
        {
        }

        private void ifNeeded()
        {
        }

        private void ifRemoved()
        {
        }

        delegate void connectedProcedure();

        public string getName()
        {
            return this.name;
        }

        public string getPtrToType()
        {
            switch (this.ptrToType)
            {
                case TypeOfData.BOOL:
                    return "BOOL";
                case TypeOfData.FRAME:
                    return "FRAME";
                case TypeOfData.INTEGER:
                    return "INTEGER";
                case TypeOfData.LISP:
                    return "LISP";
                case TypeOfData.LIST:
                    return "LIST";
                case TypeOfData.REAL:
                    return "REAL";
                case TypeOfData.ТЕХТ:
                    return "TEXT";
                default:
                    return null;
            }
        }

        public string getPtrToInheritance()
        {
            switch (this.ptrToInheritance)
            {
                case TypeOfInheritance.Override:
                    return "O";
                case TypeOfInheritance.Range:
                    return "R";
                case TypeOfInheritance.Same:
                    return "S";
                case TypeOfInheritance.Unique:
                    return "U";
                default:
                    return null;
            }
        }

        public object getData()
        {
            return this.data;
        }
    }

    class Frame
    {
        string name;
        List<Slot> slots = new List<Slot>();

        private Frame(string name)
        {
            this.name = name;
        }

        public static Frame createFrame(string name)
        {
            return new Frame(name);
        }

        public Slot getSlot(string name)
        {
            return slots.Find(nameSlot => nameSlot.getName() == name);
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

        public string getName()
        {
            return this.name;
        }
    }
}
