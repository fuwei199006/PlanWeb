using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.Dto
{
    public enum MsgType
    {
        Error,Success,Info
    }

    public enum ReturnInfo
    {
        Yes,No
    }

    public class MenuType
    {
        public const string Nav = "Nav";
        public const string Item = "Item";
        public const string Group = "Group";
 
    }
}
