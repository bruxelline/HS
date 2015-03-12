using HomeShare.Models;
using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int Page = 1)
        {
            
           
            BienEchange.ChargerLesMeilleursEchange();

            Double d = (double)(HomeShareDAL.BienEchange.ChargerLesDerniersBiens().Count());
            ViewBag.tot = Math.Ceiling(d / 3);
              
            return View(HomeShareDAL.BienEchange.ChargerPagination(Page));
          
        }

        public ActionResult ListingBiens()
        {
            List<BienEchange> be = BienEchange.ChargerTousLesBiens();
            return View(be);

        }

        public ActionResult DetailsDuBien(int id)
        {
            DetailsBienModel dbm = new DetailsBienModel()
            {
                CurrentBien = BienEchange.ChargerUnBien(id),
                PaysDuBien = Pays.ChargerPaysBien(id),
                CurrentMembre = Membre.ChargerMembreViaBien(id),
                ListeOptions = OptionsBien.ChargerOptionsBien(id),
                ListeLibelleOptions = Options.ChargerLibellesOptionsBien(id)
            };

            return View(dbm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}