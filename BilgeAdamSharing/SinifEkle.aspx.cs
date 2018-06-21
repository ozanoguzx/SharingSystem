using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
namespace BilgeAdamSharing
{

    public partial class SinifEkle : System.Web.UI.Page
    {
        BasEntities db = new BasEntities();
        ClassRepository sinifislem = new ClassRepository();
        SectionsRepository bolumislem = new SectionsRepository();
        TrainerRepository trislem = new TrainerRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
           
                lblDurum.Text = "Sınıf Ekle";
            if (!IsPostBack)
            {
                DropDownListBolum.DataSource = bolumislem.Getir().Where(p => p.IsActive==true);
                DropDownListBolum.DataValueField = "Id";
                DropDownListBolum.DataTextField = "Name";
                DropDownListBolum.DataBind();
                DropDownListBolum.Items.Insert(0, new ListItem("Bölüm Seçiniz..", "0"));
                DropDownListEgitmen.DataSource = trislem.Getir().Where(p => p.IsActive==true) ;
                DropDownListEgitmen.DataValueField = "Id";
                DropDownListEgitmen.DataTextField = "FullName";
                DropDownListEgitmen.DataBind();
                DropDownListEgitmen.Items.Insert(0, new ListItem("Eğitmen Seçiniz..", "0"));
                
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string classname = txtSinif.Text;
                var user = db.Classrooms.Where(k => k.Name == classname).FirstOrDefault();
                if (user == null)
                {
                    Classroom sinif = new Classroom();
                    sinif.CreatedDate = Convert.ToDateTime(txtAcilisTarihi.Text);
                    sinif.ClosedDate = Convert.ToDateTime(txtKapanisTarihi.Text);
                    if (chAktif.Checked == true)
                    {
                        sinif.IsActive = true;
                    }
                    else
                    {
                        sinif.IsActive = false;
                    }
                    sinif.SectionID = Convert.ToInt32(DropDownListBolum.SelectedValue);
                    sinif.TrainerID = Convert.ToInt32(DropDownListEgitmen.SelectedValue);
                    sinif.Name = txtSinif.Text;
                    if (sinifislem.Ekle(sinif))
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Sınıf başarıyla eklendi.','success');", true);
                        txtAcilisTarihi.Text = "";
                        txtKapanisTarihi.Text = "";
                        txtSinif.Text = "";
                        DropDownListBolum.SelectedIndex = 0;
                        DropDownListEgitmen.SelectedIndex = 0;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Kaydedilirken hata oluştu.','error');", true);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Aynı sınıf mevcut.','error');", true);
                }
               
                

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}