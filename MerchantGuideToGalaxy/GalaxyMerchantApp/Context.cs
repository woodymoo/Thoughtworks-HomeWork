using System.Collections.Generic;

namespace GalaxyMerchantApp
{
    public class Context
    {
        public string PrimUnit { get; set; }
        //public Dictionary<string, RomanPrimitive> Primitives { get; set; }
        public Dictionary<string, string> AliasPrimitiveMap { get; set; }

        public Dictionary<string, double> Units { get; set; }
        public List<string> Questions { get; set; }

        public Context()
        {
            //Primitives = new Dictionary<string, RomanPrimitive>();
            Units = new Dictionary<string, double>();
            Questions = new List<string>();
        }

    }
}