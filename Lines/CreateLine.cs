using System;
using Shapes;

namespace Lines
{
    class CreateLine: CreateShape
    {
        private static CreateLine instance;
        public override Shape Create()
        {
            return new Line();
        }
        public static CreateLine getInstance()
        {
            if (instance == null)
                instance = new CreateLine();
            return instance;
        }
    }
}
