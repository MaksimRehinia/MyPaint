using System;
using System.Collections.Generic;
using Shapes;

namespace ComplexShapes
{
    public class CreateComplexShape: CreateShape
    {
        List<ShapeWithDelta> Shapes { get; set; }
        int InitWidth { get; set; }
        int InitHeight { get; set; }

        public CreateComplexShape(List<ShapeWithDelta> shapes, int initWidth, int initHeight)
        {
            Shapes = shapes;
            InitWidth = initWidth;
            InitHeight = initHeight;
        }

        public override Shape Create()
        {
            return new ComplexShape(Shapes, InitWidth, InitHeight);
        }
    }
}
