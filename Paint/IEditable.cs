using System;
using System.Drawing;

namespace Paint
{
    interface IEditable
    {
        void Relocate(Point newPoint);
    }
}