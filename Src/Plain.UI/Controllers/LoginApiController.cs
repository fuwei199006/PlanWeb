using System.Collections.Generic;
using System.Web.Http;

namespace Plain.UI.Controllers
{
    public class LoginApiController : ApiController
    {
        // GET: api/LoginApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/LoginApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LoginApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LoginApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LoginApi/5
        public void Delete(int id)
        {
        }
    }
}
