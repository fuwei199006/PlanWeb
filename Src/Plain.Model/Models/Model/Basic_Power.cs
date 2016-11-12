using System;
using System.Collections.Generic;
using Framework.Contract;

namespace Plain.Model.Models.Model
{
    public partial class Basic_Power : ModelBase
    {

        public string PoweName { get; set; }
        public int PowerStatus { get; set; }
        public string PowerGroup { get; set; }
        public DateTime ModifyTime { get; set; }
    }
}
