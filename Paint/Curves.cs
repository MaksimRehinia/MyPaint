using System;
using System.Drawing;

namespace Paint
{
    class Curves: ClassShape
    {       
        public Point[] points { get; set; }     
        public Curves(Pen pen, int x, int y, params int[] coord) :base(pen, x, y)
        {
            points = new Point[coord.Length/2 + 1];
            points[0] = new Point(x, y);
            int k = 1;
            for (int i = 0; i < coord.Length; i += 2)
            {
                points[k++] = new Point(coord[i], coord[i + 1]);
            }
        }
        public override void Draw(Graphics drawArea)
        {            
            drawArea.DrawCurve(pen, points);
        }
    }
}
