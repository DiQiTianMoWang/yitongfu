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
    
    public partial class po_abnormalorder
    {
        public int id { get; set; }
        public string orderno { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string appid { get; set; }
        public Nullable<int> businessid { get; set; }
        public string account { get; set; }
        public string remark { get; set; }
        public Nullable<int> paytype { get; set; }
        public Nullable<System.DateTime> tradetime { get; set; }
        public Nullable<System.DateTime> addtime { get; set; }
    }
}