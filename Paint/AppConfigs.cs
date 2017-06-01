using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    [Serializable]
    public class AppConfigs
    {
        public int ClientWidth { get; set; }
        public int ClientHeight { get; set; }
        public int ClientOpacity { get; set; }
        public string ClientBackground { get; set; }

        public AppConfigs()
        {            
            ClientWidth = 899;
            ClientHeight = 432;
            ClientOpacity = 100;
            ClientBackground = "White";
        }

        public AppConfigs(int width, int height, int opacity, string background)
        {
            ClientHeight = height;
            ClientWidth = width;
            ClientOpacity = opacity;
            ClientBackground = background;
        }
    }
}
