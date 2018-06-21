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
    public partial class OgrenciEkle : System.Web.UI.Page
    {
        TrainerRepository kullanici = new TrainerRepository();
        Trainer users = new Trainer();
        SectionsRepository bolumislem = new SectionsRepository();
        ClassRepository sinifislem = new ClassRepository();
        StudentRepository ogrenciislem = new StudentRepository();
        BasEntities db;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null || Session["SuperUserId"] != null)
                {
                    int gelenid;
                    if (Session["SuperUserId"] != null)
                    {
                        gelenid = Convert.ToInt32(Session["SuperUserId"]);
                    }
                    else
                    {
                        gelenid = Convert.ToInt32(Session["UserId"]);
                    }

                    users = kullanici.TekGetir(gelenid);
                    if (users.IsSuperAdmin == true)
                    {
                        DropDownListBolum.DataSource = bolumislem.Getir().Where(p => p.IsActive == true);
                        DropDownListBolum.DataValueField = "Id";
                        DropDownListBolum.DataTextField = "Name";
                        DropDownListBolum.DataBind();
                        DropDownListBolum.Items.Insert(0, new ListItem("Bölüm Seçiniz..", "0"));
                    }
                    else
                    {
                        DropDownListBolum.DataSource = bolumislem.Getir().Where(p => p.IsActive == true && p.Id == users.SectionID);
                        DropDownListBolum.DataValueField = "Id";
                        DropDownListBolum.DataTextField = "Name";
                        DropDownListBolum.DataBind();
                        DropDownListBolum.Items.Insert(0, new ListItem("Bölüm Seçiniz..", "0"));
                    }
                }

            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Student ogrenci = new Student();
                string yazi;
                ogrenci.FirstName = txtAd.Text;
                yazi = txtAd.Text.Substring(0, 2);
                ogrenci.LastName = txtSoyad.Text;
                ogrenci.Password = yazi.ToLower() + txtSoyad.Text.ToLower() + "123";
                ogrenci.UserName = yazi.ToLower() + "." + txtSoyad.Text.ToLower();
                ogrenci.SectionID = Convert.ToInt32(DropDownListBolum.SelectedValue);
                ogrenci.Email = txtMail.Text;
                if (chAktif.Checked == true)
                {
                    ogrenci.IsActive = true;
                }
                else
                {
                    ogrenci.IsActive = false;
                }

                db = new BasEntities();
                Classroom classroom = db.Classrooms.Find(Convert.ToInt32(DropDownListSinif.SelectedValue));
                ogrenci.Classrooms.Add(classroom);
                bool result = ogrenciislem.Ekle(ogrenci);
                if (result)
                {

                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Öğrenci başarıyla eklendi.','success');", true);
                    txtAd.Text = "";
                    txtSoyad.Text = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Bir hata oluştu.','error');", true);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void DropDownListBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["SuperUserId"] != null)
            {
                DropDownListSinif.DataSource = sinifislem.HepsiniGetir().Where(p => p.IsActive == true && p.SectionID == Convert.ToInt32(DropDownListBolum.SelectedValue));
                DropDownListSinif.DataValueField = "Id";
                DropDownListSinif.DataTextField = "Name";
                DropDownListSinif.DataBind();
                DropDownListSinif.Items.Insert(0, new ListItem("Sınıf Seçiniz..", "0"));
            }
            else if (Session["UserId"] != null)
            {
                int id = Convert.ToInt32(Session["UserId"]);
                DropDownListSinif.DataSource = sinifislem.HepsiniGetir().Where(p => p.IsActive == true && p.TrainerID == id);
                DropDownListSinif.DataValueField = "Id";
                DropDownListSinif.DataTextField = "Name";
                DropDownListSinif.DataBind();
                DropDownListSinif.Items.Insert(0, new ListItem("Sınıf Seçiniz..", "0"));
            }
        }
    }
}