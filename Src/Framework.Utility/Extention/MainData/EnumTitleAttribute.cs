using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Utility.Extention.MainData
{
    public class EnumTitleAttribute:Attribute
    {
        private bool _IsDisplay = true;

        public EnumTitleAttribute(string title, params string[] synonyms)
        {
            Title = title;
            Synonyms = synonyms;
            Order = int.MaxValue;
        }
        public bool IsDisplay { get { return _IsDisplay; } set { _IsDisplay = value; } }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Letter { get; set; }
        /// <summary>
        /// 近义词
        /// </summary>
        public string[] Synonyms { get; set; }
        public int Category { get; set; }
        public int Order { get; set; }
    }
}
