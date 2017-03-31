using System;
using System.Drawing;

namespace Paint
{
    class CreateRectangles : ICreate
    {
        public Shape Create()
        {
            return new Rectangles();
        }
    }
}