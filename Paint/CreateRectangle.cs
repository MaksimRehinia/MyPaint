using System;
using System.Drawing;

namespace Paint
{
    class CreateRectangle : ICreate
    {
        public Shape Create()
        {
            return new Rectangles();
        }
    }
}