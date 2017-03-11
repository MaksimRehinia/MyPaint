using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        internal Graphics drawArea;
        private ICreate fabric = null;
        private Pen pen = new Pen(Color.Black, 2);                
        private bool lKeyPressed, ShiftPressed = false;        
        private Point initPoint, currPoint;
                        
        public MainForm()
        {
            InitializeComponent();            
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            drawArea = pictureBox.CreateGraphics();
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
                        fabric = new CreateLine();
                        break;
                    }
                case "Oval":
                    {
                        fabric = new CreateOval();
                        break;
                    }
                case "Rectangle":
                    {
                        fabric = new CreateRectangle();
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
            if (fabric != null)
            {
                initPoint = e.Location;                
            }
            lKeyPressed = true;
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if ((lKeyPressed) && (fabric != null))
            {
                if ((fabric.GetType() == typeof(CreateLine)) && (!ShiftPressed))
                {
                    currPoint = initPoint;
                    initPoint = e.Location;
                    IShape shape = fabric.Create(currPoint, initPoint);
                    shape.Draw(ref drawArea, ref pen, ShiftPressed);
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Point currPoint = e.Location;            
            if (fabric != null)
            {
                IShape shape = fabric.Create(initPoint, currPoint);
                shape.Draw(ref drawArea, ref pen, ShiftPressed);
            }
            lKeyPressed = false;
        }        

        private void buttonClean_Click(object sender, EventArgs e)
        {
            pictureBox.Refresh();
        }        

        private void textBoxPenWidth_TextChanged(object sender, EventArgs e)
        {
            int width;
            if (int.TryParse((sender as TextBox).Text, out width))
                pen.Width = width;
            else
            {
                pen.Width = 2;
                (sender as TextBox).Text = "2";
            }                
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
