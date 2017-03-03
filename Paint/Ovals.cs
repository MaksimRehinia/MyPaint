using System;
using System.Drawing;

namespace Paint
{
    class Ovals: ClassShape
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public Ovals(Pen Pen, int X, int Y, int length, int height): base(Pen, X, Y)
        {
            Length = length;
            Height = height;
        }
        public override void Draw(Graphics drawArea)
        {
            drawArea.DrawEllipse(Pen, X, Y, Length, Height);
        }
    }
}
