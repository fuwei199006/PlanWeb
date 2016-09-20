
 

using System;
using System.Collections.Generic;
namespace My.Model
{   

    /// <summary>
    /// 实体-T_FrameWork_Detali 
    /// </summary>
    public partial class T_FrameWork_Detali    
    {    
        public String WfmId { get; set; }
          public String ReceiptNum { get; set; }
          public String CredenceCode { get; set; }
          public String PayMethod { get; set; }
          public String SaveBank { get; set; }
          public DateTime? PrintDate { get; set; }
          public String PayMan { get; set; }
          public String ReceiveMan { get; set; }
          public String ReceiveBank { get; set; }
          public String ReceiveAccount { get; set; }
          public String BillType { get; set; }
          public String NonCorpIncomeType { get; set; }
          public Decimal? NonCorpIncome { get; set; }
          public String PayUsage { get; set; }
          public Int32? ContractEnd { get; set; }
          public Decimal? AnJieMoney { get; set; }
          public Decimal? LayMoney { get; set; }
          public String NewProperty { get; set; }
    } 
    /// <summary>
    /// 实体-T_SubEngine_Err 
    /// </summary>
    public partial class T_SubEngine_Err    
    {    
        public Int32 errid { get; set; }
          public String XMLFields { get; set; }
          public String WfmId { get; set; }
          public String ErrorMsg { get; set; }
          public DateTime? dRecordTime { get; set; }
          public Int32? isdeal { get; set; }
          public String systemFlag { get; set; }
          public Int32? flowId { get; set; }
    } 
    /// <summary>
    /// 实体-T_SubEngine_Exc 
    /// </summary>
    public partial class T_SubEngine_Exc    
    {    
        public Int32 excid { get; set; }
          public String XMLFields { get; set; }
          public DateTime? ReceiveTime { get; set; }
          public String systemFlag { get; set; }
          public Int32? flowId { get; set; }
    } 
