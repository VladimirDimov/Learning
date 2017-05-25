namespace MediaTypeFormattersDemo.App_Start
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    public static class TaskFactoryExtensionMethods
    {
        public static Task<TResult> StartNewWithCulture<TResult>(this TaskFactory<TResult> factory, Func<TResult> action, CultureInfo culture)
        {
            return factory.StartNew(() =>
            {
                Thread.CurrentThread.CurrentCulture = culture;

                return action();
            });
        }

        public static Task StartNewWithCulture(this TaskFactory factory, Action action, CultureInfo culture)
        {
            return factory.StartNew(() =>
            {
                Thread.CurrentThread.CurrentCulture = culture;

                action();
            });
        }
    }
}