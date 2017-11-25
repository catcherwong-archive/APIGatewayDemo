namespace CustomersAPIServices.Controllers
{
    
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Catcher Wong", "James Li" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"Catcher Wong - {id}";
        }            
    }
}
