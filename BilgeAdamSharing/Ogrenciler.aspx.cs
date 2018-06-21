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
    public partial class Ogrenciler : System.Web.UI.Page
    {
        StudentRepository islem = new StudentRepository();
        ClassRepository sinifislem = new ClassRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["SuperUserId"] != null)
            {
                if (!IsPostBack)
                {
                    SinifDoldur();
                }
            }
            else if (Session["UserId"] != null)
            {
                if (!IsPostBack)
                {
                    SinifDoldur1();
                }
            }
            else
            {
                Response.Redirect("AddShare");
            }
        }

        protected void GridviewOgrenciler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "aktif")
            {

                int userID = Convert.ToInt32(e.CommandArgument);



                Student c = islem.TekGetir(userID);


                if (c.IsActive == true)
                {
                    if (islem.DurumGuncelle(userID, false))
                        Doldur();
                }
                else
                {
                    if (islem.DurumGuncelle(userID, true))
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
                    GridviewOgrenciler.EditIndex = secilenSatir.RowIndex;
                    Doldur();


                    break;
                case "guncelle":


                    secilenSatir = (e.CommandSource as LinkButton).Parent.Parent as GridViewRow;
                    id = Convert.ToInt32(e.CommandArgument);

                    System.Web.UI.WebControls.DropDownList ddl1 = (System.Web.UI.WebControls.DropDownList)(secilenSatir.FindControl("dropdownBolum"));
                    System.Web.UI.WebControls.DropDownList ddl2 = (System.Web.UI.WebControls.DropDownList)(secilenSatir.FindControl("dropdownSinif"));
                    System.Web.UI.WebControls.TextBox txt4 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtAd"));
                    System.Web.UI.WebControls.TextBox txt5 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtSoyad"));
                    System.Web.UI.WebControls.TextBox txt6 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtmail"));
                    System.Web.UI.WebControls.TextBox txt8 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtpassword"));

                    Student ogr = islem.TekGetir(id);
                    ogr.Id = id;
                    ogr.CreatedDate = DateTime.Now;
                    ogr.Email = txt6.Text;
                    ogr.FirstName = txt4.Text;
                    ogr.LastName = txt5.Text;
                    ogr.Password = txt8.Text;
                    ogr.SectionID = Convert.ToInt32(ddl1.SelectedValue);


                    if (islem.Guncelle(ogr))
                    {
                        GridviewOgrenciler.EditIndex = -1;
                        Doldur();
                    }



                    break;
                case "iptal":

                    GridviewOgrenciler.EditIndex = -1;
                    Doldur();

                    break;

                default:
                    break;
            }
        }

        protected void GridviewOgrenciler_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Student k = (Student)e.Row.DataItem;

                if (k.IsActive == true)
                {
                    //(e.Row.FindControl("LinkbuttonAktif") as LinkButton).ToolTip = "Pasif Et";
                    //(e.Row.FindControl("LinkbuttonAktif") as LinkButton).Text = "Pasif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).CssClass = "btn btn-danger btn-mini";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).OnClientClick = "return confirm('Kullanıcı Pasif Edilecek');";
                }
                else
                {
                    //(e.Row.FindControl("LinkbuttonAktif") as LinkButton).ToolTip = "Aktif Et";
                    //(e.Row.FindControl("LinkbuttonAktif") as LinkButton).Text = "Aktif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).CssClass = "btn btn-success btn-mini";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).OnClientClick = "return confirm('Kullanıcı Aktif Edilecek');";
                }
                int id;

                Label lblgelenid = (Label)e.Row.FindControl("lblID");
                Label lblsecid = (Label)e.Row.FindControl("Label1");
                Label lblsinifid = (Label)e.Row.FindControl("lbltr");
                DropDownList ddl1 = (DropDownList)e.Row.FindControl("dropdownBolum");
                DropDownList ddl2 = (DropDownList)e.Row.FindControl("dropdownSinif");
                Label lbldurum = (Label)e.Row.FindControl("lbldurum");

                SectionsRepository bolum = new SectionsRepository();
                ClassRepository sinifRepo = new ClassRepository();
                int sectionid = Convert.ToInt32(lblsecid.Text);
                Section sec = new Section();
                sec = bolum.TekGetir(sectionid);
                ddl1.DataSource = bolum.HepsiniGetir();
                ddl1.DataTextField = "Name";
                ddl1.DataValueField = "Id";
                ddl1.SelectedValue = sec.Id.ToString();
                ddl1.DataBind();
                int traineridd = Convert.ToInt32(lblsinifid.Text);
                Classroom tid = new Classroom();
                tid = sinifRepo.TekGetir(traineridd);
                ddl2.DataSource = sinifRepo.HepsiniGetir();
                ddl2.DataTextField = "Name";
                ddl2.DataValueField = "Id";
                ddl2.SelectedValue = tid.Id.ToString();
                ddl2.DataBind();
            }
        }

        public void Doldur()
        {
            GridviewOgrenciler.DataSource = islem.HepsiniGetir().Where(s => s.Classrooms.Any(c => c.Id == Convert.ToInt32(DropDownListSinif.SelectedValue))).ToList();
            GridviewOgrenciler.DataBind();
        }
        public void Doldur1()
        {
            int id = Convert.ToInt32(Session["UserId"]);
            GridviewOgrenciler.DataSource = islem.HepsiniGetir().Select(p => p.Classrooms.Select(s=> s.Id == id)).ToList();
            GridviewOgrenciler.DataBind();
        }

        public void SinifDoldur()
        {
            DropDownListSinif.DataSource = sinifislem.HepsiniGetir();
            DropDownListSinif.DataValueField = "Id";
            DropDownListSinif.DataTextField = "Name";
            DropDownListSinif.DataBind();
            DropDownListSinif.Items.Insert(0, new ListItem("Sınıf Seçiniz..", "0"));
        }
        public void SinifDoldur1()
        {
            int id = Convert.ToInt32(Session["UserId"]);
            DropDownListSinif.DataSource = sinifislem.HepsiniGetir().Where(p => p.TrainerID==id);
            DropDownListSinif.DataValueField = "Id";
            DropDownListSinif.DataTextField = "Name";
            DropDownListSinif.DataBind();
            DropDownListSinif.Items.Insert(0, new ListItem("Sınıf Seçiniz..", "0"));
        }

        protected void GridviewOgrenciler_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridviewOgrenciler.PageIndex = e.NewPageIndex;
            Doldur();
        }


        protected void DropDownListSinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["SuperUserId"] != null)
            {
                    Doldur();
            }
            else if (Session["UserId"] != null)
            {
                    Doldur1();
            }
        }
    }
}