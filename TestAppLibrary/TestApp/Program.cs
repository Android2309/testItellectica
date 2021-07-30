using System;
using TestAppLibrary;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string text1 = "Этот текст (строка) предназначен для тестирования [бы{стр}ой] проверки вхождения скобок {любых [из трех видов]}";
            string text2 = "[]({}))[]";
            string text3 = "[{(})]";

            Console.WriteLine(text1);
            Console.WriteLine(text1.CheckString());
            Console.WriteLine(text2.CheckString());
            Console.WriteLine(text3.CheckString());
        }
    }
}
