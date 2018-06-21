using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace BilgeAdamSharing
{
    public class Global1 : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            SetRouteMaps(RouteTable.Routes);
        }

        private void SetRouteMaps(RouteCollection route)
        {
            route.MapPageRoute("AddShare", "AddShare", "~/Anasayfa.aspx");
            route.MapPageRoute("LogIn", "LogIn", "~/Default.aspx");
            route.MapPageRoute("AddSection", "AddSection", "~/BolumEkle.aspx");
            route.MapPageRoute("Sections", "Sections", "~/Bolumler.aspx");
            route.MapPageRoute("AddTrainer", "AddTrainer", "~/EgitmenEkle.aspx");
            route.MapPageRoute("Trainers", "Trainers", "~/Egitmenler.aspx");
            route.MapPageRoute("AddSubject", "AddSubject", "~/KonuEkle.aspx");
            route.MapPageRoute("Subjects", "Subjects", "~/Konular.aspx");
            route.MapPageRoute("Shares", "Shares", "~/Ogrenci.aspx");
            route.MapPageRoute("AddStudent", "AddStudent", "~/OgrenciEkle.aspx");
            route.MapPageRoute("Students", "Students", "~/Ogrenciler.aspx");
            route.MapPageRoute("AllShares", "AllShares", "~/Paylasimlar.aspx");
            route.MapPageRoute("UpdateProfile", "UpdateProfile", "~/ProfilGuncelle.aspx");
            route.MapPageRoute("AddClass", "AddClass", "~/SinifEkle.aspx");
            route.MapPageRoute("Classes", "Classes", "~/Siniflar.aspx");

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}