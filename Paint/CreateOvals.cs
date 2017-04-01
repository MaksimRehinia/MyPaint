using System;
using System.Drawing;

namespace Paint
{
    class CreateOvals : ICreate
    {
        private static CreateOvals instance;
        public Shape Create()
        {
            return new Ovals();
        }
        public static CreateOvals getInstance()
        {
            if (instance == null)
                instance = new CreateOvals();
            return instance;
        }
    }
}