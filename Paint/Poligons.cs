using System;
using System.Drawing;

namespace Paint
{
    class Poligons: ClassShape
    {
        public Point[] points { get; set; }
        public Poligons(Pen pen, int x, int y, params int[] coord) :base(pen, x, y)
        {
            points = new Point[coord.Length / 2 + 1 + 1];
            points[0] = new Point(x, y);
            int k = 1;
            for (int i = 0; i < coord.Length; i += 2)
            {
                points[k++] = new Point(coord[i], coord[i + 1]);
            }
            points[k] = new Point(x, y);
        }
        public override void Draw(Graphics drawArea)
        {
            drawArea.DrawLines(pen, points);
        }
    }
}
