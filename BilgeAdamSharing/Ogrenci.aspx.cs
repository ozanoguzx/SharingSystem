using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace BilgeAdamSharing
{
    public partial class Ogrenci : System.Web.UI.Page
    {
        PresentationRepository islem = new PresentationRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["StudentID"] != null)
                {
                    int gelenid = Convert.ToInt32(Session["StudentID"]);
                    Student gelenogr = new Student();
                    StudentRepository islemogrenci = new StudentRepository();
                    gelenogr = islemogrenci.TekGetir(gelenid);
                    //List<Presentation> gelenlist= islem.HepsiniGetir().Select(p => p.ClassroomID == gelenogr.Classrooms.Select(x=> x.Students.Select(s=> s.Id == gelenid)).ToList()).ToList();

                    var gelenlist = from prsen in islem.HepsiniGetir() 
                                                   where prsen.Student.Classrooms.Any(x => x.Id == prsen.ClassroomID) 
                                                   select prsen; 

                    CollectionPager1.DataSource = gelenlist;
                    CollectionPager1.BindToControl = dtVeri;
                    dtVeri.DataSource = CollectionPager1.DataSourcePaged;
                    dtVeri.DataBind(); 
                }
            }
        }
     
        protected void dtVeri_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int ID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TrainerID").ToString());
            int ID2 = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Subject").ToString());
            string url = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "FileUrl").ToString());
            SubjectRepository konuislem = new SubjectRepository();
            Subject konu = konuislem.TekGetir(ID2);
            Label lblB = (Label)e.Item.FindControl("lblSubject");
            lblB.Text = konu.Name;
            TrainerRepository gelentrainer = new TrainerRepository();
            Trainer gelen = new Trainer();
            gelen = gelentrainer.TekGetir(ID);
            Label lblA = (Label)e.Item.FindControl("lblTrainer");
            lblA.Text = gelen.FullName;
        }

        private void Lk_Click(object sender, EventArgs e)
        {
            Response.Write("sa");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
           
        }

        protected void TestObje(Object Sender, RepeaterCommandEventArgs e)
        {

            //if (e.CommandName == "Save")
            //{
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    string fName = "teste";
            //    Response.ContentType = "application/octet-stream";
            //    Response.AddHeader("Content-Disposition", "attachment;filename=" + fName);
            //    Response.TransmitFile(Server.MapPath(e.CommandArgument.ToString()));
            //    Response.End();
            //}
        }

        protected void dtVeri_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
        }
    }
}