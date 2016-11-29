// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.RegistrationExtensions
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Features.Scanning;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.SessionState;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// Extends <see cref="T:Autofac.ContainerBuilder"/> with methods to support ASP.NET MVC.
  /// 
  /// </summary>
  public static class RegistrationExtensions
  {
    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IActionFilter"/> for the specified controller.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsActionFilterFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IActionFilter, TController>(registration, AutofacFilterProvider.ActionFilterMetadataKey, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IActionFilter"/> for the specified controller action.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="actionSelector">The action selector.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsActionFilterFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, Expression<Action<TController>> actionSelector, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IActionFilter, TController>(registration, AutofacFilterProvider.ActionFilterMetadataKey, actionSelector, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IActionFilter"/> override for the specified controller.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsActionFilterOverrideFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IActionFilter, TController>(registration, AutofacFilterProvider.ActionFilterOverrideMetadataKey, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IActionFilter"/> override for the specified controller action.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="actionSelector">The action selector.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsActionFilterOverrideFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, Expression<Action<TController>> actionSelector, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IActionFilter, TController>(registration, AutofacFilterProvider.ActionFilterOverrideMetadataKey, actionSelector, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IAuthenticationFilter"/> for the specified controller.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsAuthenticationFilterFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IAuthenticationFilter, TController>(registration, AutofacFilterProvider.AuthenticationFilterMetadataKey, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IAuthenticationFilter"/> for the specified controller action.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="actionSelector">The action selector.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsAuthenticationFilterFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, Expression<Action<TController>> actionSelector, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IAuthenticationFilter, TController>(registration, AutofacFilterProvider.AuthenticationFilterMetadataKey, actionSelector, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IAuthenticationFilter"/> override for the specified controller.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsAuthenticationFilterOverrideFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IAuthenticationFilter, TController>(registration, AutofacFilterProvider.AuthenticationFilterOverrideMetadataKey, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IAuthenticationFilter"/> override for the specified controller action.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="actionSelector">The action selector.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsAuthenticationFilterOverrideFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, Expression<Action<TController>> actionSelector, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IAuthenticationFilter, TController>(registration, AutofacFilterProvider.AuthenticationFilterOverrideMetadataKey, actionSelector, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IAuthorizationFilter"/> for the specified controller.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsAuthorizationFilterFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IAuthorizationFilter, TController>(registration, AutofacFilterProvider.AuthorizationFilterMetadataKey, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IAuthorizationFilter"/> for the specified controller action.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="actionSelector">The action selector.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsAuthorizationFilterFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, Expression<Action<TController>> actionSelector, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IAuthorizationFilter, TController>(registration, AutofacFilterProvider.AuthorizationFilterMetadataKey, actionSelector, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IAuthorizationFilter"/> override for the specified controller.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsAuthorizationFilterOverrideFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IAuthorizationFilter, TController>(registration, AutofacFilterProvider.AuthorizationFilterOverrideMetadataKey, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IAuthorizationFilter"/> override for the specified controller action.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="actionSelector">The action selector.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsAuthorizationFilterOverrideFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, Expression<Action<TController>> actionSelector, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IAuthorizationFilter, TController>(registration, AutofacFilterProvider.AuthorizationFilterOverrideMetadataKey, actionSelector, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IExceptionFilter"/> for the specified controller.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsExceptionFilterFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IExceptionFilter, TController>(registration, AutofacFilterProvider.ExceptionFilterMetadataKey, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IExceptionFilter"/> for the specified controller action.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="actionSelector">The action selector.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsExceptionFilterFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, Expression<Action<TController>> actionSelector, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IExceptionFilter, TController>(registration, AutofacFilterProvider.ExceptionFilterMetadataKey, actionSelector, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IExceptionFilter"/> override for the specified controller.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsExceptionFilterOverrideFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IExceptionFilter, TController>(registration, AutofacFilterProvider.ExceptionFilterOverrideMetadataKey, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IExceptionFilter"/> override for the specified controller action.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="actionSelector">The action selector.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsExceptionFilterOverrideFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, Expression<Action<TController>> actionSelector, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IExceptionFilter, TController>(registration, AutofacFilterProvider.ExceptionFilterOverrideMetadataKey, actionSelector, order);
    }

    /// <summary>
    /// Sets a provided registration to act as an <see cref="T:System.Web.Mvc.IModelBinder"/>
    ///             for the specified list of types.
    /// 
    /// </summary>
    /// <param name="registration">The registration for the type or object instance that will act as
    ///             the model binder.
    ///             </param><param name="types">The list of model <see cref="T:System.Type"/> for which the <paramref name="registration"/>
    ///             should be a model binder.
    ///             </param><typeparam name="TLimit">Registration limit type.
    ///             </typeparam><typeparam name="TActivatorData">Activator data type.
    ///             </typeparam><typeparam name="TRegistrationStyle">Registration style.
    ///             </typeparam>
    /// <returns>
    /// An Autofac registration that can be modified as needed.
    /// 
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="registration"/> or <paramref name="types"/> is <see langword="null"/>.
    ///             </exception><exception cref="T:System.ArgumentException">Thrown if <paramref name="types"/> is empty or contains all <see langword="null"/>
    ///             values.
    ///             </exception>
    /// <remarks>
    /// 
    /// <para>
    /// The declarative mechanism of registering model binders with Autofac
    ///             is through use of <see cref="M:Autofac.Integration.Mvc.RegistrationExtensions.RegisterModelBinders(Autofac.ContainerBuilder,System.Reflection.Assembly[])"/>
    ///             and the <see cref="T:Autofac.Integration.Mvc.ModelBinderTypeAttribute"/>.
    ///             This method is an imperative alternative.
    /// 
    /// </para>
    /// 
    /// <para>
    /// The two mechanisms are mutually exclusive. If you register a model
    ///             binder using <see cref="M:Autofac.Integration.Mvc.RegistrationExtensions.RegisterModelBinders(Autofac.ContainerBuilder,System.Reflection.Assembly[])"/>
    ///             and register the same model binder with this method, the results
    ///             are not automatically merged together - standard dependency
    ///             registration/resolution rules will be used to manage the conflict.
    /// 
    /// </para>
    /// 
    /// <para>
    /// Any <see langword="null"/> values provided in <paramref name="types"/>
    ///             will be removed prior to registration.
    /// 
    /// </para>
    /// 
    /// </remarks>
    public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> AsModelBinderForTypes<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registration, params Type[] types) where TActivatorData : IConcreteActivatorData where TRegistrationStyle : SingleRegistrationStyle
    {
      if (registration == null)
        throw new ArgumentNullException("registration");
      if (types == null)
        throw new ArgumentNullException("types");
      List<Type> list = Enumerable.ToList<Type>(Enumerable.Where<Type>((IEnumerable<Type>) types, (Func<Type, bool>) (type => type != (Type) null)));
      if (list.Count == 0)
        throw new ArgumentException(RegistrationExtensionsResources.InvalidModelBinderType, "types");
      return registration.As<IModelBinder>().WithMetadata(AutofacModelBinderProvider.MetadataKey, (object) list);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IResultFilter"/> for the specified controller.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsResultFilterFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IResultFilter, TController>(registration, AutofacFilterProvider.ResultFilterMetadataKey, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IResultFilter"/> for the specified controller action.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="actionSelector">The action selector.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsResultFilterFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, Expression<Action<TController>> actionSelector, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IResultFilter, TController>(registration, AutofacFilterProvider.ResultFilterMetadataKey, actionSelector, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IResultFilter"/> override for the specified controller.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsResultFilterOverrideFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IResultFilter, TController>(registration, AutofacFilterProvider.ResultFilterOverrideMetadataKey, order);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.IResultFilter"/> override for the specified controller action.
    /// 
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam><param name="registration">The registration.</param><param name="actionSelector">The action selector.</param><param name="order">The order in which the filter is applied.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsResultFilterOverrideFor<TController>(this IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, Expression<Action<TController>> actionSelector, int order = -1) where TController : IController
    {
      return RegistrationExtensions.AsFilterFor<IResultFilter, TController>(registration, AutofacFilterProvider.ResultFilterOverrideMetadataKey, actionSelector, order);
    }

    /// <summary>
    /// Cache instances in the web session. This implies external ownership (disposal is not
    ///             available.) All dependencies must also have external ownership.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// It is strongly recommended that components cached per-session do not take dependencies on
    ///             other services.
    /// 
    /// </remarks>
    /// <typeparam name="TLimit">Registration limit type.</typeparam><typeparam name="TSingleRegistrationStyle">Registration style.</typeparam><typeparam name="TActivatorData">Activator data type.</typeparam><param name="registration">The registration to configure.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "It is the responsibility of the registry to dispose of registrations.")]
    public static IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> CacheInSession<TLimit, TActivatorData, TSingleRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TSingleRegistrationStyle> registration) where TActivatorData : IConcreteActivatorData where TSingleRegistrationStyle : SingleRegistrationStyle
    {
      if (registration == null)
        throw new ArgumentNullException("registration");
      Service[] services = Enumerable.ToArray<Service>(registration.RegistrationData.Services);
      registration.RegistrationData.ClearServices();
      return Autofac.RegistrationExtensions.OnRegistered<TLimit, TActivatorData, TSingleRegistrationStyle>(registration.ExternallyOwned(), (Action<ComponentRegisteredEventArgs>) (e => e.ComponentRegistry.Register(RegistrationBuilder.CreateRegistration<object, SimpleActivatorData, SingleRegistrationStyle>(RegistrationBuilder.ForDelegate<object>((Func<IComponentContext, IEnumerable<Parameter>, object>) ((c, p) =>
      {
        HttpSessionState session = HttpContext.Current.Session;
        object syncRoot = session.SyncRoot;
        bool lockTaken = false;
        object obj;
        try
        {
          Monitor.Enter(syncRoot, ref lockTaken);
          obj = session[e.ComponentRegistration.Id.ToString()];
          if (obj == null)
          {
            obj = c.ResolveComponent(e.ComponentRegistration, p);
            session[e.ComponentRegistration.Id.ToString()] = obj;
          }
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(syncRoot);
        }
        return obj;
      })).As(services).InstancePerLifetimeScope().ExternallyOwned()))));
    }

    /// <summary>
    /// Inject an IActionInvoker into the controller's ActionInvoker property.
    /// 
    /// </summary>
    /// <typeparam name="TLimit">Limit type.</typeparam><typeparam name="TActivatorData">Activator data.</typeparam><typeparam name="TRegistrationStyle">Registration style.</typeparam><param name="registrationBuilder">The registration builder.</param>
    /// <returns>
    /// A registration builder.
    /// </returns>
    public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> InjectActionInvoker<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registrationBuilder)
    {
      return RegistrationExtensions.InjectActionInvoker<TLimit, TActivatorData, TRegistrationStyle>(registrationBuilder, (Service) new TypedService(typeof (IActionInvoker)));
    }

    /// <summary>
    /// Inject an IActionInvoker into the controller's ActionInvoker property.
    /// 
    /// </summary>
    /// <typeparam name="TLimit">Limit type.</typeparam><typeparam name="TActivatorData">Activator data.</typeparam><typeparam name="TRegistrationStyle">Registration style.</typeparam><param name="registrationBuilder">The registration builder.</param><param name="actionInvokerService">Service used to resolve the action invoker.</param>
    /// <returns>
    /// A registration builder.
    /// </returns>
    public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> InjectActionInvoker<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> registrationBuilder, Service actionInvokerService)
    {
      if (registrationBuilder == null)
        throw new ArgumentNullException("registrationBuilder");
      if (actionInvokerService == (Service) null)
        throw new ArgumentNullException("actionInvokerService");
      return registrationBuilder.OnActivating((Action<IActivatingEventArgs<TLimit>>) (e =>
      {
        Controller controller = (object) e.Instance as Controller;
        if (controller == null)
          return;
        controller.ActionInvoker = (IActionInvoker) ResolutionExtensions.ResolveService(e.Context, actionInvokerService);
      }));
    }

    /// <summary>
    /// Share one instance of the component within the context of a single
    ///             HTTP request.
    /// 
    /// </summary>
    /// <typeparam name="TLimit">Registration limit type.</typeparam><typeparam name="TStyle">Registration style.</typeparam><typeparam name="TActivatorData">Activator data type.</typeparam><param name="registration">The registration to configure.</param><param name="lifetimeScopeTags">Additional tags applied for matching lifetime scopes.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="registration"/> is <see langword="null"/>.
    ///             </exception>
    [Obsolete("Instead of using the MVC-specific InstancePerHttpRequest, please switch to the InstancePerRequest shared registration extension from Autofac core.")]
    public static IRegistrationBuilder<TLimit, TActivatorData, TStyle> InstancePerHttpRequest<TLimit, TActivatorData, TStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TStyle> registration, params object[] lifetimeScopeTags)
    {
      return Autofac.RegistrationExtensions.InstancePerRequest<TLimit, TActivatorData, TStyle>(registration, lifetimeScopeTags);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IOverrideFilter"/> for the specified controller.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static void OverrideActionFilterFor<TController>(this ContainerBuilder builder) where TController : IController
    {
      RegistrationExtensions.AsOverrideFor<IActionFilter, TController>(builder, AutofacFilterProvider.ActionFilterOverrideMetadataKey);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IOverrideFilter"/> for the specified controller action.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param><param name="actionSelector">The action selector.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static void OverrideActionFilterFor<TController>(this ContainerBuilder builder, Expression<Action<TController>> actionSelector) where TController : IController
    {
      RegistrationExtensions.AsOverrideFor<IActionFilter, TController>(builder, AutofacFilterProvider.ActionFilterOverrideMetadataKey, actionSelector);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IOverrideFilter"/> for the specified controller.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static void OverrideAuthenticationFilterFor<TController>(this ContainerBuilder builder) where TController : IController
    {
      RegistrationExtensions.AsOverrideFor<IAuthenticationFilter, TController>(builder, AutofacFilterProvider.AuthenticationFilterOverrideMetadataKey);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IOverrideFilter"/> for the specified controller action.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param><param name="actionSelector">The action selector.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static void OverrideAuthenticationFilterFor<TController>(this ContainerBuilder builder, Expression<Action<TController>> actionSelector) where TController : IController
    {
      RegistrationExtensions.AsOverrideFor<IAuthenticationFilter, TController>(builder, AutofacFilterProvider.AuthenticationFilterOverrideMetadataKey, actionSelector);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IOverrideFilter"/> for the specified controller.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static void OverrideAuthorizationFilterFor<TController>(this ContainerBuilder builder) where TController : IController
    {
      RegistrationExtensions.AsOverrideFor<IAuthorizationFilter, TController>(builder, AutofacFilterProvider.AuthorizationFilterOverrideMetadataKey);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IOverrideFilter"/> for the specified controller action.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param><param name="actionSelector">The action selector.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static void OverrideAuthorizationFilterFor<TController>(this ContainerBuilder builder, Expression<Action<TController>> actionSelector) where TController : IController
    {
      RegistrationExtensions.AsOverrideFor<IAuthorizationFilter, TController>(builder, AutofacFilterProvider.AuthorizationFilterOverrideMetadataKey, actionSelector);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IOverrideFilter"/> for the specified controller.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static void OverrideExceptionFilterFor<TController>(this ContainerBuilder builder) where TController : IController
    {
      RegistrationExtensions.AsOverrideFor<IExceptionFilter, TController>(builder, AutofacFilterProvider.ExceptionFilterOverrideMetadataKey);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IOverrideFilter"/> for the specified controller action.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param><param name="actionSelector">The action selector.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static void OverrideExceptionFilterFor<TController>(this ContainerBuilder builder, Expression<Action<TController>> actionSelector) where TController : IController
    {
      RegistrationExtensions.AsOverrideFor<IExceptionFilter, TController>(builder, AutofacFilterProvider.ExceptionFilterOverrideMetadataKey, actionSelector);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IOverrideFilter"/> for the specified controller.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static void OverrideResultFilterFor<TController>(this ContainerBuilder builder) where TController : IController
    {
      RegistrationExtensions.AsOverrideFor<IResultFilter, TController>(builder, AutofacFilterProvider.ResultFilterOverrideMetadataKey);
    }

    /// <summary>
    /// Sets the provided registration to act as an <see cref="T:System.Web.Mvc.Filters.IOverrideFilter"/> for the specified controller action.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param><param name="actionSelector">The action selector.</param>
    /// <returns>
    /// A registration builder allowing further configuration of the component.
    /// </returns>
    public static void OverrideResultFilterFor<TController>(this ContainerBuilder builder, Expression<Action<TController>> actionSelector) where TController : IController
    {
      RegistrationExtensions.AsOverrideFor<IResultFilter, TController>(builder, AutofacFilterProvider.ResultFilterOverrideMetadataKey, actionSelector);
    }

    /// <summary>
    /// Register types that implement IController in the provided assemblies.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param><param name="controllerAssemblies">Assemblies to scan for controllers.</param>
    /// <returns>
    /// Registration builder allowing the controller components to be customised.
    /// </returns>
    public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterControllers(this ContainerBuilder builder, params Assembly[] controllerAssemblies)
    {
      return Autofac.RegistrationExtensions.Where<object, ScanningActivatorData, DynamicRegistrationStyle>(Autofac.RegistrationExtensions.RegisterAssemblyTypes(builder, controllerAssemblies), (Func<Type, bool>) (t =>
      {
        if (typeof (IController).IsAssignableFrom(t))
          return t.Name.EndsWith("Controller", StringComparison.Ordinal);
        return false;
      }));
    }

    /// <summary>
    /// Registers the <see cref="T:Autofac.Integration.Mvc.AutofacFilterProvider"/>.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param>
    public static void RegisterFilterProvider(this ContainerBuilder builder)
    {
      if (builder == null)
        throw new ArgumentNullException("builder");
      foreach (IFilterProvider filterProvider in Enumerable.ToArray<FilterAttributeFilterProvider>(Enumerable.OfType<FilterAttributeFilterProvider>((IEnumerable) FilterProviders.Providers)))
        FilterProviders.Providers.Remove(filterProvider);
      Autofac.RegistrationExtensions.RegisterType<AutofacFilterProvider>(builder).As<IFilterProvider>().SingleInstance();
    }

    /// <summary>
    /// Registers the <see cref="T:Autofac.Integration.Mvc.AutofacModelBinderProvider"/>.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param>
    public static void RegisterModelBinderProvider(this ContainerBuilder builder)
    {
      if (builder == null)
        throw new ArgumentNullException("builder");
      Autofac.RegistrationExtensions.RegisterType<AutofacModelBinderProvider>(builder).As<IModelBinderProvider>().SingleInstance();
    }

    /// <summary>
    /// Register types that implement <see cref="T:System.Web.Mvc.IModelBinder"/> in the provided assemblies
    ///             and have a <see cref="T:Autofac.Integration.Mvc.ModelBinderTypeAttribute"/>.
    /// 
    /// </summary>
    /// <param name="builder">The container builder.</param><param name="modelBinderAssemblies">Assemblies to scan for model binders.</param>
    /// <returns>
    /// A registration builder.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="modelBinderAssemblies"/> is <see langword="null"/>.
    ///             </exception>
    /// <remarks>
    /// 
    /// <para>
    /// The declarative mechanism of registering model binders with Autofac
    ///             is through use of this method and the
    ///             <see cref="T:Autofac.Integration.Mvc.ModelBinderTypeAttribute"/>.
    ///             If you would like more imperative control over registration for your
    ///             model binders, see the <see cref="M:Autofac.Integration.Mvc.RegistrationExtensions.AsModelBinderForTypes``3(Autofac.Builder.IRegistrationBuilder{``0,``1,``2},System.Type[])"/>
    ///             method.
    /// 
    /// </para>
    /// 
    /// <para>
    /// The two mechanisms are mutually exclusive. If you register a model
    ///             binder using <see cref="M:Autofac.Integration.Mvc.RegistrationExtensions.AsModelBinderForTypes``3(Autofac.Builder.IRegistrationBuilder{``0,``1,``2},System.Type[])"/>
    ///             and register the same model binder with this method, the results
    ///             are not automatically merged together - standard dependency
    ///             registration/resolution rules will be used to manage the conflict.
    /// 
    /// </para>
    /// 
    /// <para>
    /// This method only registers types that implement <see cref="T:System.Web.Mvc.IModelBinder"/>
    ///             and are marked with the <see cref="T:Autofac.Integration.Mvc.ModelBinderTypeAttribute"/>.
    ///             The model binder must have the attribute because the
    ///             <see cref="T:Autofac.Integration.Mvc.AutofacModelBinderProvider"/> uses
    ///             the associated metadata - from the attribute(s) - to resolve the
    ///             binder based on model type. If there aren't any attributes, there
    ///             won't be any metadata, so the model binder will be technically
    ///             registered but will never actually be resolved.
    /// 
    /// </para>
    /// 
    /// <para>
    /// If your model is not marked with the attribute, or if you don't want
    ///             to use attributes, use the
    ///             <see cref="M:Autofac.Integration.Mvc.RegistrationExtensions.AsModelBinderForTypes``3(Autofac.Builder.IRegistrationBuilder{``0,``1,``2},System.Type[])"/>
    ///             extension instead.
    /// 
    /// </para>
    /// 
    /// </remarks>
    public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterModelBinders(this ContainerBuilder builder, params Assembly[] modelBinderAssemblies)
    {
      if (builder == null)
        throw new ArgumentNullException("builder");
      if (modelBinderAssemblies == null)
        throw new ArgumentNullException("modelBinderAssemblies");
      return Autofac.RegistrationExtensions.WithMetadata<object, ScanningActivatorData, DynamicRegistrationStyle>(Autofac.RegistrationExtensions.InstancePerRequest<object, ScanningActivatorData, DynamicRegistrationStyle>(Autofac.RegistrationExtensions.Where<object, ScanningActivatorData, DynamicRegistrationStyle>(Autofac.RegistrationExtensions.RegisterAssemblyTypes(builder, modelBinderAssemblies), (Func<Type, bool>) (type =>
      {
        if (typeof (IModelBinder).IsAssignableFrom(type))
          return (uint) type.GetCustomAttributes(typeof (ModelBinderTypeAttribute), true).Length > 0U;
        return false;
      })).As<IModelBinder>()), AutofacModelBinderProvider.MetadataKey, (Func<Type, object>) (type =>
      {
        IEnumerable<ModelBinderTypeAttribute> source = Enumerable.Cast<ModelBinderTypeAttribute>((IEnumerable) type.GetCustomAttributes(typeof (ModelBinderTypeAttribute), true));
        Func<ModelBinderTypeAttribute, IEnumerable<Type>> func = (Func<ModelBinderTypeAttribute, IEnumerable<Type>>) (attribute => attribute.TargetTypes);
        Func<ModelBinderTypeAttribute, IEnumerable<Type>> collectionSelector = null;
        return (object) Enumerable.ToList<Type>(Enumerable.SelectMany<ModelBinderTypeAttribute, Type, Type>(source, collectionSelector, (Func<ModelBinderTypeAttribute, Type, Type>) ((attribute, targetType) => targetType)));
      }));
    }

    private static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsFilterFor<TFilter, TController>(IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, string metadataKey, int order) where TController : IController
    {
      if (registration == null)
        throw new ArgumentNullException("registration");
      Type limitType = registration.ActivatorData.Activator.LimitType;
      if (!TypeExtensions.IsAssignableTo<TFilter>(limitType))
      {
        CultureInfo currentCulture = CultureInfo.CurrentCulture;
        string assignableToFilterType = RegistrationExtensionsResources.MustBeAssignableToFilterType;
        object[] objArray = new object[2];
        int index1 = 0;
        string fullName1 = limitType.FullName;
        objArray[index1] = (object) fullName1;
        int index2 = 1;
        string fullName2 = typeof (TFilter).FullName;
        objArray[index2] = (object) fullName2;
        throw new ArgumentException(string.Format((IFormatProvider) currentCulture, assignableToFilterType, objArray), "registration");
      }
      FilterMetadata filterMetadata1 = new FilterMetadata();
      Type type = typeof (TController);
      filterMetadata1.ControllerType = type;
      int num1 = 20;
      filterMetadata1.FilterScope = (FilterScope) num1;
      // ISSUE: variable of the null type
 
      filterMetadata1.MethodInfo = null;
      int num2 = order;
      filterMetadata1.Order = num2;
      FilterMetadata filterMetadata2 = filterMetadata1;
      return registration.As<TFilter>().WithMetadata(metadataKey, (object) filterMetadata2);
    }

    private static IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> AsFilterFor<TFilter, TController>(IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> registration, string metadataKey, Expression<Action<TController>> actionSelector, int order) where TController : IController
    {
      if (registration == null)
        throw new ArgumentNullException("registration");
      if (actionSelector == null)
        throw new ArgumentNullException("actionSelector");
      Type limitType = registration.ActivatorData.Activator.LimitType;
      if (!TypeExtensions.IsAssignableTo<TFilter>(limitType))
      {
        CultureInfo currentCulture = CultureInfo.CurrentCulture;
        string assignableToFilterType = RegistrationExtensionsResources.MustBeAssignableToFilterType;
        object[] objArray = new object[2];
        int index1 = 0;
        string fullName1 = limitType.FullName;
        objArray[index1] = (object) fullName1;
        int index2 = 1;
        string fullName2 = typeof (TFilter).FullName;
        objArray[index2] = (object) fullName2;
        throw new ArgumentException(string.Format((IFormatProvider) currentCulture, assignableToFilterType, objArray), "registration");
      }
      FilterMetadata filterMetadata1 = new FilterMetadata();
      Type type = typeof (TController);
      filterMetadata1.ControllerType = type;
      int num1 = 30;
      filterMetadata1.FilterScope = (FilterScope) num1;
      MethodInfo methodInfo = RegistrationExtensions.GetMethodInfo((LambdaExpression) actionSelector);
      filterMetadata1.MethodInfo = methodInfo;
      int num2 = order;
      filterMetadata1.Order = num2;
      FilterMetadata filterMetadata2 = filterMetadata1;
      return registration.As<TFilter>().WithMetadata(metadataKey, (object) filterMetadata2);
    }

    private static void AsOverrideFor<TFilter, TController>(ContainerBuilder builder, string metadataKey)
    {
      FilterMetadata filterMetadata1 = new FilterMetadata();
      Type type = typeof (TController);
      filterMetadata1.ControllerType = type;
      int num = 20;
      filterMetadata1.FilterScope = (FilterScope) num;
      // ISSUE: variable of the null type
     
      filterMetadata1.MethodInfo = null;
      FilterMetadata filterMetadata2 = filterMetadata1;
      Autofac.RegistrationExtensions.RegisterInstance<AutofacOverrideFilter>(builder, new AutofacOverrideFilter(typeof (TFilter))).As<IOverrideFilter>().WithMetadata(metadataKey, (object) filterMetadata2);
    }

    private static void AsOverrideFor<TFilter, TController>(ContainerBuilder builder, string metadataKey, Expression<Action<TController>> actionSelector)
    {
      if (actionSelector == null)
        throw new ArgumentNullException("actionSelector");
      FilterMetadata filterMetadata1 = new FilterMetadata();
      Type type = typeof (TController);
      filterMetadata1.ControllerType = type;
      int num = 30;
      filterMetadata1.FilterScope = (FilterScope) num;
      MethodInfo methodInfo = RegistrationExtensions.GetMethodInfo((LambdaExpression) actionSelector);
      filterMetadata1.MethodInfo = methodInfo;
      FilterMetadata filterMetadata2 = filterMetadata1;
      Autofac.RegistrationExtensions.RegisterInstance<AutofacOverrideFilter>(builder, new AutofacOverrideFilter(typeof (TFilter))).As<IOverrideFilter>().WithMetadata(metadataKey, (object) filterMetadata2);
    }

    private static MethodInfo GetMethodInfo(LambdaExpression expression)
    {
      MethodCallExpression methodCallExpression = expression.Body as MethodCallExpression;
      if (methodCallExpression == null)
        throw new ArgumentException(RegistrationExtensionsResources.InvalidActionExpress);
      return methodCallExpression.Method;
    }
  }
}
