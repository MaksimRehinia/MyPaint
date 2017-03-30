using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Paint
{        
    [KnownType(typeof(Shape))]
    [DataContract]
    abstract class Shape
    {
        [DataMember]
        public Point FirstPoint { get; set; }
        [DataMember]
        public Point SecondPoint { get; set; }        

        public abstract void Draw(Graphics drawArea, Pen P);
        public abstract void Draw(Graphics drawArea, Pen P, bool ShiftPressed);
    }
}