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
    public partial class Egitmenler : System.Web.UI.Page
    {
        TrainerRepository islem = new TrainerRepository();
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


                Trainer k = (Trainer)e.Row.DataItem;

                if (k.IsActive == true)
                {

                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).ToolTip = "Pasif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).Text = "Pasif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).ForeColor = System.Drawing.Color.Red;
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).OnClientClick = "return confirm('Kullanıcı Pasif Edilecek');";

                }
                else
                {

                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).ToolTip = "Aktif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).Text = "Aktif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).ForeColor = System.Drawing.Color.Green;
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).OnClientClick = "return confirm('Kullanıcı Aktif Edilecek');";

                }


                int id;

                Label lblsecid = (Label)e.Row.FindControl("Label1");
                Label lbltrgelenid = (Label)e.Row.FindControl("lbltr");
                DropDownList ddl1 = (DropDownList)e.Row.FindControl("dropdownBolum");
                Label lbldurum = (Label)e.Row.FindControl("lbldurum");

                SectionsRepository bolum = new SectionsRepository();
                int sectionid = Convert.ToInt32(lblsecid.Text);
                Section sec = new Section();
                sec = bolum.TekGetir(sectionid);
                ddl1.DataSource = bolum.HepsiniGetir();
                ddl1.DataTextField = "Name";
                ddl1.DataValueField = "Id";
                ddl1.SelectedValue = sec.Id.ToString();
                ddl1.DataBind();

            }
        }

        protected void GridviewSiniflar_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "aktif")
            {

                int userID = Convert.ToInt32(e.CommandArgument);



                Trainer c = islem.TekGetir(userID);


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
                    System.Web.UI.WebControls.TextBox txt4 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtAd"));
                    System.Web.UI.WebControls.TextBox txt5 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtAcilis"));
                    System.Web.UI.WebControls.TextBox txt6 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtSoyad"));
                    System.Web.UI.WebControls.TextBox txt7 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtusername"));
                    System.Web.UI.WebControls.TextBox txt8 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtmail"));

                    Trainer trainer = islem.TekGetir(id);
                    trainer.EMail = txt8.Text;
                    trainer.FirstName = txt4.Text;
                    trainer.LastName = txt6.Text;
                    trainer.Username = txt7.Text;
                    trainer.FullName = txt4.Text + "" + txt6.Text;
                    trainer.SectionID = Convert.ToInt32(ddl1.SelectedValue);

                    if (islem.Guncelle(trainer))
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
            List<Trainer> liste = islem.HepsiniGetir().OrderByDescending(p => p.CreatedDate).ToList();
            GridviewSiniflar.DataSource = liste;
            GridviewSiniflar.DataBind();
            LabelSayi.Text = String.Format("<span class='label label-info'><strong>{0}</strong></span> adet eğitmen listeleniyor... ", liste.Count);
        }

        protected void GridviewSiniflar_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridviewSiniflar.PageIndex = e.NewPageIndex;
            Doldur();
        }
    }
}