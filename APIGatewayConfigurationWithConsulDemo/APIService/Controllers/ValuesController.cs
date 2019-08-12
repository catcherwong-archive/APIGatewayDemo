namespace APIService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/demo1
        [HttpGet("demo1")]
        public ActionResult<string> GetDemo1()
        {
            return "demo1";
        }

        // GET api/values/demo2
        [HttpGet("demo2")]
        public ActionResult<string> GetDemo2()
        {
            return "demo2";
        }

        // GET api/values/demo3
        [HttpGet("demo3")]
        public ActionResult<string> GetDemo3()
        {
            return "demo3";
        }

        // GET api/values/demo4
        [HttpGet("demo4")]
        public ActionResult<string> GetDemo4()
        {
            return "demo4";
        }
    }
}
