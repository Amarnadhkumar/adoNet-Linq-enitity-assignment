using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Busdetails.mycontext;


namespace Busdetails.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        aspNetEntities dbObj = new aspNetEntities();
        public ActionResult Bus(Busdetail busTracking)
        {

            return View(busTracking);
        }

        [HttpPost]
        public ActionResult AddBus(Busdetail busTracking)
        {
            if (ModelState.IsValid)
            {

                Busdetail obj = new Busdetail();
                obj.BusID = busTracking.BusID;
                obj.BoardingPoint = busTracking.BoardingPoint;
                obj.TravelDate = busTracking.TravelDate;
                obj.Amount = busTracking.Amount;
                obj.Rating = busTracking.Rating;
                if (busTracking.BusID == 0)
                {
                    dbObj.Busdetails.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(busTracking).State = EntityState.Modified;
                    dbObj.SaveChanges();

                    var list = dbObj.Busdetails.ToList();
                    return View("BusList", list);

                }
                ModelState.Clear();
            }



            return View("Bus");
        }
        public ActionResult BusList()
        {
            var result = dbObj.Busdetails.ToList();
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            var result = dbObj.Busdetails.Where(x => x.BusID == id).First();
            dbObj.Busdetails.Remove(result);
            dbObj.SaveChanges();

            var list = dbObj.Busdetails.ToList();

            return View("BusList", list);
        }
    }
}