﻿// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.RequestLifetimeScopeProviderResources
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// A strongly-typed resource class, for looking up localized strings, etc.
  /// 
  /// </summary>
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class RequestLifetimeScopeProviderResources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    /// <summary>
    /// Returns the cached ResourceManager instance used by this class.
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (RequestLifetimeScopeProviderResources.resourceMan == null)
          RequestLifetimeScopeProviderResources.resourceMan = new ResourceManager("Autofac.Integration.Mvc.RequestLifetimeScopeProviderResources", typeof (RequestLifetimeScopeProviderResources).Assembly);
        return RequestLifetimeScopeProviderResources.resourceMan;
      }
    }

    /// <summary>
    /// Overrides the current thread's CurrentUICulture property for all
    ///               resource lookups using this strongly typed resource class.
    /// 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return RequestLifetimeScopeProviderResources.resourceCulture;
      }
      set
      {
        RequestLifetimeScopeProviderResources.resourceCulture = value;
      }
    }

    /// <summary>
    /// Looks up a localized string similar to The request lifetime scope cannot be created because the HttpContext is not available..
    /// 
    /// </summary>
    internal static string HttpContextNotAvailable
    {
      get
      {
        return RequestLifetimeScopeProviderResources.ResourceManager.GetString("HttpContextNotAvailable", RequestLifetimeScopeProviderResources.resourceCulture);
      }
    }

    /// <summary>
    /// Looks up a localized string similar to The 'GetLifetimeScopeCore' method implementation on '{0}' returned a null ILifetimeScope instance. When overridden this method must return a valid ILifetimeScope instance for the current HTTP request..
    /// 
    /// </summary>
    internal static string NullLifetimeScopeReturned
    {
      get
      {
        return RequestLifetimeScopeProviderResources.ResourceManager.GetString("NullLifetimeScopeReturned", RequestLifetimeScopeProviderResources.resourceCulture);
      }
    }

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    internal RequestLifetimeScopeProviderResources()
    {
    }
  }
}
