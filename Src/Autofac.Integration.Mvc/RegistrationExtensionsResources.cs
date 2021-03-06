﻿// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.RegistrationExtensionsResources
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
  internal class RegistrationExtensionsResources
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
        if (RegistrationExtensionsResources.resourceMan == null)
          RegistrationExtensionsResources.resourceMan = new ResourceManager("Autofac.Integration.Mvc.RegistrationExtensionsResources", typeof (RegistrationExtensionsResources).Assembly);
        return RegistrationExtensionsResources.resourceMan;
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
        return RegistrationExtensionsResources.resourceCulture;
      }
      set
      {
        RegistrationExtensionsResources.resourceCulture = value;
      }
    }

    /// <summary>
    /// Looks up a localized string similar to The action method Expression is invalid. It should consist only of a Method call to a controller action method..
    /// 
    /// </summary>
    internal static string InvalidActionExpress
    {
      get
      {
        return RegistrationExtensionsResources.ResourceManager.GetString("InvalidActionExpress", RegistrationExtensionsResources.resourceCulture);
      }
    }

    /// <summary>
    /// Looks up a localized string similar to Type list may not be empty or contain all null values..
    /// 
    /// </summary>
    internal static string InvalidModelBinderType
    {
      get
      {
        return RegistrationExtensionsResources.ResourceManager.GetString("InvalidModelBinderType", RegistrationExtensionsResources.resourceCulture);
      }
    }

    /// <summary>
    /// Looks up a localized string similar to The type '{0}' must be assignable to the filter type '{1}'..
    /// 
    /// </summary>
    internal static string MustBeAssignableToFilterType
    {
      get
      {
        return RegistrationExtensionsResources.ResourceManager.GetString("MustBeAssignableToFilterType", RegistrationExtensionsResources.resourceCulture);
      }
    }

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    internal RegistrationExtensionsResources()
    {
    }
  }
}
