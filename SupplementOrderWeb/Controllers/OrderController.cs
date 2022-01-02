using SupplementOrderWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Type = SupplementOrderWeb.Models.Type;

namespace SupplementOrderWeb.Controllers
{
    public class OrderController : Controller
    {
        private supplementOrderDBContext context;
        // GET: Order
        [HttpGet]
        public ActionResult Index()
        {
            context = new supplementOrderDBContext();
            return View();
        }

        [HttpPost]
        public ActionResult Index(GoodExport model,List<long> pid,List<int> quantity)
        {
            context = new supplementOrderDBContext();
            Response.Write("<script>alert(" + model.ToString() + " </ script > ");
            return View(model);
        }

        public List<Type> getAllTypesList()
        {
            List<Type> list = new List<Type>();
            string query = "Select * from Type ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Type i = new Type(item);
                list.Add(i);
            }
            return list;
        }
    }
}