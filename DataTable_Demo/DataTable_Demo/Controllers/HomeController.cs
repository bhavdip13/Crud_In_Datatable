using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTable_Demo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private PMSEntities context = new PMSEntities();

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult SaveAndUpdateProduct(int PID,string Name, string Description, float Price)
        {
            var result = new jsonMessage();
            try
            {
                //define the model
                Mst_Product _Mst_Product = new Mst_Product();
                _Mst_Product.PID = PID;
                _Mst_Product.Name = Name;
                _Mst_Product.Description = Description;
                _Mst_Product.Price = Price;


               //for insert recored..
                if (_Mst_Product.PID == 0)
                {
                    context.Mst_Product.Add(_Mst_Product);
                    result.Message = "your product has been saved success..";
                    result.Status = true;
                }
                else  //for update recored..
                {
                    context.Entry(_Mst_Product).State = EntityState.Modified;
                    result.Message = "your product has been updated successfully..";
                    result.Status = true;
                }
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
       
        public JsonResult GetProduct()
        {

            List<Mst_Product> _list = new List<Mst_Product>();
           
            try
            {
                _list = context.Mst_Product.ToList();
                     var  result = from c in _list
                         select new[]
                         {
                          Convert.ToString( c.PID ),  // 0   
                          Convert.ToString( c.Name ),  // 1   
                          Convert.ToString( c.Description ),  // 2   
                          Convert.ToString( c.Price ),  // 3   
                                                   };

                     return Json(new
                     {
                        aaData= result
                     }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                ErrorLogers.ErrorLog(ex);
                return Json(new
                {
                    aaData = new List<string[]> { }
                }, JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult DeleteProduct(int id)
        {
            var result = new jsonMessage();
            try
            {

                var product = new Mst_Product { PID = id };
                context.Entry(product).State = EntityState.Deleted;
                context.SaveChanges();

                
                result.Message = "your product has been deleted successfully..";
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
       
    }
}
