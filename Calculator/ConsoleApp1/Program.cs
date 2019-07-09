using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Program
    {
        public void Restart()
        {
            string b;
            Program p = new Program();         
            Console.WriteLine("\nrestart y/n");
            Console.Write(": ");
            b = Console.ReadLine();
            switch (b)
            {
                case "y":
                    p.Calculator();
                    break;
                case "n":
                    System.Environment.Exit(1);
                    break;
                default:
                    p.Restart();
                    break;
            }
        }
        public void Calculator()
        {
            //int x = 0;
            Program p = new Program();
            string a;
            float num1 = 0, num2 = 0;
            Console.Clear();
            Console.WriteLine("Calculator choose \n1.add\n2.sub\n3.multiply\n4.divide");
            Console.Write(": ");
            a = Console.ReadLine();
            switch (a)
            {
                case "1":
                    Console.Write("\n1.number\n: ");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n2.number\n: ");
                    num2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("{0} + {1} = {2}",num1,num2,num1 + num2);                    
                    p.Restart();
                    break;
                case "2":
                    Console.Write("\n1.number\n: ");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n2.number\n: ");
                    num2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("{0} - {1} = {2}", num1, num2, num1 - num2);
                    p.Restart();
                    break;
                case "3":
                    Console.Write("\n1.number\n: ");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n2.number\n: ");
                    num2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("{0} * {1} = {2}", num1, num2, num1 * num2);
                    p.Restart();
                    break;
                case "4":
                    Console.Write("\n1.number\n: ");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("\n2.number\n: ");
                    num2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("{0} / {1} = {2}", num1, num2, num1 / num2);
                    p.Restart();
                    break;
                default:
                    Console.WriteLine("error");                    
                    p.Restart();
                    break;
            }               
        }
        static void Main(string[] args)
        {
            Program r = new Program();
            r.Calculator();
        }
    }
}
