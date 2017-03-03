using System;
using System.Drawing;

namespace Paint
{
    class Rectangles: IShape
    {
        private Point FirstPoint;  // верхняя левая вершина
        private Point SecondPoint; // нижняя правая вершина
        public int Height
        {
            get
            {               
                return (SecondPoint.Y - FirstPoint.Y);
            }
        }
        public int Width
        {
            get
            {                                                
                return (SecondPoint.X - FirstPoint.X);
            }
        }
        public Rectangles(params Point[] pt)
        {
            FirstPoint = pt[0];
            SecondPoint = pt[1];
        }        
        public void Draw(ref Graphics drawArea, ref Pen p, bool ShiftPressed)
        {
            if ((FirstPoint.X > SecondPoint.X) && (FirstPoint.Y < SecondPoint.Y))
            {
                Point temp = FirstPoint;
                FirstPoint = SecondPoint;
                SecondPoint = temp;
            }  
            if (ShiftPressed)           
                drawArea.DrawRectangle(p, FirstPoint.X, FirstPoint.Y, Width, Width);            
            else            
                drawArea.DrawRectangle(p, FirstPoint.X, FirstPoint.Y, Width, Height);            
        }
    }
}
