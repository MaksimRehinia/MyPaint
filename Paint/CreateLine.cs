using System;
using System.Drawing;

namespace Paint
{
    class CreateLine : ICreate
    {
        public IShape Create()
        {
            return new Lines();
        }
    }
}