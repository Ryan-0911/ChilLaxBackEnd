using ChilLaxBackEnd.Models.ViewModels;
using ChilLaxBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChilLaxBackEnd.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ChilLaxEntities db = new ChilLaxEntities();

            List<ModelChartJs> chartData = db.Database.SqlQuery<ModelChartJs>(@"
                WITH new_data AS (
                    SELECT
                    REPLACE(CONVERT(varchar(6), po.ORDER_DATE, 112), '-', '') AS OrderData,
                    po.ORDER_TOTALPRICE
                    FROM DBO.PRODUCTORDER PO
                )
                SELECT OrderData, SUM(ORDER_TOTALPRICE) AS Total FROM new_data GROUP BY OrderData;"
            ).ToList();

            return View(chartData);
            //return View();
        }
    }
}