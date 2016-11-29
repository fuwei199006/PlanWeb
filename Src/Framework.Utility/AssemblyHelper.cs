using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Web;
using Framework.Extention;


namespace Framework.Utility
{
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public class AssemblyHelper
    {
        /// <summary>
        /// 获得入口的程序集
        /// </summary>
        /// <returns></returns>
        public static Assembly GetEntryAssembly()
        {
            // 获取默认应用程序域中的进程可执行文件。在其他的应用程序域中，这是由 <see cref="M:System.AppDomain.ExecuteAssembly(System.String)"/> 执行的第一个可执行文件。
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
                return entryAssembly;
            if (HttpContext.Current == null || HttpContext.Current.ApplicationInstance == null)// 为当前 HTTP 请求获取或设置
            {
                return Assembly.GetExecutingAssembly(); // 获取包含当前执行的代码的程序集。
            }
            var type = HttpContext.Current.ApplicationInstance.GetType();
            while (type != null && type.Namespace != "ASP") { }
            {
                type = type.BaseType;
            }
            return type == null ? null : type.Assembly;
        }

        /// <summary>
        /// 把所有的资源文件转成流文件
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IList<Stream> GetResourceStream(Assembly assembly, Expression<Func<string, bool>> predicate)
        {
            List<Stream> result=new List<Stream>();
            foreach (var resource in assembly.GetManifestResourceNames())// 返回此程序集中的所有资源的名称。
            {
                if (predicate.Compile().Invoke(resource))
                {
                    result.Add(assembly.GetManifestResourceStream(resource));
                }
            }
            var stream=new StreamReader(result[0]);
            var r = stream.ReadToEnd();
            result[0].Position = 0;
            return result;
        }
        /// <summary>
        /// 扫描程序集找到继承了某基类的所有子类
        /// </summary>
        /// <param name="inheritType">基类</param>
        /// <param name="searchPattern">文件名过滤</param>
        /// <returns></returns>
        public static List<Type> FindTypeByInheritType(Type inheritType, string searchPattern = "*.dll")
        {
            var result=new List<Type>();

            var domain = GetBaseDirectory();
            var dllFiles = Directory.GetFiles(domain, searchPattern, SearchOption.TopDirectoryOnly);// 指定是搜索当前目录
            foreach (var dllFile in dllFiles)
            {
                foreach (var type in Assembly.LoadFrom(dllFile).GetLoadableTypes())
                {
                    if (inheritType == type.BaseType)
                    {
                        result.Add(type);
                    }
                }
            }
            return result;

        }
        /// <summary>
        /// 扫描程序集找到带有某个Attribute的所有PropertyInfo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchPattern">文件名过滤</param>
        public static Dictionary<PropertyInfo, T> FindAllProperByAttribute<T>(string searchPattern = "*.dll")
            where T : Attribute
        {
            var result=new Dictionary<PropertyInfo, T>();
            var attr = typeof (T);

            var domain = GetBaseDirectory();
            var dllFiles = Directory.GetFiles(domain, searchPattern, SearchOption.TopDirectoryOnly);
            foreach (var dllFile in dllFiles)
            {
                foreach (var type in Assembly.LoadFrom(dllFile).GetLoadableTypes())
                {
                    foreach (var propertyInfo in type.GetProperties())
                    {
                        var attrs = propertyInfo.GetCustomAttributes(attr, true);
                        if(attrs.Length==0)
                            continue;
                        result.Add(propertyInfo,(T)attrs.First());
                    }
                }
            }
            return result;

        }

        /// <summary>
        /// 扫描程序集找到类型上带有某个Attribute的所有类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchPattern">文件名过滤</param>
        /// <returns></returns>
        public static Dictionary<string, List<T>> FindAllTypeByAttribute<T>(string searchPattern = "*.dll")
            where T : Attribute
        {
            var result = new Dictionary<string, List<T>>();
            Type attr = typeof(T);

            string domain = GetBaseDirectory();
            string[] dllFiles = Directory.GetFiles(domain, searchPattern, SearchOption.TopDirectoryOnly);

            foreach (string dllFileName in dllFiles)
            {
                foreach (Type type in Assembly.LoadFrom(dllFileName).GetLoadableTypes())
                {
                    var typeName = type.AssemblyQualifiedName;

                    var attrs = type.GetCustomAttributes(attr, true);// 在派生类中重写时，返回应用于此成员并由 <see cref="T:System.Type"/> 标识的自定义特性的数组。
                    if (attrs.Length == 0)
                        continue;

                    result.Add(typeName, new List<T>());

                    foreach (T a in attrs)
                        result[typeName].Add(a);

                }
            }

            return result;
        }

        /// <summary>
        /// 扫描程序集找到实现了某个接口的第一个实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchPattern">文件名过滤</param>
        public static T FindTypeByInterface<T>(string searchPattern = "*.dll") where T : class
        {
            var interfaceType = typeof (T);

            var domain = GetBaseDirectory();
            var dllFiles = Directory.GetFiles(domain, searchPattern, SearchOption.TopDirectoryOnly);

            foreach (var dllFileName in dllFiles)
            {
                foreach (var type in Assembly.LoadFrom(dllFileName).GetLoadableTypes())
                {
                    if (interfaceType != type && interfaceType.IsAssignableFrom(type))
                    {
                        var instance = Activator.CreateInstance(type) as T;
                        return instance;
                    }
                }
            }
            return null;

        }
        private static string GetBaseDirectory()
        {
            var baseDirectory = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;// 获取或设置应用程序基目录下的目录列表，这些目录被探测以寻找其中的私有程序集。
            if (baseDirectory == null)
            {
                baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            }
            return baseDirectory;
        }
    }
}