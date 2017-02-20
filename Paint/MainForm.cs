using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();            
        }

        private Dictionary<string, ClassShape> CreateDictionary()
        {
            var map = new Dictionary<string, ClassShape>(5);
            map.Add("rect", new Rectangles() );
            map.Add("oval", new Ovals() );
            map.Add("line",new Lines() );
            map.Add("trian", new Triangles() );
            map.Add("curv", new Curves() );
            return map;                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var map = CreateDictionary();

            map["rect"].Draw(Color.Green, 50, 50, 50, 60);
            map["oval"].Draw(Color.Red, 100, 50, 50, 50);
            map["line"].Draw(Color.Blue, 160, 50, 170, 50);
            map["trian"].Draw(Color.Orange, 180, 30, 180, 60, 190, 50);
            map["curv"].Draw(Color.Purple, 200, 50, 220, 60);           
        }
    }
}
