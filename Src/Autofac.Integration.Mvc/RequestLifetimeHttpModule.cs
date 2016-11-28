// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.RequestLifetimeHttpModule
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using System;
using System.Web;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// An <see cref="T:System.Web.IHttpModule"/> and <see cref="T:Autofac.Integration.Mvc.ILifetimeScopeProvider"/> implementation
  ///             that creates a nested lifetime scope for each HTTP request.
  /// 
  /// </summary>
  internal class RequestLifetimeHttpModule : IHttpModule
  {
    /// <summary>
    /// Gets the lifetime scope provider that should be notified when a HTTP request ends.
    /// 
    /// </summary>
    internal static ILifetimeScopeProvider LifetimeScopeProvider { get; private set; }

    /// <summary>
    /// Initializes a module and prepares it to handle requests.
    /// 
    /// </summary>
    /// <param name="context">An <see cref="T:System.Web.HttpApplication"/> that provides access to the
    ///             methods, properties, and events common to all application objects within an ASP.NET application</param><exception cref="T:System.ArgumentNullException">Thrown if <paramref name="context"/> is <see langword="null"/>.
    ///             </exception>
    public void Init(HttpApplication context)
    {
      if (context == null)
        throw new ArgumentNullException("context");
      context.EndRequest += new EventHandler(RequestLifetimeHttpModule.OnEndRequest);
    }

    /// <summary>
    /// Disposes of the resources (other than memory) used by the module that implements <see cref="T:System.Web.IHttpModule"/>.
    /// 
    /// </summary>
    public void Dispose()
    {
    }

    public static void SetLifetimeScopeProvider(ILifetimeScopeProvider lifetimeScopeProvider)
    {
      if (lifetimeScopeProvider == null)
        throw new ArgumentNullException("lifetimeScopeProvider");
      RequestLifetimeHttpModule.LifetimeScopeProvider = lifetimeScopeProvider;
    }

    private static void OnEndRequest(object sender, EventArgs e)
    {
      if (RequestLifetimeHttpModule.LifetimeScopeProvider == null)
        return;
      RequestLifetimeHttpModule.LifetimeScopeProvider.EndLifetimeScope();
    }
  }
}
