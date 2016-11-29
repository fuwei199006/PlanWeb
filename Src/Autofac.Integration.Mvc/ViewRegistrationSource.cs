// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.ViewRegistrationSource
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using Autofac;
using Autofac.Builder;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// A registration source for building view registrations.
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// Supports view registrations for <see cref="T:System.Web.Mvc.WebViewPage"/>, <see cref="T:System.Web.Mvc.ViewPage"/>,
  ///             <see cref="T:System.Web.Mvc.ViewMasterPage"/> and <see cref="T:System.Web.Mvc.ViewUserControl"/> derived types.
  /// 
  /// </remarks>
  public class ViewRegistrationSource : IRegistrationSource
  {
    /// <summary>
    /// Gets whether the registrations provided by this source are 1:1 adapters on top
    ///             of other components (I.e. like Meta, Func or Owned.)
    /// 
    /// </summary>
    public bool IsAdapterForIndividualComponents
    {
      get
      {
        return false;
      }
    }

    /// <summary>
    /// Retrieve registrations for an unregistered service, to be used
    ///             by the container.
    /// 
    /// </summary>
    /// <param name="service">The service that was requested.</param><param name="registrationAccessor">A function that will return existing registrations for a service.</param>
    /// <returns>
    /// Registrations providing the service.
    /// </returns>
    public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
    {
      IServiceWithType serviceWithType = service as IServiceWithType;
      if (serviceWithType != null && ViewRegistrationSource.IsSupportedView(serviceWithType.ServiceType))
        yield return RegistrationBuilder.CreateRegistration<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.PropertiesAutowired<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>(RegistrationBuilder.ForType(serviceWithType.ServiceType), PropertyWiringOptions.None).InstancePerDependency());
    }

    private static bool IsSupportedView(Type serviceType)
    {
      if (!TypeExtensions.IsAssignableTo<WebViewPage>(serviceType) && !TypeExtensions.IsAssignableTo<ViewPage>(serviceType) && !TypeExtensions.IsAssignableTo<ViewMasterPage>(serviceType))
        return TypeExtensions.IsAssignableTo<ViewUserControl>(serviceType);
      return true;
    }
  }
}
