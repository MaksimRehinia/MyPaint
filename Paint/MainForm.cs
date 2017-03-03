using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        internal Graphics drawArea;//поле для рисования фигур
        Color CurrentColor = Color.Black;
        enum Figure
        {
            None,
            Line,
            Rectangle,
            Oval,
            Triangle
        }
        Figure SelectedFigure;
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
        }

        private void checkedListBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
                if (checkedListBox.Items[i] != checkedListBox.SelectedItem)
                    checkedListBox.SetItemChecked(checkedListBox.Items.IndexOf(checkedListBox.Items[i]), false);

            switch (checkedListBox.SelectedItem.ToString())
            {
                case "Line":
                    {
                        SelectedFigure = Figure.Line;
                        break;
                    }
                case "Oval":
                    {
                        SelectedFigure = Figure.Oval;
                        break;
                    }
                case "Rectangle":
                    {
                        SelectedFigure = Figure.Rectangle;
                        break;
                    }
                case "Triangle":
                    {
                        SelectedFigure = Figure.Triangle;
                        break;
                    }
            }            
        }

        private void button_Color_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog.ShowDialog();
            if (D == DialogResult.OK)
            {
                CurrentColor = colorDialog.Color;                                
                button_Color.ForeColor = CurrentColor;
            }
        }
    }
}
