using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTable_Demo.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        private PMSEntities context = new PMSEntities();
        public class Cart_Deatails
        {
            public int PID { get; set; }

            public string Name { get; set; }
            public string Description { get; set; }
            public Nullable<double> Price { get; set; }

            public int Quantity { get; set; }
            public DateTime Date { get; set; }

            public double TotalPrice { get; set; }

        }
        public ActionResult Cart()
        {
            var joinedResult = (from u in context.Mst_Product
                                join u2 in context.Carts on u.PID equals u2.PID

                                select new Cart_Deatails
                                {
                                    PID=u.PID,
                                    Name = u.Name,
                                    Description = u.Description,
                                    Price = u.Price,
                                    Quantity=u2.Quantity,
                                    Date=u2.DateTime,
                                    TotalPrice=u2.TotalPrice



                                }).ToList();

            return View(joinedResult);
        }
        public ActionResult Invoice()
        {

            var joinedResult = (from u in context.Mst_Product
                                join u2 in context.Carts on u.PID equals u2.PID

                                select new Cart_Deatails
                                {
                                    PID = u.PID,
                                    Name = u.Name,
                                    Description = u.Description,
                                    Price = u.Price,
                                    Quantity = u2.Quantity,
                                    Date = u2.DateTime,
                                    TotalPrice = u2.TotalPrice



                                }).ToList();

            return View(joinedResult);

        }
        public JsonResult DeleteProduct(int id)
        {
            var result = new jsonMessage();
            try
            {

                
                var a = context.Carts.Where(x => x.PID == id).FirstOrDefault();
                context.Carts.Remove(a);
                context.SaveChanges();


                result.Message = "your product has been removed successfully..";
                result.Status = true;

            }
            catch (Exception ex)
            {
                ErrorLogers.ErrorLog(ex);
                result.Message = "We are unable to process your request at this time. Please try again later.";
                result.Status = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateCart(int id, string Qty, string FinalAmount)
        {
            var result = new jsonMessage();
            try
            {

                Cart a = context.Carts.Where(x => x.PID == id).FirstOrDefault();


                //define the model
              
                a.PID = Convert.ToInt32(id);
                a.Quantity = Convert.ToInt32(Qty);
                a.TotalPrice = Convert.ToDouble(FinalAmount);
              

                //for Update cart..

                context.Entry(a).State = EntityState.Modified;
                    result.Message = "";
                    result.Status = true;
                
                context.SaveChanges();


            }
            catch (Exception ex)
            {
                ErrorLogers.ErrorLog(ex);
                result.Message = "We are unable to process your request at this time. Please try again later.";
                result.Status = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
       
    }
}
