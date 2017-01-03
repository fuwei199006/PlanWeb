using System;
using System.Web;
using Core.Encrypt;

using Framework.Utility;
using Framework.Utility.Extention;

namespace Plain.Web
{
    public class CookieContext:IAuthCookie
    {
        #region IAuthCookie


        private   int _userExpiresHoures = 10;

        public virtual int UserExpiresHours
        {
            get { return _userExpiresHoures; }
            set { _userExpiresHoures = value; }
        }

        public virtual string UserName
        {
            get { return HttpUtility.UrlDecode(Cookie.GetValue(KeyPrefix + "UserName")); }
            set
            {
                Cookie.Save(KeyPrefix+"UserName",HttpUtility.UrlDecode(value),UserExpiresHours);
            }
        }

        public virtual int UserId
        {
            get { return Cookie.GetValue(KeyPrefix + "UserId").ToInt(); }
            set { Cookie.Save(KeyPrefix + "UserId", HttpUtility.HtmlEncode(value), UserExpiresHours); }
        }

        public virtual Guid UserToken
        {
            get
            {
                return Cookie.GetValue(KeyPrefix + "UserToken").ToGuid();
            }
            set
            {
                Cookie.Save(KeyPrefix + "UserToken", value.ToString(), UserExpiresHours);
            }
        }

        public virtual Guid VerifyCodeGuid
        {
            get
            {
                var verifyCodeGuid = Cookie.GetValue(KeyPrefix + "VerifyCodeGuid");
                return Guid.Parse(verifyCodeGuid);
            }
            set
            {
                Cookie.Save(KeyPrefix + "VerifyCodeGuid", value.ToString(), 1);
            }
        }

        public virtual string VerifyCode
        {
            get
            {
                var verifyCode = DESEncrypt.Decode(Cookie.GetValue(KeyPrefix + "VerifyCode"));

                //获取完Cookie后马上过期，重新生成新的验证码
                Cookie.Save(KeyPrefix + "VerifyCode", DESEncrypt.Encode(DateTime.Now.Ticks.ToString()), 1);

                return verifyCode;
            }
            set
            {
                Cookie.Save(KeyPrefix + "VerifyCode", DESEncrypt.Encode(value), 1);
            }
        }

        public virtual int LoginErrorTimes
        {
            get
            {
                return Cookie.GetValue(KeyPrefix + "LoginErrorTimes").ToInt();
            }
            set
            {
                Cookie.Save(KeyPrefix + "LoginErrorTimes", value.ToString(), 1);
            }
        }

        public bool IsNeedVerifyCode
        {
            get
            {
                return LoginErrorTimes > 1;
            }
        }
        #endregion


        public virtual string KeyPrefix
        {
            get { return "Context_"; }
        }

        public void Set(string key, string value, int expiresHours = 0)
        {
            if (expiresHours > 0)
            {
               Cookie.Save(KeyPrefix+key,value,expiresHours);
            }
            else
            {
                Cookie.Save(KeyPrefix+key,value);
            }
        }
    }
}