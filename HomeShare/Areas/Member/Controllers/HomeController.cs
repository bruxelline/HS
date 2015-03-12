﻿using HomeShare.Areas.Member.Models;
using HomeShare.Helper;
using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Member/Home/
         public ActionResult Index()
        {
            if (Utils.Login != null)
            {
              
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtLog, string txtPass)
        {
            Membre m = Membre.ChargerMembreViaMotDePasse(txtLog, txtPass);

            if(m ==  null)

            {
                ViewBag.Error = "Essaie encore !!!";
                return View();
            }

            else

            {
                Utils.Login = m.Login;
                Utils.User = m;

                return RedirectToRoute(new { controller = "Home", action ="Index"});
            }
          
        }

        [HttpGet]
        public ActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(string txtNom, string txtPrenom, string txtEmail, int idPays, string txtTel, string txtLogin, string txtPassword)
        {
            Membre m = new Membre();
            m.Nom = txtNom;
            m.Prenom = txtPrenom;
            m.Email = txtEmail;
            m.Pays = (int)idPays;
            m.Telephone = txtTel;
            m.Login = txtLogin;
            m.Password = txtPassword;
            m.Sauvegarder();

            return RedirectToRoute(new { area = "Member", controller = "Home", action = "Inscription" });
        }


        [HttpGet]
        public ActionResult AjouterBienMembre()
        {
            if (Utils.Login == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjouterBienMembre( BienEchange b,
           HttpPostedFileWrapper Fclient, string txtTitre, string txtdescCourt, string txtdescLong, int cap, int codePays,
            string txtVille, string txtRue, string txtNumero, string txtCP, string txtPhoto,
            bool txtAssurance, bool txtDispo, string txtLat, string txtLong, DateTime txtDate)
        {

            //Membre m = new Membre();
            //m.Nom = txtNom;
            //m.Prenom = txtPrenom;
            //m.Email = txtEmail;
            //m.Pays = (int)idPays;
            //m.Telephone = txtTel;
            //m.Login = txtLogin;
            //m.Password = txtPassword;
            //m.Sauvegarder();

            if (Utils.Login == null)
            {
                return RedirectToAction("Login");
            }

            if (Fclient != null)
            {
                b.Titre = txtTitre;
                b.DescCourte = txtdescCourt;
                b.DescLong = txtdescLong;
                b.NombrePerson = cap;
                b.Pays = codePays;
                b.Ville = txtVille;
                b.Rue = txtRue;
                b.Numero = txtNumero;
                b.CodePostal = txtCP;
                b.Photo = txtPhoto;
                b.AssuranceObligatoire = (bool)txtAssurance;
                b.IsEnabled = (bool)txtDispo;
                b.Latitude = txtLat;
                b.Longitude = txtLong;
                b.DateCreation = (DateTime)txtDate;
                b.Photo = Fclient.FileName;
                b.Sauvegarder();
                // Fclient.SaveAs(@"C:\Users\l.arnolin\Documents\visual studio 2013\Projects\HomeShare\HomeShare\Content\img\" + Fclient.FileName);
            }
            else
            {
                b.Photo = "";
            }
           
          

            return RedirectToAction("Index");
        }


        public ActionResult ListeBiens()
        {
            if (Utils.Login == null)
            {
               return RedirectToAction("Login");

             //MembreModel bmm = new MembreModel()
             //   {
             //       LstBiens = Membre.ChargerBienDuMembre()
             //   };

             //   return View(bmm);
            }

            return View(HomeShareDAL.BienEchange.ChargerTousLesBiens());
          
        }

        [HttpGet]
        public ActionResult EditBienMembre(int id)
        {
            if (Utils.Login == null)
            {
                return RedirectToAction("Login");
            }
            BienEchange be = BienEchange.ChargerUnBien(id);
            return View(be);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BienEchange b, HttpPostedFileWrapper Fclient)
        {
            if (Utils.Login == null)
            {
                return RedirectToAction("Login");
            }
            if (Fclient != null)
            {
                b.Photo = Fclient.FileName;
                Fclient.SaveAs(@"C:\Users\l.arnolin\Documents\visual studio 2013\Projects\HomeShare\HomeShare\Content\img\" + Fclient.FileName);
            }
            else
            {
                b.Photo = BienEchange.ChargerUnBien(b.IdBien).Photo;
            }
        
            b.Sauvegarder();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Utils.Login == null)
            {
                return RedirectToAction("Login");
            }
            BienEchange be = BienEchange.ChargerUnBien(id);
            be.Supprimer();
            return RedirectToAction("ListeBiens");
        }


        public ActionResult LogOut()
        {
            Utils.Login = null;
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}