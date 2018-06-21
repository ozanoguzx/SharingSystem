using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BilgeAdamSharing
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        PresentationRepository islem = new PresentationRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CollectionPager1.DataSource = islem.HepsiniGetir();
                CollectionPager1.BindToControl = dtVeri;
                dtVeri.DataSource = CollectionPager1.DataSourcePaged;
                dtVeri.DataBind();
            }
        }

        protected void dtVeri_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //int ID = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "TrainerID").ToString());
            //int ID2 = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Subject").ToString());
            //string url = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "FileUrl").ToString());
            //SubjectRepository konuislem = new SubjectRepository();
            //SUBJECT konu = konuislem.TekGetir(ID2);
            //Label lblB = (Label)e.Item.FindControl("lblSubject");
            //lblB.Text = konu.SubjectName;
            //TrainerRepository gelentrainer = new TrainerRepository();
            //TRAINER gelen = new TRAINER();
            //gelen = gelentrainer.TekGetir(ID);
            //Label lblA = (Label)e.Item.FindControl("lblTrainer");
            //lblA.Text = gelen.FullName;
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