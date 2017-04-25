using System;
using System.Drawing;

namespace Interfaces
{
    public interface ISelectable
    {
        void Select(Graphics graphics);
        bool isInArea(Point point);
    }
}
