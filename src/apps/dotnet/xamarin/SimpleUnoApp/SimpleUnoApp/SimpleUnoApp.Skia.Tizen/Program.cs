using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace SimpleUnoApp.Skia.Tizen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = new TizenHost(() => new SimpleUnoApp.App(), args);
            host.Run();
        }
    }
}
