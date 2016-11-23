using System;
using System.Collections.Generic;
using Plain.Dto;
using Plain.Model.Models;
using Plain.Model.Models.Model;

namespace Plain.BLL.LoginService
{
    public interface ILoginService : IBaseService<Basic_LoginInfo>
    {
        Basic_LoginInfo GetLoginInfoByToken(Guid token);
        Basic_LoginInfo GetLoginInfoByLoginName(string loginName);
        Basic_LoginInfo Login(string loginName, string password, LoginType loginType = LoginType.NormalLogin);
        Basic_LoginInfo LoginTest(string loginName, string password, LoginType loginType = LoginType.NormalLogin);
        List<Basic_LoginInfo> GetListLoginInfoByLoginName(string loginName);
        bool LoginOut(Guid loginName);

        Basic_LoginInfo AddLoginInfo(Basic_LoginInfo entity);

        List<Basic_LoginInfo> GetOnlineUser();

    }
}