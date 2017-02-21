using System;
using System.Drawing;

namespace Paint
{
    class Ovals: ClassShape
    {
        public int length { get; set; }
        public int height { get; set; }
        public Ovals(Pen pen, int x, int y, int length, int height): base(pen, x, y)
        {
            this.length = length;
            this.height = height;
        }
        public override void Draw(Graphics drawArea)
        {
            drawArea.DrawEllipse(pen, x, y, length, height);
        }
    }
}
