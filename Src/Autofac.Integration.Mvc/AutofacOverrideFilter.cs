// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.AutofacOverrideFilter
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using System;
using System.Web.Mvc.Filters;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// Allows other filters to be overriden at the control and action level.
  /// 
  /// </summary>
  internal class AutofacOverrideFilter : IOverrideFilter
  {
    public Type FiltersToOverride { get; private set; }

    public AutofacOverrideFilter(Type filtersToOverride)
    {
      this.FiltersToOverride = filtersToOverride;
    }
  }
}
