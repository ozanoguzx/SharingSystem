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
    public partial class Bolumler : System.Web.UI.Page
    {
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

        protected void GridviewBolumler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "aktif")
            {

                int userID = Convert.ToInt32(e.CommandArgument);



                Section c = islem.TekGetir(userID);


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
                    GridviewBolumler.EditIndex = secilenSatir.RowIndex;
                    Doldur();


                    break;
                case "guncelle":


                    secilenSatir = (e.CommandSource as LinkButton).Parent.Parent as GridViewRow;
                    id = Convert.ToInt32(e.CommandArgument);


                    System.Web.UI.WebControls.TextBox txt4 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtAd"));
                    System.Web.UI.WebControls.TextBox txt5 = (System.Web.UI.WebControls.TextBox)(secilenSatir.FindControl("txtAcilis"));


                    Section bolum = islem.TekGetir(id);
                    bolum.CreatedDate = Convert.ToDateTime(txt5.Text);
                    bolum.Name = txt4.Text;


                    if (islem.Guncelle(bolum))
                    {
                        GridviewBolumler.EditIndex = -1;
                        Doldur();
                    }



                    break;
                case "iptal":

                    GridviewBolumler.EditIndex = -1;
                    Doldur();

                    break;

                default:
                    break;
            }
        }

        protected void GridviewBolumler_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Section k = (Section)e.Row.DataItem;

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


            }
        }

        public void Doldur()
        {
            List<Section> liste = islem.HepsiniGetir().OrderByDescending(p => p.CreatedDate).ToList();
            GridviewBolumler.DataSource = liste;
            GridviewBolumler.DataBind();
            LabelSayi.Text = String.Format("Toplam" + "<span class='label label-info'><strong>{0}</strong></span> adet bölüm listeleniyor... ", liste.Count);
        }



        protected void GridviewBolumler_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridviewBolumler.PageIndex = e.NewPageIndex;
            Doldur();
        }
    }
}