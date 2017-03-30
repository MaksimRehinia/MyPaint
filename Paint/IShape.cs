using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Paint
{        
    [KnownType(typeof(IShape))]
    [DataContract]
    abstract class IShape
    {
        [DataMember]
        public Point FirstPoint { get; set; }
        [DataMember]
        public Point SecondPoint { get; set; }
        [DataMember]
        public Pen P { get; set; }

        public abstract void Draw(ref Graphics drawArea);
        public abstract void Draw(ref Graphics drawArea, bool ShiftPressed);
    }
}