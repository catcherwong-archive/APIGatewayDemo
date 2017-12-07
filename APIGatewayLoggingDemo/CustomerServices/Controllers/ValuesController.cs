namespace CustomerServices.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
            
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
