using System;
using System.Drawing;

namespace Paint
{
    class Rectangles: ClassShape
    {
        public int Length { get; set; }
        public int Height { get; set; }
        public Rectangles(Pen Pen, int X, int Y, int length, int height): base(Pen, X, Y)
        {
            Length = length;
            Height = height;
        }
        public override void Draw(Graphics drawArea)
        {
            drawArea.DrawRectangle(Pen, X, Y, Length, Height);
        }
    }
}
