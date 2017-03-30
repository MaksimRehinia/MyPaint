using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Paint
{
    [DataContract]
    class Configs
    {
        [DataMember]
        public Color Color { get; set; }
        [DataMember]
        public float Width { get; set; }
        [DataMember]
        public Shape CurrentFigure { get; set; }

        public Configs()
        {
            Color = Color.Black;
            Width = 2;
            CurrentFigure = null;
        }
        public Configs(Configs conf)
        {
            Color = conf.Color;
            CurrentFigure = conf.CurrentFigure;
            Width = conf.Width;
        }
    }
}
