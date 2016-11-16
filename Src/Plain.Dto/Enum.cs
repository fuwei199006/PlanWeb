using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Utility;
using Framework.Utility.ValideCode;

namespace Plain.Dto
{

    //todo:现在的主数据的获取都是通过程序集的反射的方式获取，后面可以改成由配置文件决定读取的方式，db,程序集，xml文件
    public enum MsgType
    {
        Error, Success, Info
    }

    public enum ReturnInfo
    {
        Yes, No
    }

    public enum MenuType
    {
        [EnumTitle("导航菜单")]
        Nav = 0,
        [EnumTitle("群组菜单")]
        Group = 1,
        [EnumTitle("子菜单")]
        Item = 2
    }

    public enum LoginType
    {
        [EnumTitle("单点登录")]
        SingleLogin = 1,
        [EnumTitle("正常登录")]
        NormalLogin = 2,
        [EnumTitle("接口调用登录")]
        ApiLogin = 3
    }


    public enum StatusType
    {
        [EnumTitle("可用")]
        Enable = 1,
        [EnumTitle("禁用")]
        Disable = 0
    }

    public enum UserStausType
    {
        [EnumTitle("禁用")]
        Disable = 1,
        [EnumTitle("可用")]
        Enable = 2,
        [EnumTitle("未激活")]
        UnActive = 3,
        [EnumTitle("激活")]
        Active = 4
    }

    public enum SexType
    {
        [EnumTitle("女")]
        Female = 0,
        [EnumTitle("男")]
        Male = 1
    }

    public enum RoleGroup
    {
        [EnumTitle("系统角色")]
        SystemRole = 1,
        [EnumTitle("数据角色")]
        DataRole = 2,
        [EnumTitle("部门角色")]
        DeptRole = 3,
        [EnumTitle("其它角色")]
        OtherRole = 4,
    }

    public enum PowerGroup
    {
        [EnumTitle("系统角色")]
        SystemPower = 1,
        [EnumTitle("数据角色")]
        DataPower = 2,
        [EnumTitle("部门角色")]
        DeptPower = 3,
        [EnumTitle("其它角色")]
        OtherPower = 4,
    }
}
