using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BilgeAdamSharing
{
    public partial class Paylasimlar : System.Web.UI.Page
    {

        PresentationRepository sunumislem = new PresentationRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SuperUserId"] != null)
            {
                if (!IsPostBack)
                {
                    Doldur();
                }
            }
            else if (Session["UserId"] != null)
            {
                if (!IsPostBack)
                {
                    Doldur1();
                }
            }
            else
            {
                Response.Redirect("AddShare");
            }
        }

        protected void GridviewPaylasimlar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "aktif")
            {

                int userID = Convert.ToInt32(e.CommandArgument);



                Presentation c = sunumislem.TekGetir(userID);


                if (c.IsActive == true)
                {
                    if (sunumislem.DurumGuncelle(userID, false))
                        Doldur();
                }
                else
                {
                    if (sunumislem.DurumGuncelle(userID, true))
                        Doldur();
                }
            }

            GridViewRow secilenSatir;
            int id;


            switch (e.CommandName)
            {
                case "duzenle":

                    secilenSatir = (e.CommandSource as LinkButton).Parent.Parent as GridViewRow;
                    id = Convert.ToInt32(e.CommandArgument);
                    GridviewPaylasimlar.EditIndex = secilenSatir.RowIndex;
                    Doldur();


                    break;
                case "kaydet":


                    //int belgeId = Convert.ToInt32(e.CommandArgument);
                    //PRESENTATION c = sunumislem.TekGetir(belgeId);
                    //string yol = "";
                    //yol = c.FileUrl;
                    //string filePath = yol;
                    //Response.ContentType = ContentType;
                    //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(yol));
                    //Response.WriteFile(yol);
                    //Response.End();

                    break;
                case "guncelle":


                    secilenSatir = (e.CommandSource as LinkButton).Parent.Parent as GridViewRow;
                    id = Convert.ToInt32(e.CommandArgument);

                    System.Web.UI.WebControls.DropDownList ddl1 = (System.Web.UI.WebControls.DropDownList)(secilenSatir.FindControl("dropDownKonu"));
                    System.Web.UI.WebControls.DropDownList ddl2 = (System.Web.UI.WebControls.DropDownList)(secilenSatir.FindControl("dropDownSinif"));
                    System.Web.UI.WebControls.TextBox txt5 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtAcilis"));

                    Presentation sunum2 = sunumislem.TekGetir(id);
                    sunum2.CreatedDate = Convert.ToDateTime(txt5.Text);
                    sunum2.ClassroomID = Convert.ToInt32(ddl2.SelectedValue);
                    sunum2.SubjectID = Convert.ToInt32(ddl1.SelectedValue);


                    if (sunumislem.Guncelle(sunum2))
                    {
                        GridviewPaylasimlar.EditIndex = -1;
                        Doldur();
                    }



                    break;
                case "iptal":

                    GridviewPaylasimlar.EditIndex = -1;
                    Doldur();

                    break;

                default:
                    break;
            }

        }

        protected void GridviewPaylasimlar_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Presentation k = (Presentation)e.Row.DataItem;

                if (k.IsActive == true)
                {
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).CssClass = "btn btn-danger btn-mini";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).OnClientClick = "return confirm('Sunum Pasif Edilecek');";
                }
                else
                {
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).CssClass = "btn btn-success btn-mini";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).OnClientClick = "return confirm('Sunum Aktif Edilecek');";
                }

                (e.Row.FindControl("LinkbuttonKaydet") as LinkButton).CssClass = "btn btn-info btn-mini";
                int id;

                Label lblgelenid = (Label)e.Row.FindControl("lblID");
                Label lblsecid = (Label)e.Row.FindControl("Label1");
                Label lbltrgelenid = (Label)e.Row.FindControl("lbltr");
                DropDownList ddl1 = (DropDownList)e.Row.FindControl("dropDownKonu");
                DropDownList ddl2 = (DropDownList)e.Row.FindControl("dropDownSinif");
                Label lbldurum = (Label)e.Row.FindControl("lbldurum");

                SubjectRepository konu = new SubjectRepository();
                ClassRepository sinif = new ClassRepository();
                int subjectid = Convert.ToInt32(lblsecid.Text);
                if (subjectid > 0)
                {
                    Subject sec = new Subject();
                    sec = konu.TekGetir(subjectid);
                    ddl1.DataSource = konu.HepsiniGetir();
                    ddl1.DataTextField = "Name";
                    ddl1.DataValueField = "Id";
                    ddl1.SelectedValue = sec.Id.ToString();
                    ddl1.DataBind();
                }

                int classid = Convert.ToInt32(lbltrgelenid.Text);
                Classroom tid = new Classroom();
                tid = sinif.TekGetir(classid);
                ddl2.SelectedValue = tid.Id.ToString();
                ddl2.DataSource = sinif.HepsiniGetir();
                ddl2.DataTextField = "Name";
                ddl2.DataValueField = "Id";
                ddl2.DataBind();
            }
        }


        public void Doldur()
        {
            SubjectRepository konuislem = new SubjectRepository();
            GridviewPaylasimlar.DataSource = sunumislem.HepsiniGetir();
            GridviewPaylasimlar.DataBind();
        }

        public void Doldur1()
        {
            int id = Convert.ToInt32(Session["UserId"]);
            SubjectRepository konuislem = new SubjectRepository();
            GridviewPaylasimlar.DataSource = sunumislem.HepsiniGetir().Where(p => p.TrainerID == id).ToList();
            GridviewPaylasimlar.DataBind();
        }

        protected void LinkButtonKaydet_Click(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;

            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        protected void GridviewPaylasimlar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridviewPaylasimlar.PageIndex = e.NewPageIndex;
            if (Session["UserId"] != null)
            {
                Doldur1();
            }
            else
            {
                Doldur();
            }

               
        }
    }
}