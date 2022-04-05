namespace GalaxyMerchantApp
{
    public abstract class Parser
    {
        public Context Context { get; private set; }
        public Parser(Context context)
        {
            Context = context;
        }
        public abstract void Parse(string inputLine);
    }

}