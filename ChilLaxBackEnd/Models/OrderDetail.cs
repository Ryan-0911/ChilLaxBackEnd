//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChilLaxBackEnd.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class OrderDetail
    {
        public int order_id { get; set; }
        public int product_id { get; set; }
        [Display(Name ="數量")]
        public int cart_product_quantity { get; set; }
    
        public virtual ProductOrder ProductOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}
