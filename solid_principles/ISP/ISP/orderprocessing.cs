using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP
{
    public interface Ionlineorderprocessing
    {

        void processingonlineorder();
        void applyingdiscount();
        void shipingorder();


    }
    public interface Iinstoreorderprocessing
    {
        void applyingdiscount();
        void instorepickuporder();

    }
    public class onlineorderprocessimp : Ionlineorderprocessing
    {
        public void processingonlineorder()
        {
            Console.WriteLine("processing online order in isp");
        }
        public void applyingdiscount()
        {
            Console.WriteLine("applying discount in isp");
        }
        public void shipingorder()
        {
            Console.WriteLine("shipping orders in isp");
        }
    }
    public class instoreorderprocessimp : Iinstoreorderprocessing
    {
        public  void instorepickuporder()
        {
            Console.WriteLine("processing shop orders in isp");
        }
        public void applyingdiscount()
        {
            Console.WriteLine("applying discount");
        }

    }



}
