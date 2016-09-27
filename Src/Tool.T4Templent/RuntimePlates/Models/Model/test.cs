
  

namespace DataAccess.Model.Office
{
    public partial class Test  
    {
        public long ItemID { get; set; }
        public string ItemName { get; set; }
        public Nullable<long> ParentID { get; set; }
        public string ItemType { get; set; }
        public string Remark { get; set; }
        public System.DateTime dRecordTime { get; set; }
    }
}

