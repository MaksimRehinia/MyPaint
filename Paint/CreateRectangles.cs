using System;
using System.Drawing;

namespace Paint
{
    class CreateRectangles : ICreate
    {
        private static CreateRectangles instance;
        public Shape Create()
        {
            return new Rectangles();
        }
        public static CreateRectangles getInstance()
        {
            if (instance == null)
                instance = new CreateRectangles();
            return instance;
        }
    }
}