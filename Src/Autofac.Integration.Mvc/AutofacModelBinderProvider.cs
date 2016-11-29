// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.AutofacModelBinderProvider
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using Autofac.Features.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// Autofac implementation of the <see cref="T:System.Web.Mvc.IModelBinderProvider"/> interface.
  /// 
  /// </summary>
  public class AutofacModelBinderProvider : IModelBinderProvider
  {
    /// <summary>
    /// Metadata key for the supported model types.
    /// 
    /// </summary>
    internal static readonly string MetadataKey = "SupportedModelTypes";

    /// <summary>
    /// Gets the model binder associated with the provided model type.
    /// 
    /// </summary>
    /// <param name="modelType">Type of the model.</param>
    /// <returns>
    /// An <see cref="T:System.Web.Mvc.IModelBinder"/> instance if found; otherwise, <c>null</c>.
    /// </returns>
    public IModelBinder GetBinder(Type modelType)
    {
      Meta<Lazy<IModelBinder>> meta = Enumerable.FirstOrDefault<Meta<Lazy<IModelBinder>>>(Enumerable.Where<Meta<Lazy<IModelBinder>>>(DependencyResolverExtensions.GetServices<Meta<Lazy<IModelBinder>>>(DependencyResolver.Current), (Func<Meta<Lazy<IModelBinder>>, bool>) (binder => binder.Metadata.ContainsKey(AutofacModelBinderProvider.MetadataKey))), (Func<Meta<Lazy<IModelBinder>>, bool>) (binder => ((List<Type>) binder.Metadata[AutofacModelBinderProvider.MetadataKey]).Contains(modelType)));
      if (meta == null)
        return (IModelBinder) null;
      return meta.Value.Value;
    }
  }
}
