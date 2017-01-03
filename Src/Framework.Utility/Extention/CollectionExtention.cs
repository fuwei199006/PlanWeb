﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Framework.Utility.Extention
{
    public static class CollectionExtention
    {
        /// <summary>
        /// 数组或list随机选出几个
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="collection">数组或list</param>
        /// <param name="count">选出数量</param>
        /// <returns></returns>
        public static IEnumerable<T> Random<T>(this IEnumerable<T> collection, int count)
        {
            var rd = new Random();
            return collection.OrderBy(c => rd.Next()).Take(count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Random<T>(this IEnumerable<T> collection)
        {
            return collection.Random<T>(1).SingleOrDefault();
        }

        public static string[] ToArray(this MatchCollection matchs)
        {
            var str = new string[matchs.Count];
            var arr = new object[matchs.Count];
            matchs.CopyTo(arr,0);
            for (int i = 0; i < arr.Length; i++)
            {
                str[i] = arr[i].ToString();
            }
            return str ;
        }
    }
}
