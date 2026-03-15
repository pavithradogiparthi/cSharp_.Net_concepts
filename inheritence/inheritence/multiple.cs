using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritence
{
    public interface Iflyable {
        void fly();

    }
    public interface Iswimmable {
        void swim();
    }

    public class Duck : Iflyable, Iswimmable {

        public void fly() { Console.WriteLine("flying"); }
        public void swim() { Console.WriteLine("swimming"); }
    
    }
    public class Crane : Iflyable, Iswimmable
    {
        public void fly() { Console.WriteLine(" crane is flying ...."); }
        public void swim() { Console.WriteLine(" i am swimming"); }

    }



}
