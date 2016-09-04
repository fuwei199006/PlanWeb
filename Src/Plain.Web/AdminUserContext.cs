using Core.Cache;

namespace Plain.Web
{
    public class AdminUserContext:UserContext
    {
        public AdminUserContext(IAuthCookie authCookie) : base(authCookie)
        {
        }

        public AdminUserContext()
            : base(AdminCookieContext.Current)
        {
        }

        public static AdminUserContext Current
        {
            get { return CacheContext.GetItem<AdminUserContext>(); }
        }
    }
}