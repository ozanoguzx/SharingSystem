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
    public partial class EgitmenEkle : System.Web.UI.Page
    {
        BasEntities db = new BasEntities();
        SectionsRepository bolumislem = new SectionsRepository();
        TrainerRepository trainerrep = new TrainerRepository();
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

        protected void chAktif_CheckedChanged(object sender, EventArgs e)
        {

        }


        protected void btnKullanici_Click(object sender, EventArgs e)
        {

          

            try
            {
                string egitmenmail = txtMailadmin.Text;
                var user = db.Trainers.Where(k => k.EMail == egitmenmail||k.Username==txtUsername.Text).FirstOrDefault();
                if (user == null)
                {
                    Trainer trainer = new Trainer();
                    trainer.CreatedDate = DateTime.Now.ToLocalTime();
                    trainer.EMail = txtMailadmin.Text;
                    if (chAktif.Checked = true)
                    {
                        trainer.IsActive = true;
                    }
                    else
                    {
                        trainer.IsActive = false;
                    }
                    trainer.LastName = txtSoyad.Text;
                    trainer.FirstName = txtAd.Text;
                    trainer.Password = txtSifreadmin.Text;
                    trainer.SectionID = Convert.ToInt32(DropDownListBolum.SelectedValue);
                    trainer.Username = txtUsername.Text;
                    trainer.FullName = txtAd.Text+ " "+ txtSoyad.Text;
                    if (trainerrep.Ekle(trainer))
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Eğitmen Başarıyla Kaydedildi.','success');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Bir Hata Oluştu','success');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Bu kullanıcı sisteme kayıtlıdır.','error');", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Bir Hata Oluştu','success');", true);
            }









        }

    }
}