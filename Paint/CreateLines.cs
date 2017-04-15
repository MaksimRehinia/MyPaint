using System;
using System.Drawing;

namespace Paint
{
    class CreateLines : ICreateable
    {
        private static CreateLines instance;
        public Shape Create()
        {                        
            return new Lines();
        }
        public static CreateLines getInstance()
        {
            if (instance == null)
                instance = new CreateLines();
            return instance;
        }        
    }
}