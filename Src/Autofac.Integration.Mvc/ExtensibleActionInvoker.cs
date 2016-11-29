// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.ExtensibleActionInvoker
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using Autofac;
using Autofac.Core;
using System;
using System.Web.Mvc;
using System.Web.Mvc.Async;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// Injects services from the container into the ASP.NET MVC invocation pipeline.
  ///             This is a Async Controller Action Invoker which can be used for both async and non-async scenarios
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// 
  /// <para>
  /// Action methods can include parameters that will be resolved from the
  ///             container, along with regular parameters.
  /// 
  /// </para>
  /// 
  /// </remarks>
  public class ExtensibleActionInvoker : AsyncControllerActionInvoker
  {
    /// <summary>
    /// If set, this is used to determine which model properties are injected.
    /// 
    /// </summary>
    //private readonly IPropertySelector _propertySelector;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Autofac.Integration.Mvc.ExtensibleActionInvoker"/> class.
    /// 
    /// </summary>
    public ExtensibleActionInvoker()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Autofac.Integration.Mvc.ExtensibleActionInvoker"/> class.
    /// 
    /// </summary>
    /// <param name="propertySelector">The inject property selector.</param>
    //public ExtensibleActionInvoker(IPropertySelector propertySelector)
    //{
    //  this._propertySelector = propertySelector;
    //}

    /// <summary>
    /// Gets the parameter value.
    /// 
    /// </summary>
    /// <param name="controllerContext">The controller context.</param><param name="parameterDescriptor">The parameter descriptor.</param>
    /// <returns>
    /// The parameter value.
    /// 
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="parameterDescriptor"/> is <see langword="null"/>.
    ///             </exception>
    protected override object GetParameterValue(ControllerContext controllerContext, ParameterDescriptor parameterDescriptor)
    {
      if (parameterDescriptor == null)
        throw new ArgumentNullException("parameterDescriptor");
      object instance = (object) null;
      try
      {
        instance = base.GetParameterValue(controllerContext, parameterDescriptor);
      }
      catch (MissingMethodException ex)
      {
      }
      ILifetimeScope requestLifetimeScope = AutofacDependencyResolver.Current.RequestLifetimeScope;
      if (instance == null)
        instance = ResolutionExtensions.ResolveOptional((IComponentContext) requestLifetimeScope, parameterDescriptor.ParameterType);
      //if (this._propertySelector != null && instance != null)
      //  ResolutionExtensions.InjectProperties<object>((IComponentContext) requestLifetimeScope, instance, this._propertySelector);
      return instance;
    }
  }
}
