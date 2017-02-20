using System;
using System.Drawing;

namespace Paint
{
    abstract class ClassShape
    {
        public Pen pen { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public ClassShape(Pen pen, int x, int y)
        {
            this.pen = pen;
            this.x = x;
            this.y = y;    
        }        
        public abstract void Draw(Graphics drawArea);   
    }
}
