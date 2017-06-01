using System;
using System.Text;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Config;
using ComplexShapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using Shapes;
using Interfaces;

namespace Paint
{
    public partial class MainForm : Form
    {
        internal Graphics drawArea;
        private int CountComplexShapes;        
        private CreateShape fabric;
        private List<Configs> shapeList;
        private List<Configs> selectedFigures;
        private Pen pen;
        private bool shiftPressed;
        private bool moving;
        private bool IsBeganCreate;
        private Bitmap btmp_front, btmp_back;              
        private Configs configs;
        private Configs selectedShape;        
        private List<Type> factoryTypesList;
        private ICheckable checking = null;
        private Dictionary<byte, string> assembliesToSign;       

        public MainForm()
        {
            LoadCheckSumPlugin(ref checking);            
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            fabric = null;
            shiftPressed = false;
            moving = false;
            IsBeganCreate = false;
            buttonRelocate.Enabled = false;
            buttonEdit.Enabled = false;
            CountComplexShapes = Directory.GetFiles(Application.StartupPath + "\\..\\..\\Libraries", "*.fig").Length;
            shapeList = new List<Configs>();
            selectedFigures = new List<Configs>();
            factoryTypesList = new List<Type>();
            assembliesToSign = new Dictionary<byte, string>();            
            configs = new Configs();
            pen = new Pen(configs.Color, configs.Width);
            InitLibraries();
            CleanField();
        }       

        private bool Check_Check_Sum(string lib, string licence)
        {                       
            byte checksum = checking.Get_checksum(lib);
            if (!checking.Check_checksum(checksum, licence))
            {
                string message = "Warning! Library: " + lib + " is not signed or has an inproper sign." +
                "Do you really want to download this library? (if Yes, it will be signed)";
                string caption = "Library isn't signed";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult result =  MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    assembliesToSign.Add(checksum, licence);
                    return true;
                }
                else
                    return false;                
            }
            else
            {
                assembliesToSign.Add(checksum, licence);
                return true;
            }
        }

        private string GetFileLicence(string lib)
        {
            string path = Application.StartupPath + "\\..\\..\\Libraries";            
            int firstindex = lib.LastIndexOf('\\');
            int lastindex = lib.LastIndexOf('.');
            string nameoflib = lib.Substring(firstindex + 1, lastindex - firstindex - 1);

            string[] licences = null;
            licences = Directory.GetFiles(path, nameoflib+"Licence");
            if (licences != null && licences.Count() != 0)
                return licences[0];
            else
                return path+"\\"+nameoflib+"Licence";
        }

