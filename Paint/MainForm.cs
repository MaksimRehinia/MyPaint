using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        internal Graphics drawArea;//поле для рисования фигур
        public MainForm()
        {
            InitializeComponent();            
        }

        private Dictionary<string, ClassShape> CreateDictionary()
        {
            var map = new Dictionary<string, ClassShape>(5);
            map.Add("rect", new Rectangles(new Pen(Color.Green, 5), 50, 50, 50, 50 ) );
            map.Add("oval", new Ovals(new Pen(Color.Red, 1), 110, 50, 60, 40) );
            map.Add("line",new Lines(new Pen(Color.Blue, 3), 180, 50, 190, 100) );
            map.Add("polig", new Poligons(new Pen(Color.Orange, 2), 200, 30, 210, 100, 230, 50) );
            map.Add("curv", new Curves(new Pen(Color.Purple, 4), 240, 50, 270, 100, 300, 50, 330, 100) );
            return map;                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var map = CreateDictionary();

            drawArea = pictureBox1.CreateGraphics();
            map["rect"].Draw(drawArea);
            map["oval"].Draw(drawArea);
            map["line"].Draw(drawArea);
            map["polig"].Draw(drawArea);
            map["curv"].Draw(drawArea);
        }
    }
}
