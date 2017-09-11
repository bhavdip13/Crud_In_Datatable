using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DataTable_Demo.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private PMSEntities context = new PMSEntities();

        public ActionResult Product()
        {
            List<Mst_Product> _list = new List<Mst_Product>();
            _list = context.Mst_Product.ToList();
            return View(_list);
        }
        public JsonResult AddToCart(int PID)
        {
            var result = new jsonMessage();
            try
            {

                Mst_Product _Mst_Product = context.Mst_Product.Where(t => t.PID == PID).FirstOrDefault();

                //define the model of crt
                Cart _Cart = new Cart();
                _Cart.PID = PID;
                _Cart.Quantity = 1;
                _Cart.DateTime = System.DateTime.Now;
                _Cart.TotalPrice = Convert.ToDouble(_Mst_Product.Price);

                context.Carts.Add(_Cart);
                result.Message = "your product has been Added in to cart..";
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
