// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.FilterMetadata
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using System;
using System.ComponentModel;
using System.Reflection;
using System.Web.Mvc;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// Metadata interface for filter registrations.
  /// 
  /// </summary>
  internal class FilterMetadata
  {
    /// <summary>
    /// Gets the type of the controller.
    /// 
    /// </summary>
    [DefaultValue(null)]
    public Type ControllerType { get; set; }

    /// <summary>
    /// Gets the filter scope.
    /// 
    /// </summary>
    [DefaultValue(FilterScope.First)]
    public FilterScope FilterScope { get; set; }

    /// <summary>
    /// Gets the method info.
    /// 
    /// </summary>
    [DefaultValue(null)]
    public MethodInfo MethodInfo { get; set; }

    /// <summary>
    /// Gets the order in which the filter is applied.
    /// 
    /// </summary>
    [DefaultValue(-1)]
    public int Order { get; set; }
  }
}
