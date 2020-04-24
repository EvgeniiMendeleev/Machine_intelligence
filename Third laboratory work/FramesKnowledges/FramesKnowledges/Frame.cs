using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramesModel
{
    enum PointerOnAttribute {  }
    enum TypeOfData { FRAME, INTEGER, REAL, BOOL, LISP, TEXT, LIST }
    struct Slot
    {
        string name;
    }

    class Frame
    {
        string name;
        PointerOnAttribute ptr;
        List<Slot> slots = new List<Slot>();
    }
}
