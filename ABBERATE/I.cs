using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Swap<T>(ref T a, ref T b)
        {             
            T temp = a;
            a = b;
            b = temp;
        }
        static void Main(string[] args)
        {
            int x = 5, y = 10;
            string str1 = "Hello", str2 = "World";
            bool bool1 = true, bool2 = false;

            Console.WriteLine($"Before Swap: x = {x}, y = {y}");
            Swap(ref x, ref y);
            Console.WriteLine($"After Swap: x = {x}, y = {y}");
            Console.WriteLine($"Before Swap: str1 = {str1}, str2 = {str2}");
            Swap(ref str1, ref str2);
            Console.WriteLine($"After Swap: str1 = {str1}, str2 = {str2}");
            Console.WriteLine($"Before Swap: bool1 = {bool1}, bool2 = {bool2}");
            Swap(ref bool1, ref bool2);
            Console.WriteLine($"After Swap: bool1 = {bool1}, bool2 = {bool2}");
        }
    }
}
