using System;
using System.IO;
using System.Collections.Generic;

namespace GalaxyMerchantApp
{
    class Program
    {
        static void Main(string[] args)
        {

            if( args.Length > 1 && !string.IsNullOrEmpty( args[1]))
            {
                if ( File.Exists(args[1]) )
                {
                    var input = File.ReadAllLines(args[1]);
                    var parser = new Converter(input);
                    var result = parser.Run();
                    OutputResult(result);

                    Console.WriteLine();
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid input file or file path.");
                    return;
                }
            }
            Console.WriteLine("Hello World!");
        }


        static void OutputResult(IEnumerable<string> strOutput)
        {
            foreach( var line in strOutput)
            {
                Console.WriteLine(line);
            }
        }
    }
}
