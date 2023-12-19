using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//using Google.Cloud.Firestore;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace stanley_india
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //void Session_Start(object sender, EventArgs e)
        //{
        //    Session.Timeout = 60;
        //}

        protected void Application_Start()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var filePath = Server.MapPath("~/important_files/serviceAccountKey.json");
            var credential = GoogleCredential.FromFile(filePath);
            FirebaseApp.Create(new AppOptions() { Credential = credential });

            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            //// Allow other necessary headers and methods as needed
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
        }
    }
}
