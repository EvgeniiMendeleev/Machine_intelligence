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
                if (value == "null")
                {
                    ifRemoved();
                    return;
                }
                if (value == "") return;

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
    }

    class Frame
    {
        string name;
        List<Slot> slots = new List<Slot>();
    }
}
