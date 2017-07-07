using System.IO;
using System.Linq;
using System.Reflection;

namespace ImdbCommunication.Test
{
    public class EmbeddedResources
    {
        public static string GetResource(string name)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string resourceName = executingAssembly.GetManifestResourceNames().SingleOrDefault(x => x.EndsWith(name));
            Stream resourceStream = executingAssembly.GetManifestResourceStream(resourceName);
            return new StreamReader(resourceStream).ReadToEnd();
        }
    }
}
