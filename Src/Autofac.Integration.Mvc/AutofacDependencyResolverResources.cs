// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.AutofacDependencyResolverResources
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
  internal class AutofacDependencyResolverResources
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
        if (AutofacDependencyResolverResources.resourceMan == null)
          AutofacDependencyResolverResources.resourceMan = new ResourceManager("Autofac.Integration.Mvc.AutofacDependencyResolverResources", typeof (AutofacDependencyResolverResources).Assembly);
        return AutofacDependencyResolverResources.resourceMan;
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
        return AutofacDependencyResolverResources.resourceCulture;
      }
      set
      {
        AutofacDependencyResolverResources.resourceCulture = value;
      }
    }

    /// <summary>
    /// Looks up a localized string similar to The dependency resolver is of type '{0}' but was expected to be of type '{1}'. It also does not appear to be wrapped using DynamicProxy from the Castle Project. This issue could be the result of a change in the DynamicProxy implementation or the use of a different proxy library to wrap the dependency resolver..
    /// 
    /// </summary>
    internal static string AutofacDependencyResolverNotFound
    {
      get
      {
        return AutofacDependencyResolverResources.ResourceManager.GetString("AutofacDependencyResolverNotFound", AutofacDependencyResolverResources.resourceCulture);
      }
    }

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    internal AutofacDependencyResolverResources()
    {
    }
  }
}
