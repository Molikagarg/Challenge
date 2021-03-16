using System;
using Xunit;
using Newtonsoft.Json.Linq;

namespace XUnitTestProject1
{
    public class Challenge3
    {

        [Theory]
        [InlineData(@"{""a"":{""b"":{""c"":""d""}}}", "a.b.c")]
        public void Test1(string jsonStr, string jsonKey)
        {
            JObject jObject = JObject.Parse(jsonStr);

            var result = GetJsonValue(jObject, jsonKey);
            Assert.Equal("d", result);
        }

        [Theory]
        [InlineData(@"{""x"":{""y"":{""z"":""a""}}}", "x.y.z")]
        public void Test2(string jsonStr, string jsonKey)
        {
            JObject jObject = JObject.Parse(jsonStr);

            var result = GetJsonValue(jObject, jsonKey); 
            Assert.Equal("a", result);
        }

        [Theory]
        [InlineData(@"{""x"":{""y"":{""z"":{""a"":{""b"":""c""}}}}}", "x.y.z.a.b")]
        public void Test3(string jsonStr, string jsonKey)
        {
            JObject jObject = JObject.Parse(jsonStr);

            var result = GetJsonValue(jObject, jsonKey);
            Assert.Equal("c", result);
        }

        public static JToken GetJsonValue(JObject obj, string key)
        {
            foreach (JToken token in obj.SelectTokens(key))
            {
                return token;
            }
            return null;
        }
    }
}
