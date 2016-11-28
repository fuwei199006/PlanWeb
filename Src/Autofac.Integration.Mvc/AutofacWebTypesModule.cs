// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.AutofacWebTypesModule
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using Autofac;
using Autofac.Builder;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// Dependency injection module that registers abstractions for common
  ///             web application properties.
  /// 
  /// </summary>
  /// 
  /// <remarks>
  /// 
  /// <para>
  /// This <see cref="T:Autofac.Module"/> is primarily used during
  ///             application startup (in <c>Global.asax</c>) to register
  ///             mappings from commonly referenced contextual application properties
  ///             to their corresponding abstraction.
  /// 
  /// </para>
  /// 
  /// <para>
  /// The following mappings are made:
  /// 
  /// </para>
  /// 
  /// <list type="table">
  /// 
  /// <listheader>
  /// <term>Common Construct</term><description>Abstraction</description>
  /// </listheader>
  /// 
  /// <item>
  /// <term><c>HttpContext.Current</c></term><description><see cref="T:System.Web.HttpContextBase"/></description>
  /// </item>
  /// 
  /// <item>
  /// <term><c>HttpContext.Current.Application</c></term><description><see cref="T:System.Web.HttpApplicationStateBase"/></description>
  /// </item>
  /// 
  /// <item>
  /// <term><c>HttpContext.Current.Request</c></term><description><see cref="T:System.Web.HttpRequestBase"/></description>
  /// </item>
  /// 
  /// <item>
  /// <term><c>HttpContext.Current.Request.Browser</c></term><description><see cref="T:System.Web.HttpBrowserCapabilitiesBase"/></description>
  /// </item>
  /// 
  /// <item>
  /// <term><c>HttpContext.Current.Request.Files</c></term><description><see cref="T:System.Web.HttpFileCollectionBase"/></description>
  /// </item>
  /// 
  /// <item>
  /// <term><c>HttpContext.Current.Request.RequestContext</c></term><description><see cref="T:System.Web.Routing.RequestContext"/></description>
  /// </item>
  /// 
  /// <item>
  /// <term><c>HttpContext.Current.Response</c></term><description><see cref="T:System.Web.HttpResponseBase"/></description>
  /// </item>
  /// 
  /// <item>
  /// <term><c>HttpContext.Current.Response.Cache</c></term><description><see cref="T:System.Web.HttpCachePolicyBase"/></description>
  /// </item>
  /// 
  /// <item>
  /// <term><c>HttpContext.Current.Server</c></term><description><see cref="T:System.Web.HttpServerUtilityBase"/></description>
  /// </item>
  /// 
  /// <item>
  /// <term><c>HttpContext.Current.Session</c></term><description><see cref="T:System.Web.HttpSessionStateBase"/></description>
  /// </item>
  /// 
  /// <item>
  /// <term><c>HostingEnvironment.VirtualPathProvider</c></term><description><see cref="T:System.Web.Hosting.VirtualPathProvider"/></description>
  /// </item>
  /// 
  /// </list>
  /// 
  /// <para>
  /// In addition, the <see cref="T:System.Web.Mvc.UrlHelper"/> type is registered
  ///             for construction based on the current <see cref="T:System.Web.Routing.RequestContext"/>.
  /// 
  /// </para>
  /// 
  /// <para>
  /// The lifetime for each of these items is one web request.
  /// 
  /// </para>
  /// 
  /// </remarks>
  public class AutofacWebTypesModule : Module
  {
    /// <summary>
    /// Registers web abstractions with dependency injection.
    /// 
    /// </summary>
    /// <param name="builder">The <see cref="T:Autofac.ContainerBuilder"/> in which registration
    ///             should take place.
    ///             </param>
    /// <remarks>
    /// 
    /// <para>
    /// This method registers mappings between common current context-related
    ///             web constructs and their associated abstract counterparts. See
    ///             <see cref="T:Autofac.Integration.Mvc.AutofacWebTypesModule"/> for the complete
    ///             list of mappings that get registered.
    /// 
    /// </para>
    /// 
    /// </remarks>
    [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "A lot of types get registered, but there isn't much complexity.")]
    [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "The complexity is in the registration lambdas. They're not actually hard to maintain.")]
    protected override void Load(ContainerBuilder builder)
    {
      Autofac.RegistrationExtensions.InstancePerRequest<HttpContextWrapper, SimpleActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.Register<HttpContextWrapper>(builder, (Func<IComponentContext, HttpContextWrapper>) (c => new HttpContextWrapper(HttpContext.Current))).As<HttpContextBase>());
      Autofac.RegistrationExtensions.InstancePerRequest<HttpRequestBase, SimpleActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.Register<HttpRequestBase>(builder, (Func<IComponentContext, HttpRequestBase>) (c => ResolutionExtensions.Resolve<HttpContextBase>(c).Request)).As<HttpRequestBase>());
      Autofac.RegistrationExtensions.InstancePerRequest<HttpResponseBase, SimpleActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.Register<HttpResponseBase>(builder, (Func<IComponentContext, HttpResponseBase>) (c => ResolutionExtensions.Resolve<HttpContextBase>(c).Response)).As<HttpResponseBase>());
      Autofac.RegistrationExtensions.InstancePerRequest<HttpServerUtilityBase, SimpleActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.Register<HttpServerUtilityBase>(builder, (Func<IComponentContext, HttpServerUtilityBase>) (c => ResolutionExtensions.Resolve<HttpContextBase>(c).Server)).As<HttpServerUtilityBase>());
      Autofac.RegistrationExtensions.InstancePerRequest<HttpSessionStateBase, SimpleActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.Register<HttpSessionStateBase>(builder, (Func<IComponentContext, HttpSessionStateBase>) (c => ResolutionExtensions.Resolve<HttpContextBase>(c).Session)).As<HttpSessionStateBase>());
      Autofac.RegistrationExtensions.InstancePerRequest<HttpApplicationStateBase, SimpleActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.Register<HttpApplicationStateBase>(builder, (Func<IComponentContext, HttpApplicationStateBase>) (c => ResolutionExtensions.Resolve<HttpContextBase>(c).Application)).As<HttpApplicationStateBase>());
      Autofac.RegistrationExtensions.InstancePerRequest<HttpBrowserCapabilitiesBase, SimpleActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.Register<HttpBrowserCapabilitiesBase>(builder, (Func<IComponentContext, HttpBrowserCapabilitiesBase>) (c => ResolutionExtensions.Resolve<HttpRequestBase>(c).Browser)).As<HttpBrowserCapabilitiesBase>());
      Autofac.RegistrationExtensions.InstancePerRequest<HttpFileCollectionBase, SimpleActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.Register<HttpFileCollectionBase>(builder, (Func<IComponentContext, HttpFileCollectionBase>) (c => ResolutionExtensions.Resolve<HttpRequestBase>(c).Files)).As<HttpFileCollectionBase>());
      Autofac.RegistrationExtensions.InstancePerRequest<RequestContext, SimpleActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.Register<RequestContext>(builder, (Func<IComponentContext, RequestContext>) (c => ResolutionExtensions.Resolve<HttpRequestBase>(c).RequestContext)).As<RequestContext>());
      Autofac.RegistrationExtensions.InstancePerRequest<HttpCachePolicyBase, SimpleActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.Register<HttpCachePolicyBase>(builder, (Func<IComponentContext, HttpCachePolicyBase>) (c => ResolutionExtensions.Resolve<HttpResponseBase>(c).Cache)).As<HttpCachePolicyBase>());
      Autofac.RegistrationExtensions.InstancePerRequest<VirtualPathProvider, SimpleActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.Register<VirtualPathProvider>(builder, (Func<IComponentContext, VirtualPathProvider>) (c => HostingEnvironment.VirtualPathProvider)).As<VirtualPathProvider>());
      Autofac.RegistrationExtensions.InstancePerRequest<UrlHelper, SimpleActivatorData, SingleRegistrationStyle>(Autofac.RegistrationExtensions.Register<UrlHelper>(builder, (Func<IComponentContext, UrlHelper>) (c => new UrlHelper(ResolutionExtensions.Resolve<RequestContext>(c)))).As<UrlHelper>());
    }
  }
}
