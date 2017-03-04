using System;
using System.Drawing;

namespace Paint
{
    interface IShape
    {        
        void Draw(ref Graphics drawArea, ref Pen p, bool ShiftPressed);
    }
}
