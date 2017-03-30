using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Paint
{
    [KnownType(typeof(Lines))]
    [DataContract]
    class Lines: Shape
    {             
        public override void Draw(Graphics drawArea, Pen P)
        {
            drawArea.DrawLine(P, FirstPoint, SecondPoint);
        }

        public override void Draw(Graphics drawArea, Pen P, bool shiftPressed)
        {                                   
            drawArea.DrawLine(P, FirstPoint, SecondPoint);            
        }
    }
}