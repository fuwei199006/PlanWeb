using Plain.Dao;
using Plain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Contract;

namespace Plain.Dao.MenuDao
{
   public class MenuDao:BaseDao<Basic_MenuDto>,IMenuDao
    {
       public PagedList<Basic_MenuDto> GetMenuDto(string menuName, int pageSize, int pageIndex)
        {
            var sql = @"SELECT  m.Id ,
                        m.MenuName ,
                        m.MenuUrl ,
                        m.MenuType ,
                        m.MenuSort ,
                        m.MenuParentId ,
                        m.CreateTime ,
                        m.ModifyTime ,
                        m.MenuStatus ,
                        m.MenuIcon ,
                        n.MenuName AS ParentMenuName ,
                        n.MenuType AS ParentMenuType
                FROM    dbo.Basic_Menu m
                       LEFT JOIN dbo.Basic_Menu n ON m.MenuParentId = n.Id WHERE   m.MenuName LIKE '%{0}%'  OR n.MenuName LIKE '%{0}%' Order by m.Id, m.MenuSort;";
            sql = string.Format(sql, menuName);
            return this.ExceSqlPagedList<Basic_MenuDto>(sql,pageSize,pageIndex);
        }
    }
}
