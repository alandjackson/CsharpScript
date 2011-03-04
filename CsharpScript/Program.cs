using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.CSharp;
using System.Reflection;
using System.Windows.Forms;

namespace CsharpScript
{
    class Program
    {
        static void Main(string[] args)
        {
            //CLI();
            Application.EnableVisualStyles();
            Application.Run(new Immediate());
        }
        
        static void CLI()
        {
            try
            {
                Evaluator.Init(new string[0]);
                Evaluator.ReferenceAssembly(Assembly.GetExecutingAssembly());
                Evaluator.Run("using CsharpScript.Scripting;");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return;
            }

            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (line == "q")
                    return;

                try
                {
                    Console.WriteLine(Evaluator.Evaluate(line).ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.ToString());
                }
            }
        }
    }
}
