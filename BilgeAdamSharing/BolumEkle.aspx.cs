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
    public partial class BolumEkle : System.Web.UI.Page
    {
        SectionsRepository db = new SectionsRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            Section sc = new Section();
            try
            {
                sc.CreatedDate = DateTime.Now.ToLocalTime();
                if (chAktif.Checked==true)
                {
                    sc.IsActive = true;
                }
                else
                {
                    sc.IsActive =false;

                }
                sc.Name = txtBolum.Text;
                db.Ekle(sc);
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Bölüm başarıyla eklendi.','success');", true);
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