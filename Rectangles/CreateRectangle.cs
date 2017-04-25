using System;
using Shapes;

namespace Rectangles
{
    class CreateRectangle: CreateShape
    {
        private static CreateRectangle instance;
        public override Shape Create()
        {
            return new Rectangle();
        }
        public static CreateRectangle getInstance()
        {
            if (instance == null)
                instance = new CreateRectangle();
            return instance;
        }
    }
}
