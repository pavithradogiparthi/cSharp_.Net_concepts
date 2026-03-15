using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops
{
    public interface Ishape
    {
        
        double calculatearea();
    }
    public class circle : Ishape
    {
        public int _value;
        public int Radius
        {
            get { return _value; }
            set { if (value > 0) _value = value; }
        }
        public circle(int r)
        {
            Radius = r;
            Console.WriteLine($"In constructer {Radius}");
        }

       

        public double calculatearea()
        {
            return Math.PI * Radius*Radius;
        }
    
    }
    public class square: Ishape
    {
       public int length { get; set; }
        public int bredth { get; set; }
        public square(int l, int b)
        {
            length = l;
            bredth = b;
        }
        public double calculatearea()
        {
            return length * bredth;
        }

    }

}
