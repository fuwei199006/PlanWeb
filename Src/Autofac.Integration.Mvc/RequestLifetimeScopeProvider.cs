// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.RequestLifetimeScopeProvider
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using Autofac;
using Autofac.Core.Lifetime;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Web;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// Creates and disposes HTTP request based lifetime scopes.
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// The provider is notified when a HTTP request ends by the <see cref="T:Autofac.Integration.Mvc.RequestLifetimeHttpModule"/>.
  /// 
  /// </remarks>
  public class RequestLifetimeScopeProvider : ILifetimeScopeProvider
  {
    private readonly ILifetimeScope _container;

    /// <summary>
    /// Gets the global, application-wide container.
    /// 
    /// </summary>
    public ILifetimeScope ApplicationContainer
    {
      get
      {
        return this._container;
      }
    }

    private static ILifetimeScope LifetimeScope
    {
      get
      {
        return (ILifetimeScope) HttpContext.Current.Items[(object) typeof (ILifetimeScope)];
      }
      set
      {
        HttpContext.Current.Items[(object) typeof (ILifetimeScope)] = (object) value;
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Autofac.Integration.Mvc.RequestLifetimeScopeProvider"/> class.
    /// 
    /// </summary>
    /// <param name="container">The parent container, usually the application container.</param>
    public RequestLifetimeScopeProvider(ILifetimeScope container)
    {
      if (container == null)
        throw new ArgumentNullException("container");
      this._container = container;
      RequestLifetimeHttpModule.SetLifetimeScopeProvider((ILifetimeScopeProvider) this);
    }

    /// <summary>
    /// Gets a nested lifetime scope that services can be resolved from.
    /// 
    /// </summary>
    /// <param name="configurationAction">A configuration action that will execute during lifetime scope creation.
    ///             </param>
    /// <returns>
    /// A new or existing nested lifetime scope.
    /// </returns>
    public ILifetimeScope GetLifetimeScope(Action<ContainerBuilder> configurationAction)
    {
      if (HttpContext.Current == null)
        throw new InvalidOperationException(RequestLifetimeScopeProviderResources.HttpContextNotAvailable);
      if (RequestLifetimeScopeProvider.LifetimeScope == null && (RequestLifetimeScopeProvider.LifetimeScope = this.GetLifetimeScopeCore(configurationAction)) == null)
      {
        CultureInfo currentCulture = CultureInfo.CurrentCulture;
        string lifetimeScopeReturned = RequestLifetimeScopeProviderResources.NullLifetimeScopeReturned;
        object[] objArray = new object[1];
        int index = 0;
        string fullName = this.GetType().FullName;
        objArray[index] = (object) fullName;
        throw new InvalidOperationException(string.Format((IFormatProvider) currentCulture, lifetimeScopeReturned, objArray));
      }
      return RequestLifetimeScopeProvider.LifetimeScope;
    }

    /// <summary>
    /// Ends the current HTTP request lifetime scope.
    /// 
    /// </summary>
    public void EndLifetimeScope()
    {
      ILifetimeScope lifetimeScope = RequestLifetimeScopeProvider.LifetimeScope;
      if (lifetimeScope == null)
        return;
      lifetimeScope.Dispose();
    }

    /// <summary>
    /// Gets a lifetime scope for the current HTTP request. This method can be overridden
    ///             to alter the way that the life time scope is constructed.
    /// 
    /// </summary>
    /// <param name="configurationAction">A configuration action that will execute during lifetime scope creation.
    ///             </param>
    /// <returns>
    /// A new lifetime scope for the current HTTP request.
    /// </returns>
    [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
    protected virtual ILifetimeScope GetLifetimeScopeCore(Action<ContainerBuilder> configurationAction)
    {
      if (configurationAction != null)
        return this.ApplicationContainer.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag, configurationAction);
      return this.ApplicationContainer.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
    }
  }
}
