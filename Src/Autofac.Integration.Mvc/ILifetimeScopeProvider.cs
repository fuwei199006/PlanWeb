// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.ILifetimeScopeProvider
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using Autofac;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// Implementors are able to control the creation of nested lifetime scopes.
  /// 
  /// </summary>
  public interface ILifetimeScopeProvider
  {
    /// <summary>
    /// Gets the global, application-wide container.
    /// 
    /// </summary>
    ILifetimeScope ApplicationContainer { get; }

    /// <summary>
    /// Gets a nested lifetime scope that services can be resolved from.
    /// 
    /// </summary>
    /// <param name="configurationAction">A configuration action that will execute during lifetime scope creation.
    ///             </param>
    /// <returns>
    /// A new or existing nested lifetime scope.
    /// </returns>
    [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
    ILifetimeScope GetLifetimeScope(Action<ContainerBuilder> configurationAction);

    /// <summary>
    /// Ends the current lifetime scope.
    /// 
    /// </summary>
    void EndLifetimeScope();
  }
}
