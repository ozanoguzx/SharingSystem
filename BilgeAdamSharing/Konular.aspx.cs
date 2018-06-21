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
    public partial class KonuEkle : System.Web.UI.Page
    {
        SubjectRepository subislem = new SubjectRepository();
        SectionsRepository islem = new SectionsRepository();
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

        protected void GridviewKonular_RowDataBound(object sender, GridViewRowEventArgs e)
       {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Subject k = (Subject)e.Row.DataItem;

                if (k.IsActive == true)
                {

                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).ToolTip = "Pasif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).Text = "Pasif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).ForeColor = System.Drawing.Color.Red;
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).OnClientClick = "return confirm('Bölüm Pasif Edilecek');";

                }
                else
                {

                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).ToolTip = "Aktif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).Text = "Aktif Et";
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).ForeColor = System.Drawing.Color.Green;
                    (e.Row.FindControl("LinkbuttonAktif") as LinkButton).OnClientClick = "return confirm('Bölüm Aktif Edilecek');";

                }
                DropDownList ddl1 = (DropDownList)e.Row.FindControl("dropdownBolum");
                Label lbldurum = (Label)e.Row.FindControl("Label1");
                int sectionid = Convert.ToInt32(lbldurum.Text);
                Section sec = new Section();
                sec = islem.TekGetir(sectionid);
                ddl1.DataSource = islem.HepsiniGetir();
                ddl1.DataTextField = "Name";
                ddl1.DataValueField = "Id";
                ddl1.SelectedValue = sec.Id.ToString();
                ddl1.DataBind();

            }
        }

        protected void GridviewKonular_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "aktif")
            {

                int userID = Convert.ToInt32(e.CommandArgument);



                Subject c = subislem.TekGetir(userID);


                if (c.IsActive == true)
                {
                    if (subislem.DurumGuncelle(userID, false))
                        Doldur();
                }
                else
                {
                    if (subislem.DurumGuncelle(userID, true))
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
                    GridviewKonular.EditIndex = secilenSatir.RowIndex;
                    Doldur();


                    break;
                case "guncelle":


                    secilenSatir = (e.CommandSource as LinkButton).Parent.Parent as GridViewRow;
                    id = Convert.ToInt32(e.CommandArgument);

                    System.Web.UI.WebControls.Label lbl4 = (System.Web.UI.WebControls.Label)(secilenSatir.FindControl("Label1"));
                    System.Web.UI.WebControls.TextBox txt4 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtAd"));
                    System.Web.UI.WebControls.TextBox txt5 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtAcilis"));
                    System.Web.UI.WebControls.DropDownList ddl1 = (System.Web.UI.WebControls.DropDownList)(secilenSatir.FindControl("dropdownBolum"));


                   



                    Subject konu = subislem.TekGetir(id);
                    konu.CreatedDate = Convert.ToDateTime(txt5.Text);
                    konu.Name = txt4.Text;
                    konu.SectionID = Convert.ToInt32(ddl1.SelectedValue);


                    if (subislem.Guncelle(konu))
                    {
                        GridviewKonular.EditIndex = -1;
                        Doldur();
                    }



                    break;
                case "iptal":

                    GridviewKonular.EditIndex = -1;
                    Doldur();

                    break;

                default:
                    break;
            }
        }
        public void Doldur()
        {
            List<Subject> liste = subislem.HepsiniGetir().OrderByDescending(p => p.CreatedDate).ToList();
            GridviewKonular.DataSource = liste;
            GridviewKonular.DataBind();
            LabelSayi.Text = String.Format("<span class='label label-info'><strong>{0}</strong></span> adet konu listeleniyor... ", liste.Count);
        }

        protected void GridviewKonular_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridviewKonular.PageIndex = e.NewPageIndex;
            Doldur();
        }
    }
}