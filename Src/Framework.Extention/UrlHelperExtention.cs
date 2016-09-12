using System;
using System.Web;
using System.Web.Mvc;

namespace Framework.Extention
{
    public static class UrlHelperExtention
    {

        private static readonly string StaticServiceUri = null;
      

        public static string StaticFile(this UrlHelper urlHelper, string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }
            if (path.StartsWith("~"))
            {
                return urlHelper.Content(path);
            }
            return GetStaticServiceUrl() + path;
        }

        private static string GetStaticServiceUrl()
        {
            if (string.IsNullOrEmpty(StaticServiceUri))
            {
                return "http://" + HttpContext.Current.Request.Url.Authority; 
            }
            return StaticServiceUri;

        }

        public static string JsCssFile(this UrlHelper urlHelper, string path)
        {
            var jsAndCssFileEdition =Guid.NewGuid().ToString();
             
            path += String.Format("?v={0}", jsAndCssFileEdition);
            return urlHelper.StaticFile(path);
        }

        public static string ImageFile(this UrlHelper urlHelper, string path, string size = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                return urlHelper.StaticFile(@"/content/images/no_picture.jpg");
            }
            if (string.IsNullOrEmpty(size))
            {
                return urlHelper.StaticFile(path);
            }
            var ext = path.Substring(path.LastIndexOf('.'));
            var head = path.Substring(0, path.LastIndexOf('.'));
            var url = string.Format("{0}{1}_{2}{3}", GetStaticServiceUrl(), head, size, ext);
            return url;
        }


        /// <summary>
        /// 得到图片文件，缩略图，根据参数(width:100,height:75)返回如：
        /// http://...../upload/editorial/day_111013/thumb/201110130326326847_100_75.jpg
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="path"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        //public static string ImageFile(this UrlHelper helper, string path, int width, int height, bool containStaticServiceUri = true)
        //{
        //    if (string.IsNullOrEmpty(path))
        //        return helper.StaticFile(@"/content/images/no_picture.jpg");

        //    if (width <= 0 || height <= 0)
        //        return helper.StaticFile(path);

        //    var thumbnailUrl = ThumbnailHelper.GetThumbnailUrl(path, width, height);
        //    var url = (containStaticServiceUri ? GetStaticServiceUrl() : string.Empty) + thumbnailUrl;

        //    return url;

        //}
        /// <summary>
        /// 得到文件服务器根网址
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static string StaticFile(this UrlHelper helper)
        {
            return GetStaticServiceUrl();
        }
    }
}