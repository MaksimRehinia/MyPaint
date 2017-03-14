using System;
using System.Drawing;

namespace Paint
{
    class CreateRectangle : ICreate
    {
        public IShape Create()
        {
            return new Rectangles();
        }
    }
}