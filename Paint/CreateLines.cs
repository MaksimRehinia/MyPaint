using System;
using System.Drawing;

namespace Paint
{
    class CreateLines : ICreate
    {
        public Shape Create()
        {
            return new Lines();
        }
    }
}