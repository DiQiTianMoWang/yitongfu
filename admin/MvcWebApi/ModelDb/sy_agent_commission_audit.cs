//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class sy_agent_commission_audit
    {
        public int id { get; set; }
        public int agid { get; set; }
        public Nullable<int> transaction_number { get; set; }
        public Nullable<decimal> total_income { get; set; }
        public Nullable<decimal> commission { get; set; }
        public Nullable<System.DateTime> addtime { get; set; }
        public Nullable<int> status { get; set; }
    }
}
