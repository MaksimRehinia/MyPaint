using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Paint
{
    [KnownType(typeof(Lines))]
    [DataContract]
    class Lines: Shape
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