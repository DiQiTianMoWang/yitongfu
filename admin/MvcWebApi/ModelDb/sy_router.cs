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
    
    public partial class sy_router
    {
        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string redirect { get; set; }
        public string icon { get; set; }
        public Nullable<bool> nodropdown { get; set; }
        public string meta { get; set; }
        public Nullable<int> sort { get; set; }
        public Nullable<bool> hidden { get; set; }
        public string createuser { get; set; }
        public Nullable<System.DateTime> createtime { get; set; }
        public string lastupdateuser { get; set; }
        public Nullable<System.DateTime> lastupdatetime { get; set; }
        public byte[] tx { get; set; }
    }
}
