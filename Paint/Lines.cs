using System;
using System.Drawing;

namespace Paint
{
    class Lines: IShape
    {
        private Point FirstPoint;  // верхняя левая вершина
        private Point SecondPoint; // нижняя правая вершина
        
        public Lines(params Point[] pt)
        {
            FirstPoint = pt[0];
            SecondPoint = pt[1];
        }
        public void Draw(ref Graphics drawArea, ref Pen p, bool ShiftPressed)
        {            
            drawArea.DrawLine(p, FirstPoint, SecondPoint);            
        }
    }
}
