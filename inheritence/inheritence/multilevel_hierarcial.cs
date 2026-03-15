using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritence
{
    public class Animal {
        public void eat()
        {
            Console.WriteLine("eating");
        }
    }
    public class Dog : Animal { 

        public void bark()
        {
            Console.WriteLine("barking");
        }
    }
    public class cat : Animal
    {
        public void shouts()
        {
            Console.WriteLine("cat meows");
        }
    }
    public class puppy : Dog { 

        public void weep()
        {
            Console.WriteLine("weeping");
        }
    }



}
