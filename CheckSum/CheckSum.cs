using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Interfaces;

namespace CheckSum
{
    public class CheckSum: ICheckable
    {
        public void Set_checksum(byte checksum, string filename)
        {            
            try
            {
                using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    for (int i=0; i<10; i++)
                    {
                        fs.WriteByte(checksum);
                    }                    
                    fs.Close();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        public bool Check_checksum(byte checksum, string filename)
        {
            byte[] buffer = new byte[] { };

            try
            {
                using (var fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    Array.Resize<byte>(ref buffer, (int)fs.Length);                    
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
            if (buffer.Length != 10)
                return false;

            foreach (byte b in buffer)
            {
                if (b != checksum)
                    return false;
            }

            return true;            
        }

        public byte Get_checksum(string filename)
        {
            byte[] buffer;
            int sum = 0;

            try
            {
                using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                }
                sum = buffer.Aggregate(0, (acc, i) => acc + i);
                sum = sum % 256;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            

            return (byte)sum;
        }
    }
}
