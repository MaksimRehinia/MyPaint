using System;
using System.Drawing;

namespace Paint
{
    class CreateLine : ICreate
    {
        public IShape Create(params Point[] pt)
        {
            return new Lines(pt);
        }
    }
}