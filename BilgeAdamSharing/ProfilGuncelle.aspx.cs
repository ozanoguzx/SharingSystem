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
    public partial class ProfilGuncelle : System.Web.UI.Page
    {
        BasEntities db = new BasEntities();
        StudentRepository islem = new StudentRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["StudentID"] != null)
                {
                    Doldur();
                }
            }
           
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtGuncelleSifre.Text!=txtTekrar.Text)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Şifreler uyuşmuyor.','error');", true);
            }
            else
            {
                string sifre = txtGuncelleSifre.Text;
                if (sifre.Length<6)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Lütfen en az 6 karakter giriniz.','error');", true);
                }
                else
                {
                    Student sifres = new Student();
                    int gelenid = Convert.ToInt32(Session["StudentID"]);
                    sifres.Id = gelenid;
                    sifres.Password = sifre;
                    if (islem.SifreGuncelle(sifres))
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Şifre Başarıyla Güncellendi.','success');", true);
                    }
                    
                }
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            string mail = txtMail.Text;
            var user = db.Students.Where(k => k.Email ==mail).FirstOrDefault();
            if (user!=null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Bu mail adresi kullanılıyor,lütfen farklı bir adres giriniz.','error');", true);
            }
            else
            {
                Student guncellenecek = new Student();
                int gelenid = Convert.ToInt32(Session["StudentID"]);
                guncellenecek.Id = gelenid;
                guncellenecek.FirstName = txtAd.Text;
                guncellenecek.LastName = txtSoyad.Text;
                guncellenecek.Email = txtMail.Text;
                if (islem.DetayGuncelle(guncellenecek))
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Profil Başarıyla Güncellendi.','success');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Hata oluştu.','error');", true);
                }
            }
           
            
        }

        public void Doldur()
        {
            int gelenid = Convert.ToInt32(Session["StudentID"]);
            Student s = new Student();
            s = islem.TekGetir(gelenid);
            txtAd.Text = s.FirstName;
            txtSoyad.Text = s.LastName;
            txtMail.Text = s.Email;
        }
       

        protected void btnSifre_Click(object sender, EventArgs e)
        {
            if (pnlSifreGuncelle.Visible == false)
            {
                pnlSifreGuncelle.Visible = true;
            }
            else
            {
                pnlSifreGuncelle.Visible = false;
            }
        }
    }
}