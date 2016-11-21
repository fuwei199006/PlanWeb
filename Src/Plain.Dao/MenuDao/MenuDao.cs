using Plain.Dao;
using Plain.Dto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Contract;
using Plain.Model.Models.Model;

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

       public List<Basic_Menu> GetMenuByUserName(string loginName)
       {
            var sql= @"SELECT  DISTINCT menu.* FROM    dbo.Basic_UserInfo userinfo
                                JOIN dbo.Basic_UserRole userRole ON userRole.UserId = userinfo.Id
                                                                    AND userRole.MappingStatus = 1
                                JOIN dbo.Basic_PowerRole powerRole ON userRole.RoleId = powerRole.RoleId
                                                                      AND powerRole.MappingStatus = 1
                                JOIN dbo.Basic_PowerMenu powerMenu ON powerRole.PowerId = powerMenu.PowerId
                                                                      AND powerMenu.MappingStatus = 1
                                JOIN dbo.Basic_Menu menu ON menu.Id = powerMenu.MenuId
                        WHERE   userinfo.LoginName =@loginName";
           var dbParas = new SqlParameter[]
           {
               new SqlParameter("@loginName", loginName),
           };
           return this.ExceSql<Basic_Menu>(sql, dbParas);
       }
    }
}
