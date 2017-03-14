using System;
using System.Drawing;

namespace Paint
{
    [Serializable]
    class Lines: IShape
    {             
        public override void Draw(ref Graphics drawArea)
        {
            drawArea.DrawLine(P, FirstPoint, SecondPoint);
        }

        public override void Draw(ref Graphics drawArea, ref Pen p, bool shiftPressed)
        {
            P = p;                        

            drawArea.DrawLine(p, FirstPoint, SecondPoint);            
        }
    }
}