using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChilLaxBackEnd.Models.ViewModels
{
    public class ProductViewModel
    {
        public int product_id { get; set; }
        public int supplier_id { get; set; }
        public string product_name { get; set; }
        public string product_desc { get; set; }
        public int product_price { get; set; }
        public string product_img { get; set; }
        public int product_quantity { get; set; }
        public string product_category { get; set; }
        public bool product_state { get; set; }

        public HttpPostedFile photo { get; set; }
    }
}