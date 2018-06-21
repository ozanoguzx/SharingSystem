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
    public partial class Konular : System.Web.UI.Page
    {
        SubjectRepository islem = new SubjectRepository();
        SectionsRepository bolumislem = new SectionsRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListBolum.DataSource = bolumislem.Getir().Where(p => p.IsActive == true);
                DropDownListBolum.DataValueField = "Id";
                DropDownListBolum.DataTextField = "Name";
                DropDownListBolum.DataBind();
                DropDownListBolum.Items.Insert(0, new ListItem("Bölüm Seçiniz..", "0"));
            }
           

        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            Subject sc = new Subject();
            try
            {
                sc.CreatedDate = DateTime.Now.ToLocalTime();
                if (chAktif.Checked == true)
                {
                    sc.IsActive = true;
                }
                else
                {
                    sc.IsActive = false;

                }
                sc.SectionID = Convert.ToInt32(DropDownListBolum.SelectedValue);
                sc.Name = txtBolum.Text;
                islem.Ekle(sc);
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Konu başarıyla eklendi.','success');", true);
                txtBolum.Text = "";
                chAktif.Checked = false;

            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Kaydedilirken bir hata oluştu.','error');", true);
            }
        }
    }
}