using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.Dto.Request
{
   public class PowerRequest : Framework.Contract.Request
    {
        public PowerRequest()
        {
            Top = 10;
        }

        public string PowerName { get; set; }

    }
}
