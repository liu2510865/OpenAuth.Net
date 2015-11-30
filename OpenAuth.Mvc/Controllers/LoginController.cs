﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenAuth.App;

namespace OpenAuth.Mvc.Controllers
{
    public class LoginController : Controller
    {
        private LoginApp _app;

        public LoginController()
        {
            _app = (LoginApp)DependencyResolver.Current.GetService(typeof(LoginApp));
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            try
            {
                _app.Login(username, password);
                return RedirectToAction("Index", "Home");
                
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
    }
}