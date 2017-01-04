using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Framework.Utility.Extention
{
    public static class ConverterExtention
    {

        public static int ToInt(this decimal value)
        {
            var decimalNum = value - (int)value;
            if (decimalNum >= 0.5m)
            {
                return ((int)value) + 1;
            }
            return (int)value;
        }
        public static int ToInt(this Enum value)
        {

            return Convert.ToInt32(value);
        }

        public static int ToInt(this double value)
        {
            return ((decimal)value).ToInt();
        }

        /// <summary>
        /// 将时间精确到哪个级别
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="cutTicks"></param>
        /// <returns></returns>
        public static DateTime CutOff(this DateTime dateTime, long cutTicks = TimeSpan.TicksPerMillisecond)
        {
            return new DateTime(dateTime.Ticks - (dateTime.Ticks % cutTicks), dateTime.Kind);
        }


        public static string ToCnDataString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        public static string ToCnDataString(this DateTime? dateTime)
        {
            return dateTime == null ? string.Empty : dateTime.Value.ToCnDataString();
        }

        public static string ToStar(this string s, int star = 1)
        {
            var sb = new StringBuilder();
            if (string.IsNullOrEmpty(s))
            {
                return "*";
            }
            var firstLetter = s[0];
            var firstIsLetter = 65 < firstLetter && firstLetter < 122;//是不是英文字母
            if (firstIsLetter)
            {
                var array = s.Split(' ');
                if (array.Length > 1 && array[0].Length <= 10)
                {
                    sb.Append(array[0]);
                    if (!string.IsNullOrEmpty(array[1]))
                    {
                        sb.Append(" ");
                        sb.Append(array[1].Substring(0, 1).ToUpper());
                    }
                    else
                    {
                        sb.Append("*");
                    }
                }
                else
                {
                    var head = array[0];
                    sb.Append(head);
                    sb.Append("*");
                }
            }
            return sb.ToString();


        }
        public static DateTime ToDateTime(this string s, DateTime defalut = new DateTime())
        {
            DateTime result = defalut;
            if (DateTime.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        public static string ToWeek(this string date)
        {
            var dayOfWeek = Convert.ToInt32(date.ToDateTime().DayOfWeek);

            string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            return weekdays[dayOfWeek];
        }
        /// <summary>
        /// 字符串转GUID
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string s)
        {
            Guid result = Guid.Empty;
            if (Guid.TryParse(s, out result))
                return result;
            return Guid.Empty;
        }


        /// <summary>
        /// 字符串转Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string s) where T : struct
        {
            T result = default(T);
            Enum.TryParse<T>(s, true, out result);
            return result;
        }

        /// <summary>
        /// 字符串转int
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static int ToInt(this string s, int defalut = 0)
        {
            int result = defalut;
            if (int.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 字符串转bool
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static bool ToBool(this string s, bool defalut = false)
        {
            bool result = defalut;
            if (bool.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 字符串转double
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static double ToDouble(this string s, double defalut = 0)
        {
            double result = defalut;
            if (double.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defalut"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string s, decimal defalut = 0)
        {
            decimal result = defalut;
            if (decimal.TryParse(s, out result))
                return result;
            else
                return defalut;
        }

        public static string TrimAll(this string s)
        {
            return s.Replace(" ", "");
        }
        /// <summary>
        /// DataTable转换成泛型List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static IList<T> ToList<T>(this DataTable dt)
        {
            // 定义集合    
            IList<T> ts = new List<T>();

            // 获得此模型的类型   
            Type type = typeof(T);
            string tempName = "";

            T t = default(T);
            foreach (DataRow dr in dt.Rows)
            {
                t = Activator.CreateInstance<T>();
                //t = new T();
                // 获得此模型的公共属性      
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;  // 检查DataTable是否包含此列    

                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter      
                        if (pi.CanWrite)
                        {
                            object value = dr[tempName];
                            if (value != DBNull.Value)
                                pi.SetValue(t, value, null);
                        }


                    }
                }
                ts.Add(t);
            }
            return ts;
        }

        public static T ToEntity<T>(this DataTable dt, string filedName = "ConfigKey", string valueName = "ConfigValue")
        {
            // 获得此模型的类型   
            Type type = typeof(T);
            T t = Activator.CreateInstance<T>();
            var propertys = t.GetType().GetProperties().Where(r => r.CanWrite);
            foreach (DataRow dr in dt.Rows)
            {
                // 获得此模型的公共属性      
                if (dt.Columns.Contains(filedName) && dt.Columns.Contains(valueName))
                {
                    var pi = propertys.Where(r => r.Name == dr[filedName].ToString()).FirstOrDefault();
                    if (pi != null)
                    {
                        var value = Convert.ChangeType(dr[valueName], pi.PropertyType);
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
            }
            return t;
        }
    }
}