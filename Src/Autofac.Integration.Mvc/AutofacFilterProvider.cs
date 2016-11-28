// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.AutofacFilterProvider
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using Autofac;
using Autofac.Features.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Async;
using System.Web.Mvc.Filters;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// Defines a filter provider for filter attributes that performs property injection.
  /// 
  /// </summary>
  public class AutofacFilterProvider : FilterAttributeFilterProvider
  {
    internal static string ActionFilterMetadataKey = "AutofacMvcActionFilter";
    internal static string ActionFilterOverrideMetadataKey = "AutofacMvcActionFilterOverride";
    internal static string AuthenticationFilterMetadataKey = "AutofacMvcAuthenticationFilter";
    internal static string AuthenticationFilterOverrideMetadataKey = "AutofacMvcAuthenticationFilterOverride";
    internal static string AuthorizationFilterMetadataKey = "AutofacMvcAuthorizationFilter";
    internal static string AuthorizationFilterOverrideMetadataKey = "AutofacMvcAuthorizationFilterOverride";
    internal static string ExceptionFilterMetadataKey = "AutofacMvcExceptionFilter";
    internal static string ExceptionFilterOverrideMetadataKey = "AutofacMvcExceptionFilterOverride";
    internal static string ResultFilterMetadataKey = "AutofacMvcResultFilter";
    internal static string ResultFilterOverrideMetadataKey = "AutofacMvcResultFilterOverride";

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Autofac.Integration.Mvc.AutofacFilterProvider"/> class.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// The <c>false</c> constructor parameter passed to base here ensures that attribute instances are not cached.
    /// 
    /// </remarks>
    public AutofacFilterProvider()
      : base(false)
    {
    }

    /// <summary>
    /// Aggregates the filters from all of the filter providers into one collection.
    /// 
    /// </summary>
    /// <param name="controllerContext">The controller context.</param><param name="actionDescriptor">The action descriptor.</param>
    /// <returns>
    /// The collection filters from all of the filter providers with properties injected.
    /// 
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">Thrown if <paramref name="controllerContext"/> is <see langword="null"/>.
    ///             </exception>
    public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
    {
      if (controllerContext == null)
        throw new ArgumentNullException("controllerContext");
      List<Filter> list = Enumerable.ToList<Filter>(base.GetFilters(controllerContext, actionDescriptor));
      ILifetimeScope requestLifetimeScope = AutofacDependencyResolver.Current.RequestLifetimeScope;
      if (requestLifetimeScope != null)
      {
        foreach (Filter filter in list)
          ResolutionExtensions.InjectProperties<object>((IComponentContext) requestLifetimeScope, filter.Instance);
        Type type = controllerContext.Controller.GetType();
        AutofacFilterProvider.FilterContext filterContext = new AutofacFilterProvider.FilterContext();
        filterContext.ActionDescriptor = actionDescriptor;
        filterContext.LifetimeScope = requestLifetimeScope;
        filterContext.ControllerType = type;
        filterContext.Filters = list;
        AutofacFilterProvider.ResolveControllerScopedFilters(filterContext);
        AutofacFilterProvider.ResolveActionScopedFilters<ReflectedActionDescriptor>(filterContext, (Func<ReflectedActionDescriptor, MethodInfo>) (d => d.MethodInfo));
        AutofacFilterProvider.ResolveActionScopedFilters<ReflectedAsyncActionDescriptor>(filterContext, (Func<ReflectedAsyncActionDescriptor, MethodInfo>) (d => d.AsyncMethodInfo));
        AutofacFilterProvider.ResolveActionScopedFilters<TaskAsyncActionDescriptor>(filterContext, (Func<TaskAsyncActionDescriptor, MethodInfo>) (d => d.TaskMethodInfo));
        AutofacFilterProvider.ResolveControllerScopedFilterOverrides(filterContext);
        AutofacFilterProvider.ResolveActionScopedFilterOverrides<ReflectedActionDescriptor>(filterContext, (Func<ReflectedActionDescriptor, MethodInfo>) (d => d.MethodInfo));
        AutofacFilterProvider.ResolveActionScopedFilterOverrides<ReflectedAsyncActionDescriptor>(filterContext, (Func<ReflectedAsyncActionDescriptor, MethodInfo>) (d => d.AsyncMethodInfo));
        AutofacFilterProvider.ResolveActionScopedFilterOverrides<TaskAsyncActionDescriptor>(filterContext, (Func<TaskAsyncActionDescriptor, MethodInfo>) (d => d.TaskMethodInfo));
        AutofacFilterProvider.ResolveControllerScopedEmptyOverrideFilters(filterContext);
        AutofacFilterProvider.ResolveActionScopedEmptyOverrideFilters<ReflectedActionDescriptor>(filterContext, (Func<ReflectedActionDescriptor, MethodInfo>) (d => d.MethodInfo));
        AutofacFilterProvider.ResolveActionScopedEmptyOverrideFilters<ReflectedAsyncActionDescriptor>(filterContext, (Func<ReflectedAsyncActionDescriptor, MethodInfo>) (d => d.AsyncMethodInfo));
        AutofacFilterProvider.ResolveActionScopedEmptyOverrideFilters<TaskAsyncActionDescriptor>(filterContext, (Func<TaskAsyncActionDescriptor, MethodInfo>) (d => d.TaskMethodInfo));
      }
      return (IEnumerable<Filter>) list.ToArray();
    }

    private static bool FilterMatchesAction(AutofacFilterProvider.FilterContext filterContext, MethodInfo methodInfo, FilterMetadata metadata)
    {
      if (metadata.ControllerType != (Type) null && metadata.ControllerType.IsAssignableFrom(filterContext.ControllerType) && metadata.FilterScope == FilterScope.Action)
        return metadata.MethodInfo.GetBaseDefinition() == methodInfo.GetBaseDefinition();
      return false;
    }

    private static bool FilterMatchesController(AutofacFilterProvider.FilterContext filterContext, FilterMetadata metadata)
    {
      if (metadata.ControllerType != (Type) null && metadata.ControllerType.IsAssignableFrom(filterContext.ControllerType) && metadata.FilterScope == FilterScope.Controller)
        return metadata.MethodInfo == (MethodInfo) null;
      return false;
    }

    private static void ResolveActionScopedEmptyOverrideFilters<T>(AutofacFilterProvider.FilterContext filterContext, Func<T, MethodInfo> methodSelector) where T : ActionDescriptor
    {
      T obj = filterContext.ActionDescriptor as T;
      if ((object) obj == null)
        return;
      MethodInfo methodInfo = methodSelector(obj);
      AutofacFilterProvider.ResolveActionScopedOverrideFilter(filterContext, methodInfo, AutofacFilterProvider.ActionFilterOverrideMetadataKey);
      AutofacFilterProvider.ResolveActionScopedOverrideFilter(filterContext, methodInfo, AutofacFilterProvider.AuthenticationFilterOverrideMetadataKey);
      AutofacFilterProvider.ResolveActionScopedOverrideFilter(filterContext, methodInfo, AutofacFilterProvider.AuthorizationFilterOverrideMetadataKey);
      AutofacFilterProvider.ResolveActionScopedOverrideFilter(filterContext, methodInfo, AutofacFilterProvider.ExceptionFilterOverrideMetadataKey);
      AutofacFilterProvider.ResolveActionScopedOverrideFilter(filterContext, methodInfo, AutofacFilterProvider.ResultFilterOverrideMetadataKey);
    }

    private static void ResolveActionScopedFilter<TFilter>(AutofacFilterProvider.FilterContext filterContext, MethodInfo methodInfo, string metadataKey, Func<TFilter, TFilter> wrapperFactory = null) where TFilter : class
    {
      foreach (Meta<Lazy<TFilter>> meta in Enumerable.Where<Meta<Lazy<TFilter>>>(ResolutionExtensions.Resolve<IEnumerable<Meta<Lazy<TFilter>>>>((IComponentContext) filterContext.LifetimeScope), (Func<Meta<Lazy<TFilter>>, bool>) (a =>
      {
        if (a.Metadata.ContainsKey(metadataKey))
          return a.Metadata[metadataKey] is FilterMetadata;
        return false;
      })))
      {
        FilterMetadata metadata = (FilterMetadata) meta.Metadata[metadataKey];
        if (AutofacFilterProvider.FilterMatchesAction(filterContext, methodInfo, metadata))
        {
          TFilter filter1 = meta.Value.Value;
          if (wrapperFactory != null)
            filter1 = wrapperFactory(filter1);
          Filter filter2 = new Filter((object) filter1, FilterScope.Action, new int?(metadata.Order));
          filterContext.Filters.Add(filter2);
        }
      }
    }

    private static void ResolveActionScopedFilterOverrides<T>(AutofacFilterProvider.FilterContext filterContext, Func<T, MethodInfo> methodSelector) where T : ActionDescriptor
    {
      T obj = filterContext.ActionDescriptor as T;
      if ((object) obj == null)
        return;
      MethodInfo methodInfo = methodSelector(obj);
      AutofacFilterProvider.ResolveActionScopedFilter<IActionFilter>(filterContext, methodInfo, AutofacFilterProvider.ActionFilterOverrideMetadataKey, (Func<IActionFilter, IActionFilter>) (filter => (IActionFilter) new ActionFilterOverride(filter)));
      AutofacFilterProvider.ResolveActionScopedFilter<IAuthenticationFilter>(filterContext, methodInfo, AutofacFilterProvider.AuthenticationFilterOverrideMetadataKey, (Func<IAuthenticationFilter, IAuthenticationFilter>) (filter => (IAuthenticationFilter) new AuthenticationFilterOverride(filter)));
      AutofacFilterProvider.ResolveActionScopedFilter<IAuthorizationFilter>(filterContext, methodInfo, AutofacFilterProvider.AuthorizationFilterOverrideMetadataKey, (Func<IAuthorizationFilter, IAuthorizationFilter>) (filter => (IAuthorizationFilter) new AuthorizationFilterOverride(filter)));
      AutofacFilterProvider.ResolveActionScopedFilter<IExceptionFilter>(filterContext, methodInfo, AutofacFilterProvider.ExceptionFilterOverrideMetadataKey, (Func<IExceptionFilter, IExceptionFilter>) (filter => (IExceptionFilter) new ExceptionFilterOverride(filter)));
      AutofacFilterProvider.ResolveActionScopedFilter<IResultFilter>(filterContext, methodInfo, AutofacFilterProvider.ResultFilterOverrideMetadataKey, (Func<IResultFilter, IResultFilter>) (filter => (IResultFilter) new ResultFilterOverride(filter)));
    }

    private static void ResolveActionScopedFilters<T>(AutofacFilterProvider.FilterContext filterContext, Func<T, MethodInfo> methodSelector) where T : ActionDescriptor
    {
      T obj = filterContext.ActionDescriptor as T;
      if ((object) obj == null)
        return;
      MethodInfo methodInfo = methodSelector(obj);
      AutofacFilterProvider.ResolveActionScopedFilter<IActionFilter>(filterContext, methodInfo, AutofacFilterProvider.ActionFilterMetadataKey, (Func<IActionFilter, IActionFilter>) null);
      AutofacFilterProvider.ResolveActionScopedFilter<IAuthenticationFilter>(filterContext, methodInfo, AutofacFilterProvider.AuthenticationFilterMetadataKey, (Func<IAuthenticationFilter, IAuthenticationFilter>) null);
      AutofacFilterProvider.ResolveActionScopedFilter<IAuthorizationFilter>(filterContext, methodInfo, AutofacFilterProvider.AuthorizationFilterMetadataKey, (Func<IAuthorizationFilter, IAuthorizationFilter>) null);
      AutofacFilterProvider.ResolveActionScopedFilter<IExceptionFilter>(filterContext, methodInfo, AutofacFilterProvider.ExceptionFilterMetadataKey, (Func<IExceptionFilter, IExceptionFilter>) null);
      AutofacFilterProvider.ResolveActionScopedFilter<IResultFilter>(filterContext, methodInfo, AutofacFilterProvider.ResultFilterMetadataKey, (Func<IResultFilter, IResultFilter>) null);
    }

    private static void ResolveActionScopedOverrideFilter(AutofacFilterProvider.FilterContext filterContext, MethodInfo methodInfo, string metadataKey)
    {
      foreach (Meta<IOverrideFilter> meta in Enumerable.Where<Meta<IOverrideFilter>>(ResolutionExtensions.Resolve<IEnumerable<Meta<IOverrideFilter>>>((IComponentContext) filterContext.LifetimeScope), (Func<Meta<IOverrideFilter>, bool>) (a =>
      {
        if (a.Metadata.ContainsKey(metadataKey))
          return a.Metadata[metadataKey] is FilterMetadata;
        return false;
      })))
      {
        FilterMetadata metadata = (FilterMetadata) meta.Metadata[metadataKey];
        if (AutofacFilterProvider.FilterMatchesAction(filterContext, methodInfo, metadata))
        {
          Filter filter = new Filter((object) meta.Value, FilterScope.Action, new int?(metadata.Order));
          filterContext.Filters.Add(filter);
        }
      }
    }

    private static void ResolveControllerScopedEmptyOverrideFilters(AutofacFilterProvider.FilterContext filterContext)
    {
      AutofacFilterProvider.ResolveControllerScopedOverrideFilter(filterContext, AutofacFilterProvider.ActionFilterOverrideMetadataKey);
      AutofacFilterProvider.ResolveControllerScopedOverrideFilter(filterContext, AutofacFilterProvider.AuthenticationFilterOverrideMetadataKey);
      AutofacFilterProvider.ResolveControllerScopedOverrideFilter(filterContext, AutofacFilterProvider.AuthorizationFilterOverrideMetadataKey);
      AutofacFilterProvider.ResolveControllerScopedOverrideFilter(filterContext, AutofacFilterProvider.ExceptionFilterOverrideMetadataKey);
      AutofacFilterProvider.ResolveControllerScopedOverrideFilter(filterContext, AutofacFilterProvider.ResultFilterOverrideMetadataKey);
    }

    private static void ResolveControllerScopedFilter<TFilter>(AutofacFilterProvider.FilterContext filterContext, string metadataKey, Func<TFilter, TFilter> wrapperFactory = null) where TFilter : class
    {
      foreach (Meta<Lazy<TFilter>> meta in Enumerable.Where<Meta<Lazy<TFilter>>>(ResolutionExtensions.Resolve<IEnumerable<Meta<Lazy<TFilter>>>>((IComponentContext) filterContext.LifetimeScope), (Func<Meta<Lazy<TFilter>>, bool>) (a =>
      {
        if (a.Metadata.ContainsKey(metadataKey))
          return a.Metadata[metadataKey] is FilterMetadata;
        return false;
      })))
      {
        FilterMetadata metadata = (FilterMetadata) meta.Metadata[metadataKey];
        if (AutofacFilterProvider.FilterMatchesController(filterContext, metadata))
        {
          TFilter filter1 = meta.Value.Value;
          if (wrapperFactory != null)
            filter1 = wrapperFactory(filter1);
          Filter filter2 = new Filter((object) filter1, FilterScope.Controller, new int?(metadata.Order));
          filterContext.Filters.Add(filter2);
        }
      }
    }

    private static void ResolveControllerScopedFilterOverrides(AutofacFilterProvider.FilterContext filterContext)
    {
      AutofacFilterProvider.ResolveControllerScopedFilter<IActionFilter>(filterContext, AutofacFilterProvider.ActionFilterOverrideMetadataKey, (Func<IActionFilter, IActionFilter>) (filter => (IActionFilter) new ActionFilterOverride(filter)));
      AutofacFilterProvider.ResolveControllerScopedFilter<IAuthenticationFilter>(filterContext, AutofacFilterProvider.AuthenticationFilterOverrideMetadataKey, (Func<IAuthenticationFilter, IAuthenticationFilter>) (filter => (IAuthenticationFilter) new AuthenticationFilterOverride(filter)));
      AutofacFilterProvider.ResolveControllerScopedFilter<IAuthorizationFilter>(filterContext, AutofacFilterProvider.AuthorizationFilterOverrideMetadataKey, (Func<IAuthorizationFilter, IAuthorizationFilter>) (filter => (IAuthorizationFilter) new AuthorizationFilterOverride(filter)));
      AutofacFilterProvider.ResolveControllerScopedFilter<IExceptionFilter>(filterContext, AutofacFilterProvider.ExceptionFilterOverrideMetadataKey, (Func<IExceptionFilter, IExceptionFilter>) (filter => (IExceptionFilter) new ExceptionFilterOverride(filter)));
      AutofacFilterProvider.ResolveControllerScopedFilter<IResultFilter>(filterContext, AutofacFilterProvider.ResultFilterOverrideMetadataKey, (Func<IResultFilter, IResultFilter>) (filter => (IResultFilter) new ResultFilterOverride(filter)));
    }

    private static void ResolveControllerScopedFilters(AutofacFilterProvider.FilterContext filterContext)
    {
      AutofacFilterProvider.ResolveControllerScopedFilter<IActionFilter>(filterContext, AutofacFilterProvider.ActionFilterMetadataKey, (Func<IActionFilter, IActionFilter>) null);
      AutofacFilterProvider.ResolveControllerScopedFilter<IAuthenticationFilter>(filterContext, AutofacFilterProvider.AuthenticationFilterMetadataKey, (Func<IAuthenticationFilter, IAuthenticationFilter>) null);
      AutofacFilterProvider.ResolveControllerScopedFilter<IAuthorizationFilter>(filterContext, AutofacFilterProvider.AuthorizationFilterMetadataKey, (Func<IAuthorizationFilter, IAuthorizationFilter>) null);
      AutofacFilterProvider.ResolveControllerScopedFilter<IExceptionFilter>(filterContext, AutofacFilterProvider.ExceptionFilterMetadataKey, (Func<IExceptionFilter, IExceptionFilter>) null);
      AutofacFilterProvider.ResolveControllerScopedFilter<IResultFilter>(filterContext, AutofacFilterProvider.ResultFilterMetadataKey, (Func<IResultFilter, IResultFilter>) null);
    }

    private static void ResolveControllerScopedOverrideFilter(AutofacFilterProvider.FilterContext filterContext, string metadataKey)
    {
      foreach (Meta<IOverrideFilter> meta in Enumerable.Where<Meta<IOverrideFilter>>(ResolutionExtensions.Resolve<IEnumerable<Meta<IOverrideFilter>>>((IComponentContext) filterContext.LifetimeScope), (Func<Meta<IOverrideFilter>, bool>) (a =>
      {
        if (a.Metadata.ContainsKey(metadataKey))
          return a.Metadata[metadataKey] is FilterMetadata;
        return false;
      })))
      {
        FilterMetadata metadata = (FilterMetadata) meta.Metadata[metadataKey];
        if (AutofacFilterProvider.FilterMatchesController(filterContext, metadata))
        {
          Filter filter = new Filter((object) meta.Value, FilterScope.Controller, new int?(metadata.Order));
          filterContext.Filters.Add(filter);
        }
      }
    }

    private class FilterContext
    {
      public ActionDescriptor ActionDescriptor { get; set; }

      public Type ControllerType { get; set; }

      public List<Filter> Filters { get; set; }

      public ILifetimeScope LifetimeScope { get; set; }
    }
  }
}
