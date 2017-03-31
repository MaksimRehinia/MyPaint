using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Paint
{        
    [KnownType(typeof(Shape))]
    [DataContract]
    abstract class Shape: ISelectable, IEditable
    {
        [DataMember]
        public Point FirstPoint { get; set; }
        [DataMember]
        public Point SecondPoint { get; set; }        
        
        public abstract void Draw(Graphics drawArea, Pen P, bool ShiftPressed);

        public virtual bool isInArea(Point point)
        {
            var temp = new Point();
            temp.X = Math.Min(FirstPoint.X, SecondPoint.X);
            temp.Y = Math.Min(FirstPoint.Y, SecondPoint.Y);
            int length = Math.Abs(SecondPoint.X - FirstPoint.X);
            int height = Math.Abs(SecondPoint.Y - FirstPoint.Y);
            if (point.X >= temp.X && point.X <= temp.X + length &&
                point.Y >= temp.Y && point.Y <= temp.Y + height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void Select(Graphics graphics)
        {
            var pen = new Pen(Color.Red, 2F);
            pen.DashPattern = new float[] { 4, 3 };
            var temp = new Point();
            temp.X = Math.Min(FirstPoint.X, SecondPoint.X);
            temp.Y = Math.Min(FirstPoint.Y, SecondPoint.Y);
            int length = Math.Abs(SecondPoint.X - FirstPoint.X);
            int height = Math.Abs(SecondPoint.Y - FirstPoint.Y);
            graphics.DrawRectangle(pen, temp.X, temp.Y, length, height);
        }

        public virtual void Relocate(Point newPoint)
        {                    
            int differenceX = newPoint.X - FirstPoint.X;
            int differenceY = newPoint.Y - FirstPoint.Y;
            FirstPoint = new Point(FirstPoint.X + differenceX, FirstPoint.Y + differenceY);
            SecondPoint = new Point(SecondPoint.X + differenceX, SecondPoint.Y + differenceY);        
        }
    }
}