using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Paint
{
    [KnownType(typeof(Lines))]
    [DataContract]
    class Lines: IShape
    {             
        public override void Draw(ref Graphics drawArea)
        {
            drawArea.DrawLine(P, FirstPoint, SecondPoint);
        }

        public override void Draw(ref Graphics drawArea, bool shiftPressed)
        {                                   
            drawArea.DrawLine(P, FirstPoint, SecondPoint);            
        }
    }
}