using System;
using System.Drawing;

namespace Paint
{
    class CreateOval : ICreate
    {
        public Shape Create()
        {
            return new Ovals();
        }
    }
}