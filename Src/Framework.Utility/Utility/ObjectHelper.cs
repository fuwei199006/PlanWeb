﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
 

namespace Framework.Utility 
{
    public static class ObjectHelper
    {
        /// <summary>
        /// 不同对象之间的深拷贝 
        /// </summary>
        /// <typeparam name="T">源对象类型</typeparam>
        /// <typeparam name="F">目的对象类型</typeparam>
        /// <param name="original">源对象</param>
        /// <returns>目的对象</returns>
        public static F DeepCopy<T, F>( this T original)
        {
            var json = SerializationHelper.JsonSerialize<T>(original);
            var result = SerializationHelper.JsonDeserialize<F>(json);
            return result;
        }
        /// <summary>
        /// 相同对象之间的深拷贝 
        /// </summary>
        /// <typeparam name="T">源对象类型</typeparam>
        /// <typeparam name="F">目的对象类型</typeparam>
        /// <param name="original">源对象</param>
        /// <returns>目的对象</returns>
        public static T DeepCopy<T>(this T original)
        {
            var json = SerializationHelper.JsonSerialize<T>(original);
            var result = SerializationHelper.JsonDeserialize<T>(json);
            return result;
        }
        public static void DeepCopy<T, F>(this T original, F desination)
        {
            desination = DeepCopy<T, F>(original);
        }


    }

}
