using System;
using System.Collections.Generic;
using Plain.Model.Models;

namespace Plain.BLL.LoginService
{
    public class LoginService : BaseService<Basic_LoginInfo>, ILoginService
    {
        public Basic_LoginInfo GetLoginInfoByToken(string token)
        {
            return this.CurrentResposity.Get(r => r.LoginToken.ToString() == token&&r.ExpireTime>DateTime.Now&&!r.IsDelete);
        }

        public Basic_LoginInfo GetLoginInfoByLoginName(string loginName)
        {
            return this.CurrentResposity.Get(r => r.LoginName == loginName && r.ExpireTime > DateTime.Now && !r.IsDelete);
        }
        public List<Basic_LoginInfo> GetListLoginInfoByLoginName(string loginName)
        {
            return this.CurrentResposity.GetList(r => r.LoginName == loginName && r.ExpireTime > DateTime.Now && !r.IsDelete);
        }
        public bool LoginOut(string loginName)
        {
            var entity = this.CurrentResposity.Get(r => r.LoginName == loginName && r.ExpireTime > DateTime.Now && !r.IsDelete);
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
                    this.LoginOut(x.LoginName);

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