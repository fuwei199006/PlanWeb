using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.Dto.Request
{
   public class RoleRequest : Framework.Contract.Request
    {
        public RoleRequest()
        {
            Top = 10;
        }
        public string RoleName { get; set; }
    }
}
