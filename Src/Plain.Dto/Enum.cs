
using Framework.Utility;
using Framework.Utility.Extention;
using Framework.Utility.Extention.MainData;

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
        Item = 2,
        [EnumTitle("功能")]
        Function = 3
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
        /// <summary>
        /// 不允许查询和使用,需要管理员禁用（可能对于长时间不用系统的人，账号禁用）
        /// </summary>
        [EnumTitle("禁用")]
        Disable = 1,
        /// <summary>
        /// 允许查询，但不允许登录
        /// </summary>
        [EnumTitle("可用")]
        Enable = 2,
        /// <summary>
        /// 允许查询，不允许登录，注册的时候初始化使用。
        /// </summary>
        [EnumTitle("未激活")] 
        UnActive = 3,
        /// <summary>
        /// 系统正常使用用户
        /// </summary>
        [EnumTitle("激活")] 
        Active = 4,
        /// <summary>
        /// 可以查询，无法登录。系统已经锁定用户，无法使用。
        /// </summary>
        [EnumTitle("锁定")] 
        Lock = 5
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
        [EnumTitle("系统权限")]
        SystemPower = 1,
        [EnumTitle("数据权限")]
        DataPower = 2,
        [EnumTitle("部门权限")]
        DeptPower = 3,
        [EnumTitle("其它权限")]
        OtherPower = 4,
    }


    public enum RunType
    {
        [EnumTitle("打开")]
        On = 1,
        [EnumTitle("关闭")]
        Off = 0
    }


    public enum ArticleType
    {
        [EnumTitle("原创")]
        Original,
        [EnumTitle("评论")]
        Comment,
        [EnumTitle("话题")]
        Topic,
        [EnumTitle("其它")]
        Other
    
    }

    public enum ArticleStatus
    {
        [EnumTitle("不可用")]
        Disable =0,
        [EnumTitle("可用")]
        Enable =1,
        [EnumTitle("上线")]
        InUsing =2,
        [EnumTitle("失效")]
        LostUsing =3
    }
}
