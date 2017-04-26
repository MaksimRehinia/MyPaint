using System;
using System.Drawing;
using System.Runtime.Serialization;
using Shapes;
using Interfaces;

namespace Rectangles
{
    [KnownType(typeof(Rectangle))]
    [DataContract]
    public class Rectangle: Shape
    {
        public override void Draw(Graphics drawArea, Pen P, bool shiftPressed)
        {
            Point temp1 = new Point(FirstPoint.X, FirstPoint.Y);
            Point temp2 = new Point(SecondPoint.X, SecondPoint.Y);
            if (shiftPressed)
            {
                if (SecondPoint.X > FirstPoint.X && SecondPoint.Y > FirstPoint.Y)
                    drawArea.DrawRectangle(P, FirstPoint.X, FirstPoint.Y, SecondPoint.Y - FirstPoint.Y, SecondPoint.Y - FirstPoint.Y);
                else if (SecondPoint.X < FirstPoint.X && SecondPoint.Y > FirstPoint.Y)
                    drawArea.DrawRectangle(P, FirstPoint.X - (SecondPoint.Y - FirstPoint.Y), FirstPoint.Y, SecondPoint.Y - FirstPoint.Y, SecondPoint.Y - FirstPoint.Y);
                else if (SecondPoint.X > FirstPoint.X && SecondPoint.Y < FirstPoint.Y)
                    drawArea.DrawRectangle(P, FirstPoint.X, SecondPoint.Y, FirstPoint.Y - SecondPoint.Y, FirstPoint.Y - SecondPoint.Y);
                else
                    drawArea.DrawRectangle(P, FirstPoint.X - (FirstPoint.Y - SecondPoint.Y), SecondPoint.Y, FirstPoint.Y - SecondPoint.Y, FirstPoint.Y - SecondPoint.Y);
            }
            else
            {
                if (SecondPoint.X > FirstPoint.X && SecondPoint.Y > FirstPoint.Y)
                    drawArea.DrawRectangle(P, FirstPoint.X, FirstPoint.Y, SecondPoint.X - FirstPoint.X, SecondPoint.Y - FirstPoint.Y);
                else if (SecondPoint.X < FirstPoint.X && SecondPoint.Y > FirstPoint.Y)
                    drawArea.DrawRectangle(P, SecondPoint.X, FirstPoint.Y, FirstPoint.X - SecondPoint.X, SecondPoint.Y - FirstPoint.Y);
                else if (SecondPoint.X > FirstPoint.X && SecondPoint.Y < FirstPoint.Y)
                    drawArea.DrawRectangle(P, FirstPoint.X, SecondPoint.Y, SecondPoint.X - FirstPoint.X, FirstPoint.Y - SecondPoint.Y);
                else
                    drawArea.DrawRectangle(P, SecondPoint.X, SecondPoint.Y, FirstPoint.X - SecondPoint.X, FirstPoint.Y - SecondPoint.Y);
            }

        }        
    }
}
