using System;
using System.Runtime.Serialization;
using Config;

namespace ComplexShapes
{
    [KnownType(typeof(ShapeWithDelta))]
    [DataContract]
    public class ShapeWithDelta
    {
        [DataMember]
        public int DeltaX { get; set; }
        [DataMember]
        public int DeltaY { get; set; }
        [DataMember]
        public int Width { get; set; }
        [DataMember]
        public int Height { get; set; }
        [DataMember]
        public Configs Config { get; set; }

        public ShapeWithDelta(int deltaX, int deltaY, int width, int height, Configs config)
        {
            DeltaX = deltaX;
            DeltaY = deltaY;
            Width = width;
            Height = height;
            Config = config;
        }
    }
}
