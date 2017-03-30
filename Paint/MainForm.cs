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
        private List<IShape> shapeList = new List<IShape>();
        private Pen pen;                
        private bool lKeyPressed, shiftPressed = false;                
        private Bitmap btmp_front, btmp_back;
        IShape shape;

        public MainForm()
        {
            InitializeComponent();            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {            
            pen = new Pen(Color.Black, 2);
            CleanField();
        }        

        private void CleanField()
        {
            btmp_back = new Bitmap(pictureBox.Width, pictureBox.Height);
            btmp_front = new Bitmap(pictureBox.Width, pictureBox.Height);
            drawArea = Graphics.FromImage(btmp_front);
            pictureBox.Image = btmp_front;
            pictureBox.BackgroundImage = btmp_back;
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

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (fabric != null)
            {                
                shape = fabric.Create();
                shape.FirstPoint = new Point(e.X, e.Y);
                shape.P = new Pen(pen.Color, pen.Width);
            }
            lKeyPressed = true;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if ((lKeyPressed) && (fabric != null))
            {
                shape.SecondPoint = new Point(e.X, e.Y);
                drawArea.Clear(Color.White);
                drawArea.DrawImage(btmp_back, 0, 0);
                shape.Draw(ref drawArea, shiftPressed);
                pictureBox.Refresh();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {            
            if (fabric != null)
            {
                shape.SecondPoint = new Point(e.X, e.Y);
                shape.P = new Pen(pen.Color, pen.Width);                
                shape.Draw(ref drawArea, shiftPressed);
                btmp_back = (Bitmap)btmp_front.Clone();
                shapeList.Add(shape);
                pictureBox.Refresh();
            }
            lKeyPressed = false;
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog.ShowDialog();
            if (D == DialogResult.OK)
            {
                pen.Color = buttonColor.ForeColor = colorDialog.Color;
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            CleanField();            
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            if (File.Exists(saveFileDialog.FileName))
            {
                File.Delete(saveFileDialog.FileName);
            }
            string filename = saveFileDialog.FileName;

            JsonSerializer serializer = new JsonSerializer();
            serializer.TypeNameHandling = TypeNameHandling.All;
            try
            {
                //using (FileStream fs = new FileStream(filename, FileMode.Create))
                using (StreamWriter fs = new StreamWriter(filename))
                {                                                          
                   /* BsonWriter writer = new BsonWriter(fs);
                    //serializer.Serialize(writer, shapeList);
                    //Rectangles t = (shape as Rectangles);*/
                    serializer.Serialize(fs, shapeList);
                    
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
            string filename = openFileDialog.FileName;                                    
                        
            CleanField();
            var shapes = new List<IShape>();
            using (StreamReader streamReader = new StreamReader(filename, Encoding.ASCII))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                {
                    try
                    {
                        JsonSerializer ser = new JsonSerializer();
                        ser.TypeNameHandling = TypeNameHandling.All;
                        shapes = (List<IShape>)ser.Deserialize(jsonTextReader);
                        foreach (var elem in shapes)
                        {                            
                            elem.Draw(ref drawArea);
                        }
                        btmp_back = (Bitmap)btmp_front.Clone();
                        streamReader.Close();
                    }
                    catch (InvalidCastException ice)
                    {
                        MessageBox.Show("Невалидный JSON");
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show("Ошибка");
                    }
                    finally
                    {

                    }
                }
            }
            /*JsonSerializer serializer = new JsonSerializer();            
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    BsonReader reader = new BsonReader(fs);
                    var deserilizedShapes = (serializer.Deserialize<IShape>(reader) as Rectangles);
                 // var deserilizedShapes = (serializer.Deserialize(reader) as Rectangles);

                 // foreach (IShape shape in deserilizedShapes)
                //  {
                        deserilizedShapes.Draw(ref drawArea);
                     // btmp_back = (Bitmap)btmp_front.Clone();                    
                        pictureBox.Refresh();
               //   }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
        }        

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)            
                shiftPressed = true;             
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Shift)
                shiftPressed = false;
        }
    }
}