using System;
using System.Drawing;

namespace Paint
{
    class Lines: ClassShape
    {
        public int x2 { get; set; }
        public int y2 { get; set; }
        public Lines(Pen pen, int x, int y, int x2, int y2): base(pen, x, y)
        {
            this.x2 = x2;
            this.y2 = y2;
        }
        public override void Draw(Graphics drawArea)
        {
            drawArea.DrawLine(pen, x, y, x2, y2);
        }
    }
}
