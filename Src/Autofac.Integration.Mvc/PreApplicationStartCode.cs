// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.PreApplicationStartCode
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using System.ComponentModel;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// Container class for the ASP.NET application startup method.
  /// 
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public static class PreApplicationStartCode
  {
    private static bool _startWasCalled;

    /// <summary>
    /// Performs ASP.NET application startup logic early in the pipeline.
    /// 
    /// </summary>
    public static void Start()
    {
      if (PreApplicationStartCode._startWasCalled)
        return;
      PreApplicationStartCode._startWasCalled = true;
      DynamicModuleUtility.RegisterModule(typeof (RequestLifetimeHttpModule));
    }
  }
}
