using System;
using System.Drawing;

namespace Paint
{
    class Lines: ClassShape
    {
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public Lines(Pen Pen, int X, int Y, int x2, int y2): base(Pen, X, Y)
        {
            X2 = x2;
            Y2 = y2;
        }
        public override void Draw(Graphics drawArea)
        {
            drawArea.DrawLine(Pen, X, Y, X2, Y2);
        }
    }
}
