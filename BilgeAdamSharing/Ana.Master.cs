using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace BilgeAdamSharing
{
    public partial class Ana : System.Web.UI.MasterPage
    {
        BasEntities db = new BasEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                int gelenid = Convert.ToInt32(Session["UserId"]);
                var user = db.Trainers.Find(gelenid);
                    PanelAdmin.Visible = true;
               
                lblAdmin.Text = Session["UserName"].ToString();
            }
            else if (Session["SuperUserId"] != null)
            {
                int gelenid = Convert.ToInt32(Session["SuperUserId"]);
                var user = db.Trainers.Find(gelenid);
                PanelSuperAdmin.Visible = true;
                lblAdmin.Text = Session["UserName"].ToString();
            }
            else if (Session["StudentID"] != null)
            {
                int gelenid = Convert.ToInt32(Session["StudentID"]);
                var user = db.Students.Find(gelenid);
                PanelOgrenci.Visible = true;
                lblAdmin.Text = Session["StudentName"].ToString();
            }
            else
            {
                Response.Redirect("LogIn");


            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Session.Remove("UserId");
            Session.Remove("SuperUserId");
            Session.Remove("StudentID");
            Response.Redirect("LogIn");
        }
    }
}