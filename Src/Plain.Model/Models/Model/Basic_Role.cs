using System;
using System.Collections.Generic;
using Framework.Contract;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Plain.Model.Models.Model
{
    [Serializable]
    public partial class Basic_Role : ModelBase
    {
 
        public string RoleName { get; set; }
        public  int  RoleStatus { get; set; }

        public string RoleGroup { get; set; }
 
        public DateTime? ModifyTime { get; set; }

        [NotMapped]
        public List<Basic_Power> Powers
        {
            get;set;
        }

        public List<int> PowerIds
        {
            get { return Powers.Select(x => x.Id).ToList(); }
        } 
    }
}
