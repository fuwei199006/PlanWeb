using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Plain.UI.Areas.PlanApi.Controllers
{
    public class LoginApiController : ApiController
    {
        // GET: api/LoginApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        public IEnumerable<string> Get([FromBody]string value)
        {
            return new string[] { "value1", "value2",value };
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
