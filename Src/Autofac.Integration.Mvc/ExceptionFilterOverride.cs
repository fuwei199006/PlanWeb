// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.ExceptionFilterOverride
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Autofac.Integration.Mvc
{
  internal class ExceptionFilterOverride : IExceptionFilter, IOverrideFilter
  {
    private readonly IExceptionFilter _wrappedFilter;

    public Type FiltersToOverride
    {
      get
      {
        return typeof (IExceptionFilter);
      }
    }

    public ExceptionFilterOverride(IExceptionFilter wrappedFilter)
    {
      this._wrappedFilter = wrappedFilter;
    }

    public void OnException(ExceptionContext filterContext)
    {
      this._wrappedFilter.OnException(filterContext);
    }
  }
}
