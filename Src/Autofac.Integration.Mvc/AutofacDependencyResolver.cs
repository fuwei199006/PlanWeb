// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.AutofacDependencyResolver
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using Autofac;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Web.Mvc;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// Autofac implementation of the <see cref="T:System.Web.Mvc.IDependencyResolver"/> interface.
  /// 
  /// </summary>
  public class AutofacDependencyResolver : IDependencyResolver
  {
    private static Func<AutofacDependencyResolver> _resolverAccessor = new Func<AutofacDependencyResolver>(AutofacDependencyResolver.DefaultResolverAccessor);
    private readonly Action<ContainerBuilder> _configurationAction;
    private readonly ILifetimeScope _container;
    private ILifetimeScopeProvider _lifetimeScopeProvider;

    /// <summary>
    /// Gets the Autofac implementation of the dependency resolver.
    /// 
    /// </summary>
    public static AutofacDependencyResolver Current
    {
      get
      {
        return AutofacDependencyResolver._resolverAccessor();
      }
    }

    /// <summary>
    /// Gets the application container that was provided to the constructor.
    /// 
    /// </summary>
    public ILifetimeScope ApplicationContainer
    {
      get
      {
        return this._container;
      }
    }

    /// <summary>
    /// The lifetime containing components for processing the current HTTP request.
    /// 
    /// </summary>
    public ILifetimeScope RequestLifetimeScope
    {
      get
      {
        if (this._lifetimeScopeProvider == null)
          this._lifetimeScopeProvider = (ILifetimeScopeProvider) new RequestLifetimeScopeProvider(this._container);
        return this._lifetimeScopeProvider.GetLifetimeScope(this._configurationAction);
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Autofac.Integration.Mvc.AutofacDependencyResolver"/> class.
    /// 
    /// </summary>
    /// <param name="container">The container that nested lifetime scopes will be create from.</param>
    public AutofacDependencyResolver(ILifetimeScope container)
    {
      if (container == null)
        throw new ArgumentNullException("container");
      this._container = container;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Autofac.Integration.Mvc.AutofacDependencyResolver"/> class.
    /// 
    /// </summary>
    /// <param name="container">The container that nested lifetime scopes will be create from.</param><param name="configurationAction">Action on a <see cref="T:Autofac.ContainerBuilder"/>
    ///             that adds component registations visible only in nested lifetime scopes.</param>
    public AutofacDependencyResolver(ILifetimeScope container, Action<ContainerBuilder> configurationAction)
      : this(container)
    {
      if (configurationAction == null)
        throw new ArgumentNullException("configurationAction");
      this._configurationAction = configurationAction;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Autofac.Integration.Mvc.AutofacDependencyResolver"/> class.
    /// 
    /// </summary>
    /// <param name="container">The container that nested lifetime scopes will be create from.</param><param name="lifetimeScopeProvider">A <see cref="T:Autofac.Integration.Mvc.ILifetimeScopeProvider"/> implementation for
    ///             creating new lifetime scopes.</param>
    public AutofacDependencyResolver(ILifetimeScope container, ILifetimeScopeProvider lifetimeScopeProvider)
      : this(container)
    {
      if (lifetimeScopeProvider == null)
        throw new ArgumentNullException("lifetimeScopeProvider");
      this._lifetimeScopeProvider = lifetimeScopeProvider;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Autofac.Integration.Mvc.AutofacDependencyResolver"/> class.
    /// 
    /// </summary>
    /// <param name="container">The container that nested lifetime scopes will be create from.</param><param name="lifetimeScopeProvider">A <see cref="T:Autofac.Integration.Mvc.ILifetimeScopeProvider"/> implementation for
    ///             creating new lifetime scopes.</param><param name="configurationAction">Action on a <see cref="T:Autofac.ContainerBuilder"/>
    ///             that adds component registations visible only in nested lifetime scopes.</param>
    public AutofacDependencyResolver(ILifetimeScope container, ILifetimeScopeProvider lifetimeScopeProvider, Action<ContainerBuilder> configurationAction)
      : this(container, lifetimeScopeProvider)
    {
      if (configurationAction == null)
        throw new ArgumentNullException("configurationAction");
      this._configurationAction = configurationAction;
    }

    /// <summary>
    /// Sets the mechanism used to locate the current Autofac dependency resolver.
    /// 
    /// </summary>
    /// <param name="accessor">A <see cref="T:System.Func`1"/> that returns an <see cref="T:Autofac.Integration.Mvc.AutofacDependencyResolver"/>
    ///             based on the current context. Set this to <see langword="null"/> to return to the
    ///             default behavior.
    ///             </param>
    public static void SetAutofacDependencyResolverAccessor(Func<AutofacDependencyResolver> accessor)
    {
      if (accessor == null)
        AutofacDependencyResolver._resolverAccessor = new Func<AutofacDependencyResolver>(AutofacDependencyResolver.DefaultResolverAccessor);
      else
        AutofacDependencyResolver._resolverAccessor = accessor;
    }

    /// <summary>
    /// Get a single instance of a service.
    /// 
    /// </summary>
    /// <param name="serviceType">Type of the service.</param>
    /// <returns>
    /// The single instance if resolved; otherwise, <c>null</c>.
    /// </returns>
    public virtual object GetService(Type serviceType)
    {
      return ResolutionExtensions.ResolveOptional((IComponentContext) this.RequestLifetimeScope, serviceType);
    }

    /// <summary>
    /// Gets all available instances of a services.
    /// 
    /// </summary>
    /// <param name="serviceType">Type of the service.</param>
    /// <returns>
    /// The list of instances if any were resolved; otherwise, an empty list.
    /// </returns>
    public virtual IEnumerable<object> GetServices(Type serviceType)
    {
      Type type1 = typeof (IEnumerable<>);
      Type[] typeArray = new Type[1];
      int index = 0;
      Type type2 = serviceType;
      typeArray[index] = type2;
      return (IEnumerable<object>) ResolutionExtensions.Resolve((IComponentContext) this.RequestLifetimeScope, type1.MakeGenericType(typeArray));
    }

    /// <summary>
    /// Default mechanism for locating the current Autofac service resolver.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The current <see cref="T:Autofac.Integration.Mvc.AutofacDependencyResolver"/> if it can be located.
    /// 
    /// </returns>
    /// <exception cref="T:System.InvalidOperationException">Thrown if the current resolver can't be found.
    ///             </exception>
    private static AutofacDependencyResolver DefaultResolverAccessor()
    {
      IDependencyResolver current = DependencyResolver.Current;
      AutofacDependencyResolver dependencyResolver = current as AutofacDependencyResolver;
      if (dependencyResolver != null)
        return dependencyResolver;
      FieldInfo field = current.GetType().GetField("__target");
      if (field != (FieldInfo) null && field.FieldType == typeof (AutofacDependencyResolver))
        return (AutofacDependencyResolver) field.GetValue((object) current);
      CultureInfo currentCulture = CultureInfo.CurrentCulture;
      string resolverNotFound = AutofacDependencyResolverResources.AutofacDependencyResolverNotFound;
      object[] objArray = new object[2];
      int index1 = 0;
      string fullName1 = current.GetType().FullName;
      objArray[index1] = (object) fullName1;
      int index2 = 1;
      string fullName2 = typeof (AutofacDependencyResolver).FullName;
      objArray[index2] = (object) fullName2;
      throw new InvalidOperationException(string.Format((IFormatProvider) currentCulture, resolverNotFound, objArray));
    }
  }
}
