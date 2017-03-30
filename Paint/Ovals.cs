using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Paint
{
    [KnownType(typeof(Ovals))]
    [DataContract]
    class Ovals: Shape
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
        public override void Draw(Graphics drawArea, Pen P)
        {
            if (shiftPressed)
                drawArea.DrawEllipse(P, FirstPoint.X, FirstPoint.Y, Width, Width);
            else
                drawArea.DrawEllipse(P, FirstPoint.X, FirstPoint.Y, Width, Height);
        }

        public override void Draw(Graphics drawArea, Pen P, bool shiftPressed)
        {                        
            this.shiftPressed = shiftPressed;

            if (shiftPressed)
                drawArea.DrawEllipse(P, FirstPoint.X, FirstPoint.Y, Width, Width);
            else
                drawArea.DrawEllipse(P, FirstPoint.X, FirstPoint.Y, Width, Height);
        }
    }
}
