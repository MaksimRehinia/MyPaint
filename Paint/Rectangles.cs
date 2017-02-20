using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class Rectangles: ClassShape
    {
        public int length { get; set; }
        public int hight { get; set; }
        public Rectangles(Pen pen, int x, int y, int length, int hight): base(pen, x, y)
        {
            this.length = length;
            this.hight = hight;
        }
        public override void Draw(Graphics drawArea)
        {
            drawArea.DrawRectangle(pen, x, y, length, hight);
        }
    }
}
