using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocTest.General
{
    public static class JsonWorker
    {
        public static T ConverFromJsonFile<T>(string path)
        {
            var assembly = Assembly.GetEntryAssembly();
            var stream = assembly.GetManifestResourceStream(path);
            string json_text;
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                json_text = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(json_text);
        }
    }
}
