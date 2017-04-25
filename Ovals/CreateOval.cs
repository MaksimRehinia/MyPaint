using System;
using Shapes;

namespace Ovals
{
    class CreateOval: CreateShape
    {
        private static CreateOval instance;
        public override Shape Create()
        {
            return new Oval();
        }
        public static CreateOval getInstance()
        {
            if (instance == null)
                instance = new CreateOval();
            return instance;
        }
    }
}
