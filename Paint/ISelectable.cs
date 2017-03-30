using System;
using System.Drawing;

namespace Paint
{
    interface ISelectable
    {
        void Select(Graphics graphics);
        bool isInArea(Point point);
    }
}
