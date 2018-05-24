namespace APIServiceA.Controllers
{    
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    
    /// <summary>
    /// Values controller.
    /// </summary>
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        /// <summary>
        /// Get values.
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
