using SupplementOrderWeb.Models;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using Type = SupplementOrderWeb.Models.Type;
using Newtonsoft.Json;
using System;
using SupplementOrderWeb.Code;

namespace SupplementOrderWeb.Controllers
{
    public class HomeController : Controller
    {
        private supplementOrderDBContext context;

        

        public ActionResult Index()
        {
            context = new supplementOrderDBContext();
            return View();
        }

        public ActionResult Order(supplementOrderDBContext context)
        {
            this.context = context;

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Type");
            List<Type> typesList = new List<Type>();
            foreach (DataRow row in data.Rows)
            {
                Type i = new Type();
                i.id = (byte)row["id"];
                i.name= row["name"].ToString();
                typesList.Add(i);
            }
            ViewBag.TypesList = typesList;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Our information here. Contact us if you need some help";

            return View();
        }
        [HttpPost]
        public string getData(byte typeId)
        {
            List<Product> list = new List<Product>();

            string query = "Select * from Product where type=" + typeId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                Product i = new Product();
                i.id = (long)row["id"];
                i.name = row["name"].ToString();
                i.price = (double)row["price"];
                i.unit = row["unit"].ToString();
                list.Add(i);
            }
            string v = JsonConvert.SerializeObject(list);
            return v;
        }

        [HttpPost]
        public string makeOrder(string json,string paymentType)
        {
            if (SessionHelper.getSession() == null)
            {
                return "Please Login to your account.";
            }
            else
            {
                var deptList = JsonConvert.DeserializeObject<IList<ExportDetail>>(json);

                long lastestExport = writeExport(paymentType);

                foreach (var item in deptList)
                {
                    writeDetail(lastestExport, item.pid, item.quantity);
                }
                return "Make an order successfully.";
            }
        }


        public long getCustomerID()
        {
            try
            {
                string phone = SessionHelper.getSession().UserPhone;
                string query = "Select * from Customer where phone=" + phone;
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                return (long)data.Rows[0]["id"];
            }
            catch (Exception e)
            {
                return 0;
            }
        }


        public long writeExport(string paymentType)
        {
            string query = "Exec writeExport @cid , @sid , @paymentType , @statusPayment , @statusDelivery ";
            long cid = getCustomerID();
            if(cid == 0)
                return 0;
            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { cid, 1, paymentType, 0, "Waiting" });
                query = "Exec GetLastestIDExport";
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                return (long)data.Rows[0]["id"];
            }
            catch(Exception e)
            {
                return 0;
            }
            return 0;
        }

        public void writeDetail(long bid,long pid,int quantity)
        {
            string query = "Exec writeExportDetail @bid , @pid , @quantity ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { bid, pid, quantity });
        }
    }
}