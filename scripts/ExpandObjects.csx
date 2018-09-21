#! "netcoreapp2.1"
#r "nuget:Newtonsoft.Json,11.0.2"
#r "nuget:AutoMapper,7.0.1"

using Newtonsoft.Json;
using AutoMapper;

class Data {
    public int A { set; get; }
    public int B { set; get; }
    public string C { set; get; }
}

var text = File.ReadAllText("resource/Hello.json");

var results = JsonConvert.DeserializeObject<ExpandoObject[]>(text);

dynamic result = results[0];
var dict = result as IDictionary<string, object>;

Mapper.Initialize(cfg => {
    cfg.CreateMap(typeof(Dictionary<string, object>), typeof(Data));
});

var data = Mapper.Map<Data>(dict);
Console.WriteLine(data.A);
Console.WriteLine(data.B);
Console.WriteLine(data.C);
