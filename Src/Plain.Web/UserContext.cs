using System;
using Core.Cache;
using Core.Exception;
using Core.Service;
using Plain.BLL.LoginService;
using Plain.BLL.UserService;
using Plain.Model.Models;
using Plain.Model.Models.Model;
using Plain.Dto;

namespace Plain.Web
{
    public class UserContext
    {
        protected IAuthCookie AuthCookie;

        public UserContext(IAuthCookie authCookie)
        {
            this.AuthCookie = authCookie;
        }

        public Basic_LoginInfo LoginInfo 
        {
            get
            {
                return CacheContext.Get("LoginInfo_"+AuthCookie.UserToken.ToString(), () =>
                { 
                    if (AuthCookie.UserToken == Guid.Empty)
                    {
                        return null;
                    }
                    var loginInfo =
                        ServiceContext.Current.CreateService<ILoginService>().GetLoginInfoByToken(AuthCookie.UserToken);
                    if (loginInfo != null && loginInfo.LoginUserId > 0 &&
                        loginInfo.LoginUserId != this.AuthCookie.UserId)
                    {
                        //写日志，记录登录信息，封锁IP
                        throw new AuthValideException("非法操作，试图通过修改Cookie获得用户信息，已经记录IP和相关信息，如果超过3次，将封锁IP");
                    }
                    return loginInfo;
                });
            }
        }

        //public Basic_UserInfo BasicUserInfo
        //{
        //    get
        //    {
        //        if (LoginInfo != null)
        //        {
        //            return ServiceContext.Current.CreateService<IUserService>().GetUserByUserId(LoginInfo.LoginUserId);
        //        }
        //        return null;
        //    }
        //}


    }
}