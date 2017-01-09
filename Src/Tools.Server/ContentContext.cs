using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tools.Server
{
    public class ContentContext
    {

        public const string ContentTemplate = @"<!DOCTYPE html> <html> <head> <title>目录清单</title> </head> <body> <div class='container'> <header> <h2>目录清单:</h2> </header> <div class='clear'> </div> <div class='body'> <div class='return'> <a href='/'>[!返回上级]</a></div> <table class='table'> <thead> <tr> <th>名称</th> <th>大小</th> <th>类型</th><th>创建日期</th><th>修改日期</th> </tr> </thead> <tbody> {{content}} </tbody> </table> </div> <footer> 2017 © dev by fuwei. </footer> </div> </div> </body> </html> <style type='text/css'> a {text-decoration: none; color: #0000ee; } a:visited {color: #551a8b; } a:hover {color: #551a8b; } .container {width: 90%; margin: auto auto; } .debug {border: 1px solid black; } .clear {clear: both; border: 1px #666 solid; } .body {width: 100%; } .table {border-collapse: collapse; width: 100%; text-align: center; color: #666; margin: auto auto; } .table tr {border-bottom: 1px solid #bfbfbf; } .table th {height: 40px; } .table td {height: 40px; } .return {margin-top: 10px; } footer {text-align: right; bottom: 10px;  color: #666; } </style>";

        public const string ContentCell = @"<tr><td><a href='{{FullPath}}'>{{FileName}}</a></td> <td>{{FileSize}}</td> <td>{{FileType}}</td> <td>{{CreateTime}}</td><td>{{UpdateTime}}</td></tr>";

        public static string GetDirectoryContent(string path)
        {

            #region 获得文件
            var files = new List<FileEntity>();
            var root = path.Substring(path.IndexOf("/"), path.Length - path.IndexOf("/"));
            if (root == @"/")
            {
                root = string.Empty;
            }
            var dirs = Directory.GetDirectories(path);
            foreach (var item in dirs)
            {
                var dir = new DirectoryInfo(item);
                files.Add(new FileEntity()
                {
                    FileName = dir.Name,
                    FileType = "文件夹",
                    FileSize = "<dir>",
                    CreateTime = dir.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdateTime = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    FullPath = string.IsNullOrEmpty(root) ? dir.Name : root + "/" + dir.Name
                });
            }
            var pathFiles = Directory.GetFiles(path);
            foreach (var filePath in pathFiles)
            {
                var file = new FileInfo(filePath);
                files.Add(new FileEntity()
                {
                    FileName = file.Name,
                    FileType = "文件",
                    FileSize = GetFileSize(file.Length),
                    CreateTime = file.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdateTime = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    FullPath = string.IsNullOrEmpty(root) ? file.Name : root + "/" + file.Name
                });
            }

            #endregion


            var tableBody = new StringBuilder();
            foreach (var file in files)
            {
                var fileds = Regex.Matches(ContentCell, @"{{[^\{\}]+}}");
                var objArr = new object[fileds.Count];
                fileds.CopyTo(objArr, 0);
                var tbBody = ContentCell;
                foreach (var filed in objArr)
                {
                    var fileItem = filed.ToString().Replace("{{", "").Replace("}}", "");
                    var filedValue = file.GetType().GetProperty(fileItem).GetValue(file, null).ToString();
                    tbBody = tbBody.Replace(filed.ToString(), filedValue);

                }
                tableBody.Append(tbBody);
            }
            var result = ContentTemplate.Replace("{{content}}", tableBody.ToString());
            return result;

        }


        private static string GetFileSize(long fileSize)
        {
            var size = Convert.ToDecimal(fileSize);
            var unit = "B";
            if (size > 1024)
            {
                size = size / 1024M;
                unit = "KB";
            }
            if (size > 1024)
            {
                size = size / 1024M;
                unit = "MB";
            }
            if (size > 1024)
            {
                size = size / 1024M;
                unit = "GB";
            }
            if (size > 1024)
            {
                return "Big Size";
            }
            return Math.Round(size,2) + " " + unit;

           
      
        }
    }
}
