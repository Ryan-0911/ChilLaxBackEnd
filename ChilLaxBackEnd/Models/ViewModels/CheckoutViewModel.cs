using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChilLaxBackEnd.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public int MerchantID { get; set;}
        public string BackstageAccound { get; set; }
        public string BackstagePassword { get; set; }
        public int 統一編號 { get; set; }
        public int 身分證末四碼 { get; set; }
        public string HashKey { get; set; }
        public string HashIV { get; set; }
    }
}