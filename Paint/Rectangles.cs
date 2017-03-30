using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Paint
{
    [KnownType(typeof(Rectangles))]
    [DataContract]
    class Rectangles: IShape
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
                drawArea.DrawRectangle(P, FirstPoint.X, FirstPoint.Y, Width, Width);
            else
                drawArea.DrawRectangle(P, FirstPoint.X, FirstPoint.Y, Width, Height);
        }

        public override void Draw(ref Graphics drawArea, bool shiftPressed)
        {                                     
            this.shiftPressed = shiftPressed;

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