        private void InitLibraries()
        {
            try
            {
                checkedListBox.Items.Clear(); 
                string path = Application.StartupPath + "\\..\\..\\Libraries";
                string[] libraries = Directory.GetFiles(path, "*.dll");                
                
                foreach (var lib in libraries)
                {
                    try
                    {
                        string nameoflicence = GetFileLicence(lib);
                        if (!Check_Check_Sum(lib, nameoflicence))
                            continue;
                                               
                        Assembly assembly = Assembly.LoadFrom(lib);                        
                        Type[] types = assembly.GetTypes();                        
                        foreach (Type type in types)
                        {
                            if (type.ToString().Contains("Create") && type.BaseType.ToString().Equals("Shapes.CreateShape"))
                            {
                                string name = type.ToString().Substring(type.ToString().IndexOf("Create") + 6);
                                checkedListBox.Items.Add((object)name, false);
                                factoryTypesList.Add(type);
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = "Oops... Library: " + lib.ToString() + " can not be downloaded.\n" + "Error: ";
                        if (ex.InnerException != null)
                            message += ex.InnerException.Message;
                        else
                            message += ex.Message;
                        MessageBox.Show(message);
                    }                    
                }

            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCheckSumPlugin(ref ICheckable plugin)
        {            
            var allPlugins = Directory.GetFiles(Application.StartupPath+"\\..\\..\\Libraries\\CheckSum", "CheckSum.dll");

            string pluginName = allPlugins[0];
       
            try
            {
                var asm = Assembly.LoadFrom(pluginName);
                foreach (var type in asm.GetTypes())
                {
                    if (type.GetInterfaces().Contains(typeof(ICheckable)))
                    {
                        plugin = Activator.CreateInstance(type) as ICheckable;                            
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
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

        private void checkedListBox_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; i++)
                if (checkedListBox.Items[i] != checkedListBox.SelectedItem)
                    checkedListBox.SetItemChecked(checkedListBox.Items.IndexOf(checkedListBox.Items[i]), false);

            string nameOfType = checkedListBox.SelectedItem.ToString();
            MethodInfo factoryCreater = null;
            foreach (Type type in factoryTypesList)
            {
                if (type.ToString().Contains(nameOfType))
                {
                    factoryCreater = type.GetMethod("getInstance");
                    break;
                }
                    
            }
            fabric = (CreateShape)factoryCreater.Invoke(null, new object[] { });
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
            drawArea.Clear(Color.White);
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
                    Type realizedInterface = shapes[i].CurrentFigure.GetType().GetInterface("Interfaces.ISelectable");
                     
                    if ( (realizedInterface != null) && (shapes[i].CurrentFigure.isInArea(new Point(e.X, e.Y))) )
                    {
                        if (IsBeganCreate)
                        {
                            selectedFigures.Add(shapes[i]);
                            if (selectedFigures.Count < 2)
                            {
                                buttonEndCreate.Enabled = false;
                            }
                            else
                            {
                                buttonEndCreate.Enabled = true;
                            }
                            foreach (var shape in selectedFigures)
                            {
                                shape.CurrentFigure.Select(drawArea);
                            }
                            pictureBox.Refresh();
                        }
                        else
                        {
                            realizedInterface = null;
                            shapes[i].CurrentFigure.Select(drawArea);
                            pictureBox.Refresh();
                            selectedShape = shapes[i];
                            realizedInterface = shapes[i].CurrentFigure.GetType().GetInterface("Interfaces.IEditable");
                            if (realizedInterface != null)
                            {
                                buttonRelocate.Enabled = true;
                                buttonEdit.Enabled = true;
                            }                            
                        }
                        return;
                    }
                }
            }
            IsBeganCreate = false;
            buttonBeginCreate.Enabled = true;
            buttonEndCreate.Enabled = false;
            selectedFigures = new List<Configs>();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog.ShowDialog();
            if (D == DialogResult.OK)
            {
                pen.Color = buttonColor.ForeColor = colorDialog.Color;
                Type realizedInterface = null;
                if (selectedShape != null)
                    realizedInterface = selectedShape.CurrentFigure.GetType().GetInterface("Interfaces.IEditable");
                if ( (selectedShape != null) && (realizedInterface != null) )
                {                    
                    selectedShape.Color = pen.Color;                    
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
            if (!float.TryParse((sender as TextBox).Text, out width))
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

            selectedShape = null;
            buttonEdit.Enabled = false;
            buttonRelocate.Enabled = false;

            JsonSerializer serializer = new JsonSerializer();            
            serializer.TypeNameHandling = TypeNameHandling.All;
            
            try
            {                
                using (StreamWriter fs = new StreamWriter(saveFileDialog.FileName))
                {                                        
                    JsonTextWriter wr = new JsonTextWriter(fs);                                       
                    foreach (var shape in shapeList)
                    {                          
                        serializer.Serialize(wr, shape);
                        wr.WriteWhitespace("   ");                                                                                                
                    }                                        
                    wr.Close();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            selectedShape = null;
            buttonEdit.Enabled = false;
            buttonRelocate.Enabled = false;   
                        
            JsonSerializer deserializer = new JsonSerializer();            
            deserializer.TypeNameHandling = TypeNameHandling.All;
            var shapes = new List<Configs>();
            string[] jsonObjArray = null;
            try
            {                
                using (StreamReader fs = new StreamReader(openFileDialog.FileName, Encoding.ASCII))
                {
                    string json = fs.ReadToEnd();
                    string[] delimeters = new string[] { "   " };                    
                    jsonObjArray = json.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some problems with deserialization file " +
                    openFileDialog.FileName + "\nError: " + ex.Message.ToString());
            }

            foreach (var jsonObj in jsonObjArray)
            {
                try
                {
                    Configs item = null;
                    JObject obj = JObject.Parse(jsonObj);

                    item = new Configs(obj.ToObject<Configs>(deserializer));
                    if (item != null)
                        shapes.Add(item);
                }
                catch (JsonException ex)
                {
                    if (ex.InnerException != null)
                        MessageBox.Show(ex.InnerException.Message);
                    else
                        MessageBox.Show("Check the content of the file\n"+ex.Message);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());                    
                }
            }         
                     
            if (shapes != null && shapes.Count != 0)
            {
                shapeList = new List<Configs>(shapes);
                RedrawShapes();
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
            string nameOfType = selectedShape.CurrentFigure.GetType().ToString();
            if (nameOfType.Contains("ComplexShape"))
            {
                ComplexShape complexShape = (ComplexShape)selectedShape.CurrentFigure;
                CreateComplexShape factory = new CreateComplexShape(complexShape.Shapes, complexShape.InitWidth, complexShape.InitHeight);
                fabric = factory;
            }
            else
            {
                nameOfType = nameOfType.Substring(nameOfType.LastIndexOf('.') + 1);
                MethodInfo factoryCreator = null;
                foreach (Type type in factoryTypesList)
                {
                    if (type.ToString().Contains(nameOfType))
                    {
                        factoryCreator = type.GetMethod("getInstance");
                        break;
                    }

                }
                fabric = (CreateShape)factoryCreator.Invoke(null, new object[] { });
            }
            
            shapeList.Remove(selectedShape);
            RedrawShapes();
            pen = new Pen(selectedShape.Color, selectedShape.Width);
            selectedShape = null;
            textBoxPenWidth.Text = pen.Width.ToString();
            buttonColor.ForeColor = pen.Color;
            buttonEdit.Enabled = false;
            buttonRelocate.Enabled = false;
        }

        private void textBoxPenWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                float width;
                float.TryParse((sender as TextBox).Text, out width);
                pen.Width = width;
                Type realizedInterface = null;
                if (selectedShape != null)
                    realizedInterface = selectedShape.CurrentFigure.GetType().GetInterface("Interfaces.IEditable");
                if ((selectedShape != null) && (realizedInterface != null))
                {
                    selectedShape.Width = pen.Width;
                    RedrawShapes();
                    buttonEdit.Enabled = false;
                    buttonRelocate.Enabled = false;
                    selectedShape = null;
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            factoryTypesList.Clear();            
            foreach (KeyValuePair<byte, string> licence in assembliesToSign)
            {
                checking.Set_checksum(licence.Key, licence.Value);
            }
        }

        private void buttonBeginCreate_Click(object sender, EventArgs e)
        {
            IsBeganCreate = true;
            buttonBeginCreate.Enabled = false;
        }

        private void buttonEndCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CountComplexShapes++;
                string fileName = Application.StartupPath + "\\..\\..\\Libraries\\" + "Figure" + CountComplexShapes + ".fig";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                int minX = 10000;
                int minY = 10000;
                int maxX = 0;
                int maxY = 0;

                foreach (var shape in selectedFigures)
                {
                    if (shape.CurrentFigure.GetMaxX() > maxX)
                    {
                        maxX = shape.CurrentFigure.GetMaxX();
                    }
                    if (shape.CurrentFigure.GetMaxY() > maxY)
                    {
                        maxY = shape.CurrentFigure.GetMaxY();
                    }
                    if (shape.CurrentFigure.GetMinX() < minX)
                    {
                        minX = shape.CurrentFigure.GetMinX();
                    }
                    if (shape.CurrentFigure.GetMinY() < minY)
                    {
                        minY = shape.CurrentFigure.GetMinY();
                    }
                }
                int initWidth = maxX - minX;
                int initHeight = maxY - minY;
                var simpleFigures = new List<ShapeWithDelta>();

                foreach (Configs shape in selectedFigures)
                {
                    ShapeWithDelta simpleFigure;
                                        
                    simpleFigure = new ShapeWithDelta(
                        shape.CurrentFigure.GetMinX() - minX,
                        shape.CurrentFigure.GetMinY() - minY,
                        shape.CurrentFigure.GetMaxX() - shape.CurrentFigure.GetMinX(),
                        shape.CurrentFigure.GetMaxY() - shape.CurrentFigure.GetMinY(),
                        shape
                    );
                    simpleFigures.Add(simpleFigure);                   
                }

                ComplexShape complexFigure = new ComplexShape(simpleFigures, initWidth, initHeight);

                using (StreamWriter streamWriter = new StreamWriter(fileName))
                {
                    JsonSerializer ser = new JsonSerializer();
                    ser.TypeNameHandling = TypeNameHandling.All;
                    ser.Serialize(streamWriter, complexFigure);
                    MessageBox.Show("Complex shape is successfully created. Restart the app to use it");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n\r"+ex.InnerException != null ? ex.InnerException.ToString() : ex.ToString());
            }
        }

        private void buttonRelocate_Click(object sender, EventArgs e)
        {
            moving = true;
            fabric = null;
            buttonEdit.Enabled = false;
        }
    }
}