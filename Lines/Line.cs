using System;
using System.Drawing;
using System.Runtime.Serialization;
using Shapes;
using Interfaces;

namespace Lines
{
    [KnownType(typeof(Line))]
    [DataContract]
    public class Line: Shape
    {
        public override void Draw(Graphics drawArea, Pen P, bool shiftPressed)
        {
            drawArea.DrawLine(P, FirstPoint, SecondPoint);
        }

        public override void Select(Graphics graphics)
        {
            var pen = new Pen(Color.Red, 2F);
            pen.DashPattern = new float[] { 4, 3 };
            graphics.DrawLine(pen, FirstPoint, SecondPoint);
        }
    }
}
