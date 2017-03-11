using System;
using System.Drawing;

namespace Paint
{
    class CreateOval : ICreate
    {
        public IShape Create(params Point[] pt)
        {
            return new Ovals(pt);
        }
    }
}