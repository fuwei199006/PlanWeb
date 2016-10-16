using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Utility;
using Framework.Utility.ValideCode;

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

    public enum LoginType
    {
        [EnumTitle("单点登录")]
        SingleLogin=1,
        [EnumTitle("正常登录")]
        NormalLogin=2,
        [EnumTitle("接口调用登录")]
        ApiLogin=3
    }
}
