using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllershttps
{
    public class HomeController : ApiController
    {

        public HomeController()
        {
          
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var results = new DataAcessRepository().ReadInfo();
            return results;
        }
    }
}