﻿using Plain.Dao;
using Plain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plain.Dao.MenuDao
{
   public class MenuDao:BaseDao<Basic_MenuDto>,IMenuDao
    {
        public List<Basic_MenuDto> GetMenuDto()
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
                        n.MenuName AS ParentMenuName ,
                        n.MenuType AS ParentMenuType
                FROM    dbo.Basic_Menu m
                       LEFT JOIN dbo.Basic_Menu n ON m.MenuParentId = n.Id;";
            return this.ExceSql<Basic_MenuDto>(sql);
        }
    }
}
