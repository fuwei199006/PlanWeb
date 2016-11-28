// Decompiled with JetBrains decompiler
// Type: Autofac.Integration.Mvc.ModelBinderTypeAttribute
// Assembly: Autofac.Integration.Mvc, Version=4.0.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da
// MVID: B2444721-1B04-45D0-8357-D0AC1BC734E4
// Assembly location: E:\github\PlanWeb\Src\packages\Autofac.Mvc5.4.0.0\lib\net451\Autofac.Integration.Mvc.dll

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Autofac.Integration.Mvc
{
  /// <summary>
  /// Indicates what types a model binder supports.
  /// 
  /// </summary>
  [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments")]
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
  public sealed class ModelBinderTypeAttribute : Attribute
  {
    /// <summary>
    /// Gets the target types.
    /// 
    /// </summary>
    public IEnumerable<Type> TargetTypes { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Autofac.Integration.Mvc.ModelBinderTypeAttribute"/> class.
    /// 
    /// </summary>
    /// <param name="targetTypes">The target types.</param>
    public ModelBinderTypeAttribute(params Type[] targetTypes)
    {
      if (targetTypes == null)
        throw new ArgumentNullException("targetTypes");
      this.TargetTypes = (IEnumerable<Type>) targetTypes;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Autofac.Integration.Mvc.ModelBinderTypeAttribute"/> class.
    /// 
    /// </summary>
    /// <param name="targetType">The target type.</param>
    public ModelBinderTypeAttribute(Type targetType)
    {
      if (targetType == (Type) null)
        throw new ArgumentNullException("targetType");
      Type[] typeArray = new Type[1];
      int index = 0;
      Type type = targetType;
      typeArray[index] = type;
      this.TargetTypes = (IEnumerable<Type>) typeArray;
    }
  }
}
