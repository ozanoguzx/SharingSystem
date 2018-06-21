using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace BilgeAdamSharing
{
    public partial class Default : System.Web.UI.Page
    {
        BasEntities db = new BasEntities();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("UserId");
            Session.Remove("SuperUserId");
            Session.Remove("StudentID");
        }

        protected void ButtonGirisYap_Click(object sender, EventArgs e)
        {
            string email = TextboxUserNameEmail.Text;
            string pass = TextBoxSifre.Text;
            bool userNameMi = email.Contains("@") ? false : true;
            int ID = 0;
            var user = db.Trainers.Where(k => k.Username == email && k.Password == pass).FirstOrDefault();
            var user2 = db.Students.Where(k => k.Email == email && k.Password == pass).FirstOrDefault();
            if (user != null)
            {
                if (user.IsSuperAdmin==true)
                {
                    Session["SuperUserId"] = user.Id.ToString();
                }
                else
                {
                    Session["UserId"] = user.Id.ToString();
                }
                Session["UserName"] = user.FullName.ToString();
                Response.Redirect("AddShare");
            }
            else if (user2!=null)
            {
                Session["StudentID"] = user2.Id.ToString();
                Session["StudentName"] = user2.FirstName+"  "+user2.LastName.ToString();
                Response.Redirect("Shares");
            }
            else
            {

            }
            {
                TextBoxSifre.Text = TextboxUserNameEmail.Text = "";
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Hata();", true);
            }
        }
    }
}