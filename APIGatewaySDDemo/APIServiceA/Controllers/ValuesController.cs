namespace APIServiceA.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "I'm ServiceA";
        }             
    }
}
