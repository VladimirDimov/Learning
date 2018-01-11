namespace WcfAutofac.BL
{
    public class SomeRepository : ISomeRepository
    {
        public string FormatValue(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
}