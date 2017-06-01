using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Drawing;

using Shapes;
using Interfaces;

namespace ComplexShapes
{
    [KnownType(typeof(ComplexShape))]
    [DataContract]
    public class ComplexShape : Shape, ISelectable, IEditable
    {
        [DataMember]
        public List<ShapeWithDelta> Shapes { get; set; }

        [DataMember]
        public int InitWidth { get; set; }

        [DataMember]
        public int InitHeight { get; set; }

        public ComplexShape(List<ShapeWithDelta> shapes, int initWidth, int initHeight)
        {
            Shapes = shapes;
            InitWidth = initWidth;
            InitHeight = initHeight;
        }

        public override void Draw(Graphics graphics, Pen pen, bool shiftPressed)
        {
            int initX; int finalX; int initY; int finalY;
            if (FirstPoint.X > SecondPoint.X)
            {
                initX = SecondPoint.X;
                finalX = FirstPoint.X;
            }
            else
            {
                initX = FirstPoint.X;
                finalX = SecondPoint.X;
            }

            if (FirstPoint.Y > SecondPoint.Y)
            {
                initY = SecondPoint.Y;
                finalY = FirstPoint.Y;
            }
            else
            {
                initY = FirstPoint.Y;
                finalY = SecondPoint.Y;
            }

            foreach (ShapeWithDelta shape in Shapes)
            {                
                int tempInitX = initX + shape.DeltaX * Math.Abs(SecondPoint.X - FirstPoint.X) / InitWidth;
                int tempInitY = initY + shape.DeltaY * Math.Abs(SecondPoint.Y - FirstPoint.Y) / InitHeight;
                shape.Config.CurrentFigure.FirstPoint = new Point(tempInitX, tempInitY);

                int tempFinX = tempInitX + Math.Abs(SecondPoint.X - FirstPoint.X) * shape.Width / InitWidth;
                int tempFinY = tempInitY + Math.Abs(SecondPoint.Y - FirstPoint.Y) * shape.Height / InitHeight;
                shape.Config.CurrentFigure.SecondPoint = new Point(tempFinX, tempFinY);                
                shape.Config.CurrentFigure.Draw(graphics, pen, shiftPressed);
            }
        }
    }
}
