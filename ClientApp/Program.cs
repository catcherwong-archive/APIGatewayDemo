namespace ClientApp
{
    using System;
    using System.Net.Http;
    using Newtonsoft.Json;
    
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Clear();
            client.BaseAddress = new Uri("http://localhost:9000");

            var resWithoutToken = client.GetAsync("/customers").Result;

            Console.WriteLine($"Send Request to /customers , without token:{resWithoutToken.StatusCode}");

            if (resWithoutToken.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(resWithoutToken.Content.ReadAsStringAsync().Result);
            }

            Console.WriteLine("Begin Auth....");

            var jwt = GetJwt();

            Console.WriteLine("End Auth....");
            Console.WriteLine($"Token={jwt}");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");

            var resWithToken = client.GetAsync("/customers").Result;

            Console.WriteLine($"Send Request to /customers , with token):{resWithToken.StatusCode}");

            if (resWithToken.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(resWithToken.Content.ReadAsStringAsync().Result);
            }


            Console.WriteLine("No Auth API");

            var res = client.GetAsync("/customers/1").Result;

            Console.WriteLine($"Send Request to /customers/1:{res.StatusCode}");

            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(res.Content.ReadAsStringAsync().Result);
            }

            Console.Read();
        }


        private static string GetJwt()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri( "http://localhost:9000");
            client.DefaultRequestHeaders.Clear();

            var res2 = client.GetAsync("/api/auth?name=catcher&pwd=123").Result;

            dynamic jwt = JsonConvert.DeserializeObject(res2.Content.ReadAsStringAsync().Result);

            return jwt.access_token;
        }
    }
}
