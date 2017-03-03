using System;
using System.Drawing;

namespace Paint
{
    abstract class ClassShape
    {
        public Pen Pen { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ClassShape(Pen pen, int x, int y)
        {
            Pen = pen;
            X = x;
            Y = y;    
        }
        public abstract void Draw(Graphics drawArea); 
    }
}
