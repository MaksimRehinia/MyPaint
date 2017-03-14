using System;
using System.Drawing;

namespace Paint
{    
    [Serializable]   
    abstract class IShape
    {
        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }
        public Pen P { get; set; }

        public abstract void Draw(ref Graphics drawArea);
        public abstract void Draw(ref Graphics drawArea, ref Pen p, bool ShiftPressed);
    }
}