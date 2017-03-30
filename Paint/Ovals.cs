using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Paint
{
    [KnownType(typeof(Ovals))]
    [DataContract]
    class Ovals: IShape
    {            
        private bool shiftPressed;       

        public int Height
        {
            get
            {                
                return (SecondPoint.Y - FirstPoint.Y);                
            }
        }
        public int Width
        {
            get
            {              
                return (SecondPoint.X - FirstPoint.X);                
            }
        }        
        public override void Draw(ref Graphics drawArea)
        {
            if (shiftPressed)
                drawArea.DrawEllipse(P, FirstPoint.X, FirstPoint.Y, Width, Width);
            else
                drawArea.DrawEllipse(P, FirstPoint.X, FirstPoint.Y, Width, Height);
        }

        public override void Draw(ref Graphics drawArea, bool shiftPressed)
        {                        
            this.shiftPressed = shiftPressed;

            if (shiftPressed)
                drawArea.DrawEllipse(P, FirstPoint.X, FirstPoint.Y, Width, Width);
            else
                drawArea.DrawEllipse(P, FirstPoint.X, FirstPoint.Y, Width, Height);
        }
    }
}
