using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Text;

namespace Paint
{
    public partial class MainForm : Form
    {
        internal Graphics drawArea;
        private ICreate fabric = null;
        private List<Configs> shapeList = new List<Configs>();
        private Pen pen;                
        private bool shiftPressed = false;
        private bool moving = false;
        private Bitmap btmp_front, btmp_back;
        private Configs configs;
        private Configs selectedShape;        

        public MainForm()
        {
            InitializeComponent();            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            buttonRelocate.Enabled = false;
            buttonEdit.Enabled = false;
            configs = new Configs();
            pen = new Pen(configs.Color, configs.Width);            
            CleanField();
        }        

        private void CleanField()
        {            
            btmp_back = new Bitmap(pictureBox.Width, pictureBox.Height);
            btmp_front = new Bitmap(pictureBox.Width, pictureBox.Height);
            drawArea = Graphics.FromImage(btmp_front);
            pictureBox.BackgroundImage = btmp_back;
            pictureBox.Image = btmp_front;            
        }

        private void RedrawShapes()
        {
            CleanField();
            foreach (Configs shape in shapeList)
            {
                shape.CurrentFigure.Draw(drawArea, new Pen(shape.Color, shape.Width), shape.ShiftPressed);
            }
            btmp_back = (Bitmap)btmp_front.Clone();
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
                        fabric = CreateLines.getInstance();
                        break;
                    }
                case "Oval":
                    {                        
                        fabric = CreateOvals.getInstance();
                        break;
                    }
                case "Rectangle":
                    {
                        fabric = CreateRectangles.getInstance();
                        break;
                    }               
            }            
        }              

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (fabric != null)
                {
                    configs.CurrentFigure = fabric.Create();                    
                    configs.CurrentFigure.FirstPoint = new Point(e.X, e.Y);
                }
            }            
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (fabric != null))
            {
                configs.CurrentFigure.SecondPoint = new Point(e.X, e.Y);
                drawArea.Clear(Color.White);
                drawArea.DrawImage(btmp_back, 0, 0);
                configs.CurrentFigure.Draw(drawArea, pen, shiftPressed);
                pictureBox.Refresh();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            drawArea.Clear(Color.Transparent);
            drawArea.DrawImage(btmp_back, 0, 0);
            pictureBox.Refresh();
            if (moving)
            {
                shapeList.Remove(selectedShape);                
                fabric = null;
                if (checkedListBox.SelectedItem != null)
                {
                    checkedListBox.SetItemChecked(checkedListBox.Items.IndexOf(checkedListBox.SelectedItem), false);
                    checkedListBox.ClearSelected();
                }
                selectedShape.CurrentFigure.Relocate(new Point(e.X, e.Y));
                shapeList.Add(new Configs(selectedShape));
                RedrawShapes();                
                moving = false;
                selectedShape = null;                
                buttonRelocate.Enabled = false;
                buttonEdit.Enabled = false;
                return;
            }
            buttonRelocate.Enabled = false;
            buttonEdit.Enabled = false;
            selectedShape = null;
            if (e.Button == MouseButtons.Left)
            {
                if (fabric != null)
                {
                    configs.CurrentFigure.SecondPoint = new Point(e.X, e.Y);
                    configs.CurrentFigure.Draw(drawArea, pen, shiftPressed);
                    configs.Color = pen.Color;
                    configs.Width = pen.Width;
                    btmp_back = (Bitmap)btmp_front.Clone();                    
                    shapeList.Add(new Configs(configs));
                    pictureBox.Refresh();
                }                
            }
            if (e.Button == MouseButtons.Right)
            {
                var shapes = new List<Configs>(shapeList);
                for (int i = shapes.Count - 1; i >= 0; i--)
                {
                    if (shapes[i].CurrentFigure is ISelectable && shapes[i].CurrentFigure.isInArea(new Point(e.X, e.Y)))
                    {
                        shapes[i].CurrentFigure.Select(drawArea);                        
                        pictureBox.Refresh();
                        selectedShape = shapes[i];
                        if (selectedShape.CurrentFigure is IEditable)
                        {
                            buttonRelocate.Enabled = true;
                            buttonEdit.Enabled = true;                            
                        }
                        break;
                    }
                }
            }            
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog.ShowDialog();
            if (D == DialogResult.OK)
            {
                pen.Color = buttonColor.ForeColor = colorDialog.Color;
                if (selectedShape != null)
                {
                    shapeList.Remove(selectedShape);
                    selectedShape.Color = pen.Color;                    
                    shapeList.Add(new Configs(selectedShape));                    
                    RedrawShapes();
                    buttonEdit.Enabled = false;
                    buttonRelocate.Enabled = false;
                    selectedShape = null;
                }
            }            
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            shapeList.Clear();
            CleanField();            
        }        

        private void textBoxPenWidth_TextChanged(object sender, EventArgs e)
        {
            float width;
            if (float.TryParse((sender as TextBox).Text, out width))
            {
                pen.Width = width;
                if (selectedShape != null)
                {
                    shapeList.Remove(selectedShape);                    
                    selectedShape.Width = pen.Width;
                    shapeList.Add(new Configs(selectedShape));
                    RedrawShapes();
                    buttonEdit.Enabled = false;
                    buttonRelocate.Enabled = false;
                    selectedShape = null;
                }
            }                
            else
            {
                pen.Width = 2F;
                (sender as TextBox).Text = "2";
            }                
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            if (File.Exists(saveFileDialog.FileName))            
                File.Delete(saveFileDialog.FileName);

            JsonSerializer serializer = new JsonSerializer();
            serializer.TypeNameHandling = TypeNameHandling.All;
            try
            {                
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))                
                {
                    BsonWriter writer = new BsonWriter(fs);                                        
                    serializer.Serialize(writer, shapeList);                 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }  
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            JsonSerializer deserializer = new JsonSerializer();
            deserializer.TypeNameHandling = TypeNameHandling.All;
            shapeList.Clear();            

            try
            {
                using (FileStream streamReader = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    BsonReader reader = new BsonReader(streamReader);
                    shapeList = (List<Configs>)deserializer.Deserialize(reader);
                }                                                            
                RedrawShapes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }                      
        }        

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)            
                configs.ShiftPressed = shiftPressed = true;             
        }        

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Shift)
                configs.ShiftPressed = shiftPressed = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (checkedListBox.SelectedItem != null)
            {
                checkedListBox.SetItemChecked(checkedListBox.Items.IndexOf(checkedListBox.SelectedItem), false);
                checkedListBox.ClearSelected();
            }
            string type = selectedShape.CurrentFigure.GetType().ToString();
            type = "Paint.Create" + type.Substring(type.LastIndexOf('.') + 1);
            shapeList.Remove(selectedShape);
            fabric = (ICreate)Activator.CreateInstance(Type.GetType(type));           
            
            RedrawShapes();
            pen = new Pen(selectedShape.Color, selectedShape.Width);
            selectedShape = null;
            textBoxPenWidth.Text = pen.Width.ToString();
            buttonColor.ForeColor = pen.Color;
            buttonEdit.Enabled = false;
            buttonRelocate.Enabled = false;
        }

        private void buttonRelocate_Click(object sender, EventArgs e)
        {
            moving = true;
            fabric = null;
        }
    }
}