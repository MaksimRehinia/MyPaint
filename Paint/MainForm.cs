using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        internal Graphics drawArea;//поле для рисования фигур
        private IShape drawable = null;
        private Pen pen = new Pen(Color.Black, 2);                
        bool lKeyPressed, ShiftPressed = false;        
        private Point initPoint, currPoint;
        enum Figure
        {
            None,
            Line,
            Rectangle,
            Oval,            
        }
        Figure SelectedShape = Figure.None;
        public MainForm()
        {
            InitializeComponent();            
        }

        private void SetDrawable(Point pt1, Point pt2)
        {
            switch (SelectedShape)
            {
                case Figure.None:
                    break;
                case Figure.Line:
                    drawable = new Lines(pt1, pt2);
                    break;
                case Figure.Oval:
                    drawable = new Ovals(pt1, pt2);
                    break;
                case Figure.Rectangle:
                    drawable = new Rectangles(pt1, pt2);
                    break;                                   
                default:
                    break;
            }
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
                        SelectedShape = Figure.Line;
                        break;
                    }
                case "Oval":
                    {
                        SelectedShape = Figure.Oval;
                        break;
                    }
                case "Rectangle":
                    {
                        SelectedShape = Figure.Rectangle;
                        break;
                    }               
            }            
        }

        private void button_Color_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog.ShowDialog();
            if (D == DialogResult.OK)
            {
                pen.Color = button_Color.ForeColor = colorDialog.Color;                
            }
        }        

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedShape != Figure.None)
            {
                initPoint = e.Location;                
            }
            lKeyPressed = true;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Point currPoint = (e as MouseEventArgs).Location;
            SetDrawable(initPoint, currPoint);
            if (SelectedShape != Figure.None)
            {
                drawable.Draw(ref drawArea, ref pen, ShiftPressed);                
            }
            lKeyPressed = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            drawArea = pictureBox.CreateGraphics();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            pictureBox.Refresh();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (lKeyPressed)
            {
                if ((SelectedShape == Figure.Line) && (!ShiftPressed))
                {
                    currPoint = initPoint;
                    initPoint = e.Location;
                    drawable = new Lines(currPoint, initPoint);
                    drawable.Draw(ref drawArea, ref pen, ShiftPressed);
                }
            }
        }

        private void textBoxPenWidth_TextChanged(object sender, EventArgs e)
        {
            pen.Width = int.Parse((sender as TextBox).Text);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)            
                ShiftPressed = true;             
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            ShiftPressed = false;
        }
    }
}
