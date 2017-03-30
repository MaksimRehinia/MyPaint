using System;
using System.Drawing;

namespace Paint
{
    class CreateLine : ICreate
    {
        public Shape Create()
        {
            return new Lines();
        }
    }
}