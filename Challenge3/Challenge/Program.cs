using Newtonsoft.Json.Linq;
using System;

namespace Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonStr = @"{""a"":{""b"":{""c"":""d""}}}";
            string jsonPath = "a.b.c";

            JObject jObject = JObject.Parse(jsonStr);
            getJsonValue(jObject, jsonPath);
        }

        static void getJsonValue(JObject obj, string key)
        {
            foreach (JToken token in obj.SelectTokens(key))
            {
                Console.WriteLine(token);
            }
        }
    }
}
