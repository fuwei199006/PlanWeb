using System;
using System.Collections.Generic;
using Framework.Contract;
using System.ComponentModel.DataAnnotations;

namespace Plain.Model.Models.Model
{
    [Serializable]
    public partial class Basic_Menu : ModelBase
    {
        [Required(ErrorMessage = "菜单名称不能为空")]
        public string MenuName { get; set; }
        [Required(ErrorMessage = "菜单链接不能为空")]
        public string MenuUrl { get; set; }
 
        public string MenuType { get; set; }
        [Required(ErrorMessage = "菜单排序不能为空")]
        [RegularExpression(@"\w+", ErrorMessage = "菜单排序不是有效值")]
        public Nullable<int> MenuSort { get; set; }
        public Nullable<int> MenuParentId { get; set; }
 
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public int  MenuStatus { get; set; }
        [Required(ErrorMessage = "菜单图标不能为空")]
        public string MenuIcon { get; set; }

    }
}
