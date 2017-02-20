using System;

namespace Paint
{
    abstract class ClassShape
    {
        public string Color { get; set; }
        public abstract void Draw();   
    }
}
