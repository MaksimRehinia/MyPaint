using System;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class ConfigsForm : Form
    {
        private string background;

        public ConfigsForm()
        {            
            InitializeComponent();
        }
        
        private void buttonApply_Click(object sender, EventArgs e)
        {
            int width, height, opacity;
            if (textBoxWidth.Text.Trim() != "" && int.TryParse(textBoxWidth.Text, out width)
                    && width > 0 && width <= 1366
                    && textBoxHeight.Text.Trim() != "" && int.TryParse(textBoxHeight.Text, out height)
                    && height > 0 && height <= 740
                    && textBoxOpacity.Text.Trim() != "" && int.TryParse(textBoxOpacity.Text, out opacity)
                    && opacity > 0 && opacity <= 100)
            {
                var conf = new AppConfigs(width, height, opacity, background);
                var formatter = new XmlSerializer(typeof(AppConfigs));

                using (FileStream fs = new FileStream("../../conf/config.xml", FileMode.Create))
                {
                    formatter.Serialize(fs, conf);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверные значения");
                return;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void buttonBackground_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog.ShowDialog();
            if (D == DialogResult.OK)
            {
                background = colorDialog.Color.Name;                        
            }            
        }
    }
}
