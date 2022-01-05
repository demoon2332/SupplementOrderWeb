using Newtonsoft.Json;
using SupplementOrderWeb.Code;
using SupplementOrderWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupplementOrderWeb.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string getCartData()
        {
            if (SessionHelper.getSession() == null)
            {
                return "0";
            }
            if (SessionHelper.getSession().UserPhone == null)
            {
                return "0";
            }
            long cid = HomeController.Instance.getCustomerID();

            List<Cart> list = new List<Cart>();

            string query = "Exec getFullDetailExportByCID @cid ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,new object[] {cid });
            foreach (DataRow row in data.Rows)
            {
                Cart i = new Cart();
                i.bid = (long)row["bid"];
                i.name = row["name"].ToString();
                i.price = (double)row["price"];
                i.unit = row["unit"].ToString();
                i.quantity = (int)row["quantity"];
                i.intoMoney = (double)row["intoMoney"];
                list.Add(i);
            }
            string v = JsonConvert.SerializeObject(list);
            return v;
        }


    }
}