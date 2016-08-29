using System.Collections.Generic;
using Plain.Model.Models;

namespace Plain.BLL.LoginService
{
    public interface ILoginService : IBaseService<Basic_LoginInfo>
    {
        Basic_LoginInfo GetLoginInfoByToken(string token);
        Basic_LoginInfo GetLoginInfoByLoginName(string loginName);
        List<Basic_LoginInfo> GetListLoginInfoByLoginName(string loginName);
        bool LoginOut(string loginName);

        Basic_LoginInfo AddLoginInfo(Basic_LoginInfo entity);

        List<Basic_LoginInfo> GetOnlineUser();

    }
}