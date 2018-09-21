using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Dynamic;
using System.Collections.Generic;

namespace JsonDecoder {
    class Program {
        static void Main(string[] args) {
            var text = File.ReadAllText("resource/Hello.json");

            var results = JsonConvert.DeserializeObject<ExpandoObject[]>(text,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

            dynamic result = results[0] as IDictionary<string, object>;
            var type = result.GetType();
            var props = type.GetProperties();
            foreach (var item in props) {
                Console.WriteLine(item.PropertyType);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.GetValue(result));
            }

            Console.WriteLine(result.A);
        }
    }
}
