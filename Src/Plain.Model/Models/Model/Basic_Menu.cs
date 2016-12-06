using System;
using System.Collections.Generic;
using Framework.Contract;
using System.ComponentModel.DataAnnotations;

namespace Plain.Model.Models.Model
{
    [Serializable]
    public partial class Basic_Menu : ModelBase
    {
        [Required(ErrorMessage = "�˵����Ʋ���Ϊ��")]
        public string MenuName { get; set; }
        [Required(ErrorMessage = "�˵����Ӳ���Ϊ��")]
        public string MenuUrl { get; set; }
 
        public string MenuType { get; set; }
        [Required(ErrorMessage = "�˵�������Ϊ��")]
        [RegularExpression(@"\w+", ErrorMessage = "�˵���������Чֵ")]
        public Nullable<int> MenuSort { get; set; }
        public Nullable<int> MenuParentId { get; set; }
 
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public int  MenuStatus { get; set; }
        [Required(ErrorMessage = "�˵�ͼ�겻��Ϊ��")]
        public string MenuIcon { get; set; }

    }
}
