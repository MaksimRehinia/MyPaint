using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Paint
{
    [DataContract]
    class Configs
    {
        [DataMember]
        public Color Color { set; get; }
        [DataMember]
        public float Thickness { set; get; }
        [DataMember]
        public IShape CurrentFigure { set; get; }

        public Configs()
        {
            Color = Color.Black;
            Thickness = 4;
            CurrentFigure = null;
        }
        public Configs(Configs conf)
        {
            Color = conf.Color;
            CurrentFigure = conf.CurrentFigure;
            Thickness = conf.Thickness;
        }
    }
}
