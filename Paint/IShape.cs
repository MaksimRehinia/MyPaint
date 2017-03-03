using System;
using System.Drawing;

namespace Paint
{
    interface IShape
    {
        //void SetPoints(params Point[] pt);
        void Draw(ref Graphics drawArea, ref Pen p, bool ShiftPressed);
    }
}
