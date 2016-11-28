// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.AuthenticationFilterOverride
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using System;
using System.Web.Mvc.Filters;

namespace Autofac.Integration.Mvc
{
  internal class AuthenticationFilterOverride : IAuthenticationFilter, IOverrideFilter
  {
    private readonly IAuthenticationFilter _wrappedFilter;

    public Type FiltersToOverride
    {
      get
      {
        return typeof (IAuthenticationFilter);
      }
    }

    public AuthenticationFilterOverride(IAuthenticationFilter wrappedFilter)
    {
      this._wrappedFilter = wrappedFilter;
    }

    public void OnAuthentication(AuthenticationContext filterContext)
    {
      this._wrappedFilter.OnAuthentication(filterContext);
    }

    public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
    {
      this._wrappedFilter.OnAuthenticationChallenge(filterContext);
    }
  }
}
