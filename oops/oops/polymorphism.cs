using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oops
{
    public class math
    {
        //method overloading
        public int add(int a ,int b)
        {
            return a + b;
        }
        public float add(float a, float b, float c)
        {
            return a + b + c;
        }
    }

    //method overriding
    public class Animal
    { 
        public  virtual void speak()
        {
            Console.WriteLine("the animal makes sound");
        }

    }
    public class Dog : Animal 
    {
        public override void speak()
        {
            Console.WriteLine("the dog barks");
        }
    }
    public class cat : Animal 
    {
        public void speak()
        {
            Console.WriteLine("the cat meows");
        }
    }



}
