using System;
using System.Drawing;

namespace Paint
{
    class CreateOvals : ICreate
    {
        public Shape Create()
        {
            return new Ovals();
        }
    }
}