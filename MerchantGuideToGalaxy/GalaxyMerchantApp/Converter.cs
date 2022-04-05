

using System;
using System.Collections.Generic;

namespace GalaxyMerchantApp
{
    public class Converter
    {

        private string[] input;

        public Converter(string[] input)
        {
            this.input = input;
            foreach( var line in input )
            {
                // run all the parsers
            }

            // run solver, strategy solver and get response
        }

        public IEnumerable<string> Run()
        {
            var result = new List<string>();

            Console.WriteLine("Parsing....");
            var context = new Context();
            var parsers = new Parser[]
            {
                new AliasParser(context),
                new UnitPriceParser(context),
                new QuestionParser(context)
            };
            //var solvers = new Solver[]
            //{
            //    new PrimitiveSolver(ctx),
            //    new UnitSolver(ctx)
            //};
            //foreach (var cmd in input)
            //{
            //    foreach (var parser in parsers)
            //    {
            //        try
            //        {
            //            if (parser.Parse(cmd))
            //            {
            //                break;
            //            }
            //        }
            //        catch
            //        {

            //        }
            //    }
            //}

            return result;
        }
    }

    public class UnitPriceParser : Parser
    {


        public UnitPriceParser(Context context) : base(context)
        {

        }
        public override void Parse(string intpuLine)
        {
             
        }
    }

    public class AliasParser : Parser
    {


        public AliasParser(Context context) : base(context)
        { }

        public override void Parse(string inputLine)
        {
            string[] words = inputLine.Split(new[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length != 2)
                throw new FormatException("Syntx error");

            // TODO: check if it is primitive. 

            // put into context
            Context.AliasPrimitiveMap.Add(words[0], words[1]);

        }
    }
    public class QuestionParser : Parser
    {
        public QuestionParser(Context context) : base(context)
        {
        }

        public override void Parse(string inputLine)
        {
            throw new NotImplementedException();
        }
    }

}