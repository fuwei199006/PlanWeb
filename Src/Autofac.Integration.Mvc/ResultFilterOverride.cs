// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.ResultFilterOverride
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Autofac.Integration.Mvc
{
  internal class ResultFilterOverride : IResultFilter, IOverrideFilter
  {
    private readonly IResultFilter _wrappedFilter;

    public Type FiltersToOverride
    {
      get
      {
        return typeof (IResultFilter);
      }
    }

    public ResultFilterOverride(IResultFilter wrappedFilter)
    {
      this._wrappedFilter = wrappedFilter;
    }

    public void OnResultExecuted(ResultExecutedContext filterContext)
    {
      this._wrappedFilter.OnResultExecuted(filterContext);
    }

    public void OnResultExecuting(ResultExecutingContext filterContext)
    {
      this._wrappedFilter.OnResultExecuting(filterContext);
    }
  }
}
