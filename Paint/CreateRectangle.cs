using System;
using System.Drawing;

namespace Paint
{
    class CreateRectangle : ICreate
    {
        public IShape Create(params Point[] pt)
        {
            return new Rectangles(pt);
        }
    }
}