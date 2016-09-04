using System;
using System.Collections.Generic;
using Core.Encrypt;
using Core.Service;
using Framework.Utility;
using Plain.DAL;
using Plain.Model.Models;

namespace Plain.BLL.LoginService
{
    public class LoginService : BaseService<Basic_LoginInfo>, ILoginService
    {
        public Basic_LoginInfo GetLoginInfoByToken(Guid token)
        {
            return this.CurrentResposity.Get(r => r.LoginToken  == token&&r.ExpireTime>DateTime.Now&&!r.IsDelete);
        }

        public Basic_LoginInfo GetLoginInfoByLoginName(string loginName)
        {
            return this.CurrentResposity.Get(r => r.LoginName == loginName && r.ExpireTime > DateTime.Now && !r.IsDelete);
        }

       

        public Basic_LoginInfo Login(string loginName, string password,int loginType=1)
        {
            Basic_LoginInfo loginInfo = null;
            var keyPass = MD5Encrypt.Md5(password);
            var user =
                ServiceContext.CreateService<UserService.UserService>()
                    .Get(r => r.LoginName == loginName && r.UserPwd == keyPass && r.UserStaus == 1);
            if (user != null)
            {
                var ip = Fetch.UserIp;
                loginInfo = this.CurrentResposity.Get(r => r.LoginName == loginName && r.LoginIp == ip&&!r.IsDelete);
                if (loginInfo != null)
                {
                    loginInfo.LastUpdateTime=DateTime.Now;
                    loginInfo.ExpireTime = DateTime.Now.AddHours(1);
                    loginInfo.LoginIp = Fetch.UserIp;
                    this.CurrentResposity.Update(loginInfo);
                }
                else
                {
                    loginInfo = new Basic_LoginInfo(user.Id,loginName);
                    loginInfo.LoginType = loginType;
                    loginInfo.ExpireTime = DateTime.Now.AddHours(1);
                    loginInfo.LoginIp = Fetch.UserIp;
                    this.CurrentResposity.Add(loginInfo);

                }
            }
            return loginInfo;

        }

        public List<Basic_LoginInfo> GetListLoginInfoByLoginName(string loginName)
        {
            return this.CurrentResposity.GetList(r => r.LoginName == loginName && r.ExpireTime > DateTime.Now && !r.IsDelete);
        }
        public bool LoginOut(Guid token)
        {
            var entity = this.CurrentResposity.Get(r => r.LoginToken==token);
            if (entity == null) return true;
            entity.IsDelete = true;
            entity.LastUpdateTime=DateTime.Now;
            var res=   CurrentResposity.Update(entity);
            return res != null;

        }

        public Basic_LoginInfo AddLoginInfo(Basic_LoginInfo entity)
        {
            var existLogin = this.GetListLoginInfoByLoginName(entity.LoginName);
            if (existLogin != null && existLogin.Count > 0)
            {
                existLogin.ForEach(x =>
                {
                    //添加前先删除原来的登录信息
                    this.LoginOut(x.LoginToken);
                });

            }
            entity.CreateTime=DateTime.Now;
            entity.LoginTime=DateTime.Now;
            var res = CurrentResposity.Add(entity);
            return res;
        }

        public List<Basic_LoginInfo> GetOnlineUser()
        {
            return this.CurrentResposity.GetList(r => r.IsDelete&&r.ExpireTime>DateTime.Now);

        }
    }
}