using ChilLaxBackEnd.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChilLaxBackEnd.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Checkout()
        {
            List<CheckoutViewModel> test = new List<CheckoutViewModel>();
            CheckoutViewModel item = new CheckoutViewModel();
            item.MerchantID = 3002599;
            item.BackstageAccound = "stagetest2";
            item.BackstagePassword = "test1234";
            //item.統一編號 = 00000000;
            item.身分證末四碼 = 3609;
            item.HashKey = "pwFHCqoQZGmho4w6";
            item.HashIV = "EkRm7iFT261dpevs";
            test.Add(item);

            return View(test);
        }


        //[HttpPost]
        //public ActionResult ProcessCheckout(CheckoutViewModel model)
        //{
        //// 根據你的需求，處理結帳資料，例如驗證資料、計算金額等

        //// 呼叫 ECPay 的 API，將資料傳送給 ECPay 進行結帳
        //// 這裡使用 JavaScript 和 AJAX 技術呼叫 API
        //// 請確保引入 jQuery 函式庫

        //// 使用 AJAX 傳送 POST 請求到 ECPay 的 API
        ////$.ajax({
        ////    url: "https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5",
        ////    type: "POST",
        ////    dataType: "html",
        ////    data: model, // 將模型物件作為請求資料傳送給 API
        ////    success: function(response) {
        ////            // 處理 API 回傳的結果
        ////            // 可以將回傳的 HTML 內容插入到頁面中，或者重新導向到回傳的 URL
        ////            // 例如：
        ////            // $('#result-container').html(response); // 將回傳的 HTML 內容插入到名為 "result-container" 的元素中
        ////            // window.location.href = response; // 重新導向到回傳的 URL
        ////        },
        ////    error: function(xhr, status, error) {
        ////            // 處理錯誤情況
        ////            console.log(error);
        ////        }
        ////    });

        ////    return RedirectToAction("Checkout");
        //}
    }

}