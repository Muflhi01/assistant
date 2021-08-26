using System;
using Assistant;

namespace wonoly_assistant
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Assistant.Program assistant = new Assistant.Program();
            string function = assistant.getFunction(text);
        }
    }
}
