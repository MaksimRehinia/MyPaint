using System;
using System.Drawing;

namespace Paint
{
    class CreateOval : ICreate
    {
        public IShape Create()
        {
            return new Ovals();
        }
    }
}