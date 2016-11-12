using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public partial class Basic_UserRole : ModelBase
    {


 
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public  bool  MappingStatus { get; set; }
   
        public  System.DateTime  ModifyTime { get; set; }
    }
}
