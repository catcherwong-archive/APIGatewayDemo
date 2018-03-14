namespace APIServices.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static int _count = 0;

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _count++;
            System.Console.WriteLine($"get...{_count}");
            if(_count <= 3)
            {
                Thread.Sleep(5000);
            }            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
