using System;

namespace Framework.Contract
{
    public class ModelBase
    {

        public ModelBase()
        {
            CreateTime = DateTime.Now;
        }

        public virtual int Id{ get; set; }
        public virtual DateTime CreateTime { get; set; }
    }
}
