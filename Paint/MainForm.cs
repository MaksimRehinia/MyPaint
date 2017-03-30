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
        private bool lKeyPressed, shiftPressed = false;                
        private Bitmap btmp_front, btmp_back;
        private Configs configs;

        public MainForm()
        {
            InitializeComponent();            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            configs = new Configs();
            pen = new Pen(configs.Color, configs.Width);            
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
                configs.CurrentFigure = fabric.Create();
                configs.CurrentFigure.FirstPoint = new Point(e.X, e.Y);                
            }
            lKeyPressed = true;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if ((lKeyPressed) && (fabric != null))
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
            if (fabric != null)
            {
                configs.CurrentFigure.SecondPoint = new Point(e.X, e.Y);                
                configs.CurrentFigure.Draw(drawArea, pen, shiftPressed);
                btmp_back = (Bitmap)btmp_front.Clone();
                var temp = new Configs(configs);
                shapeList.Add(temp);                
                pictureBox.Refresh();
            }
            lKeyPressed = false;
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog.ShowDialog();
            if (D == DialogResult.OK)
            {
                configs.Color = pen.Color = buttonColor.ForeColor = colorDialog.Color;
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
                configs.Width = pen.Width = width;
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
            
            try
            {                
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))                
                {
                    BsonWriter writer = new BsonWriter(fs);
                    writer.WriteStartArray();                    
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.TypeNameHandling = TypeNameHandling.Arrays;
                    //writer.WriteEndArray();
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
                        
            CleanField();
            var shapes = new List<Configs>();            
            using (FileStream streamReader = new FileStream(openFileDialog.FileName, FileMode.Open))
            {
                //using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                {
                    try
                    {
                        BsonReader reader = new BsonReader(streamReader);
                        reader.ReadRootValueAsArray = true;                                       
                        JsonSerializer deserializer = new JsonSerializer();
                        deserializer.TypeNameHandling = TypeNameHandling.Arrays;
                        //shapes = (List<Configs>)deserializer.Deserialize(jsonTextReader);
                        shapes = (deserializer.Deserialize<List<Configs>>(reader));
                        foreach (Configs shape in shapes)
                        {                            
                            shape.CurrentFigure.Draw(drawArea, new Pen(shape.Color, shape.Width), shape.ShiftPressed);
                        }
                        btmp_back = (Bitmap)btmp_front.Clone();                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
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
    }
}