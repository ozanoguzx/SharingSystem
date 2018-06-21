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
    public partial class Siniflar : System.Web.UI.Page
    {
        ClassRepository islem = new ClassRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SuperUserId"] != null)
            {
                if (!IsPostBack)
                {
                    Doldur();
                }
            }
            else
            {
                Response.Redirect("AddShare");
            }
        }

        protected void GridviewSiniflar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridviewSiniflar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Classroom k = (Classroom)e.Row.DataItem;
                if (k.IsActive == true)
                {
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).ToolTip = "Pasif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).Text = "Pasif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).CssClass = "btn btn-danger btn-mini";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).OnClientClick = "return confirm('Kullanıcı Pasif Edilecek');";
                }
                else
                {
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).ToolTip = "Aktif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).Text = "Aktif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).CssClass = "btn btn-success btn-mini";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).OnClientClick = "return confirm('Kullanıcı Aktif Edilecek');";
                }


                int id;

                Label lblgelenid = (Label)e.Row.FindControl("lblID");
                Label lblsecid = (Label)e.Row.FindControl("Label1");
                Label lbltrgelenid = (Label)e.Row.FindControl("lbltr");
                DropDownList ddl1 = (DropDownList)e.Row.FindControl("dropdownBolum");
                DropDownList ddl2 = (DropDownList)e.Row.FindControl("dropdownEgitmen");
                Label lbldurum = (Label)e.Row.FindControl("lbldurum");

                SectionsRepository bolum = new SectionsRepository();
                TrainerRepository egitmen = new TrainerRepository();
                int sectionid = Convert.ToInt32(lblsecid.Text);
                Section sec = new Section();
                sec = bolum.TekGetir(sectionid);
                ddl1.DataSource = bolum.HepsiniGetir();
                ddl1.DataTextField = "Name";
                ddl1.DataValueField = "Id";
                ddl1.SelectedValue = sec.Id.ToString();
                ddl1.DataBind();
                int traineridd = Convert.ToInt32(lbltrgelenid.Text);
                Trainer tid = new Trainer();
                tid = egitmen.TekGetir(traineridd);
                ddl2.SelectedValue = tid.Id.ToString();
                ddl2.DataSource = egitmen.HepsiniGetir();
                ddl2.DataTextField = "FullName";
                ddl2.DataValueField = "Id";
                ddl2.DataBind();
            }
        }

        protected void GridviewSiniflar_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "aktif")
            {

                int userID = Convert.ToInt32(e.CommandArgument);

                

                Classroom c = islem.TekGetir(userID);


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
                    GridviewSiniflar.EditIndex = secilenSatir.RowIndex;
                    Doldur();


                    break;
                case "guncelle":


                    secilenSatir = (e.CommandSource as LinkButton).Parent.Parent as GridViewRow;
                    id = Convert.ToInt32(e.CommandArgument);

                    System.Web.UI.WebControls.DropDownList ddl1 = (System.Web.UI.WebControls.DropDownList)(secilenSatir.FindControl("dropdownBolum"));
                    System.Web.UI.WebControls.DropDownList ddl2 = (System.Web.UI.WebControls.DropDownList)(secilenSatir.FindControl("dropdownEgitmen"));
                    System.Web.UI.WebControls.TextBox txt4 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtAd"));
                    System.Web.UI.WebControls.TextBox txt5 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtAcilis"));
                    System.Web.UI.WebControls.TextBox txt6 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtKapanis"));

                    Classroom sinif = islem.TekGetir(id);
                    sinif.Id = id;
                    sinif.Name = txt4.Text;
                    sinif.ClosedDate = Convert.ToDateTime(txt6.Text);
                    sinif.CreatedDate= Convert.ToDateTime(txt5.Text);
                    sinif.TrainerID = Convert.ToInt32(ddl2.SelectedValue);
                    sinif.SectionID = Convert.ToInt32(ddl1.SelectedValue);

                    if (islem.Guncelle(sinif))
                    {
                        GridviewSiniflar.EditIndex = -1;
                        Doldur();
                    }



                    break;
                case "iptal":

                    GridviewSiniflar.EditIndex = -1;
                    Doldur();

                    break;

                default:
                    break;
            }

        }


        public void Doldur()
        {
            ClassRepository sinifİslem = new ClassRepository();
            GridviewSiniflar.DataSource = sinifİslem.HepsiniGetir().OrderByDescending(p=> p.CreatedDate);
            GridviewSiniflar.DataBind();
        }

    }
}