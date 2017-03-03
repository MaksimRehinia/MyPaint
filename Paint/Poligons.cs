using System;
using System.Drawing;

namespace Paint
{
    class Poligons: ClassShape
    {
        public Point[] Points { get; set; }
        public Poligons(Pen Pen, int X, int Y, params int[] coord) :base(Pen, X, Y)
        {
            Points = new Point[coord.Length / 2 + 1 + 1];
            Points[0] = new Point(X, Y);
            int k = 1;
            for (int i = 0; i < coord.Length; i += 2)
            {
                Points[k++] = new Point(coord[i], coord[i + 1]);
            }
            Points[k] = new Point(X, Y);
        }
        public override void Draw(Graphics drawArea)
        {
            drawArea.DrawLines(Pen, Points);
        }
    }
}
