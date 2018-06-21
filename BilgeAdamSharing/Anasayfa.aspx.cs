using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BilgeAdamSharing
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BasEntities db = new BasEntities();
        static string filePath;
        ClassRepository sinifislem = new ClassRepository();
        SectionsRepository bolumislem = new SectionsRepository();
        TrainerRepository kislem = new TrainerRepository();
        SubjectRepository konu = new SubjectRepository();
        PresentationRepository islem = new PresentationRepository();
        static int id;

        protected void Page_Load(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "uy3", "AjaxFileUpload_change_text();", true);
            if (Session["StudentID"]!=null)
            {
                Response.Redirect("Shares");
            }


            
            if (Session["UserId"] != null|| Session["SuperUserId"] != null)
            {
                
                if (Session["SuperUserId"] != null)
                {
                     id = Convert.ToInt32(Session["SuperUserId"]);
                }
                else
                {
                    id = Convert.ToInt32(Session["UserId"]);
                }
                
                Trainer gelen = kislem.TekGetir(id);
                if (DropDownListKonu.SelectedIndex >= 1 && (DropDownSinif.SelectedIndex >= 1 || DropDownTumSinif.SelectedIndex >= 1))
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "fyt4", "PanelUploadShow();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "fyt1", "Panel0Show();", true);

                }
                if (gelen != null)
                {
                    if (!IsPostBack)
                    {
                        DropDownListKonu.DataSource = konu.HepsiniGetir().Where(p => p.SectionID == gelen.SectionID);
                        DropDownListKonu.DataValueField = "Id";
                        DropDownListKonu.DataTextField = "Name";
                        DropDownListKonu.DataBind();
                        DropDownListKonu.Items.Insert(0, new ListItem("Konu Seçiniz..", "0"));
                        DropDownSinif.DataSource = sinifislem.HepsiniGetir().Where(p => p.IsActive == true && p.TrainerID == gelen.Id);
                        DropDownSinif.DataValueField = "Id";
                        DropDownSinif.DataTextField = "Name";
                        DropDownSinif.DataBind();
                        DropDownSinif.Items.Insert(0, new ListItem("Sınıf Seçiniz..", "0"));
                    }
                }
                else if (Session["StudentID"]!=null)
                {
                    Response.Redirect("LogIn");
                }
                else
                {
                    Response.Redirect("LogIn");
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Eğitmene ait sınıf yoktur.','success');", true);
                }

            }



        }

        protected void DropDownListBolum_SelectedIndexChanged(object sender, EventArgs e)
        {


            Session["BolumId"] = DropDownListKonu.SelectedValue;

        }
        protected void DropDownSinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Remove("SinifId");
            Session["SinifId"] = DropDownSinif.SelectedValue;
        }

        protected void DropDownTumSinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Remove("SinifId");
            Session["SinifId"] = DropDownTumSinif.SelectedValue;
        }

        protected void chTumSinif_CheckedChanged(object sender, EventArgs e)
        {
            if (DropDownTumSinif.Visible == false)
            {
                DropDownTumSinif.Visible = true;
                LBL.Visible = true;
                DropDownTumSinif.DataSource = sinifislem.HepsiniGetir().Where(p => p.IsActive == true);
                DropDownTumSinif.DataValueField = "ID";
                DropDownTumSinif.DataTextField = "Name";
                DropDownTumSinif.DataBind();
                DropDownTumSinif.Items.Insert(0, new ListItem("Sınıf Seçiniz..", "0"));
            }
            else
            {
                DropDownTumSinif.Visible = false;
                LBL.Visible = false;
            }
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {

            try
            {


                Presentation gonderi = new Presentation();
                gonderi.CreatedDate = DateTime.Now.ToLocalTime();
                gonderi.IsActive = true;
                gonderi.SubjectID = Convert.ToInt32(Session["BolumId"]);
                gonderi.ClassroomID = Convert.ToInt32(Session["SinifId"]);
                gonderi.FileName = e.FileName;
                int trainerid;
                if (Session["SuperUserId"] != null)
                {
                    trainerid = Convert.ToInt32(Session["SuperUserId"]);
                }
                else
                {
                    trainerid = Convert.ToInt32(Session["UserId"]);
                }
                Trainer gelen = kislem.TekGetir(trainerid);

                if (gelen != null)
                {
                    gonderi.TrainerID = gelen.Id;
                    gonderi.SectionID = Convert.ToInt32(gelen.SectionID);
                }
                string extension = e.FileName.Substring(e.FileName.LastIndexOf('.'));
                if (extension == ".txt" || extension == ".doc" || extension == ".pdf")
                {
                    
                    gonderi.FileUrl = "/Files/Documents/" + e.FileName;
                    filePath = "/Files/Documents/" + e.FileName;
                    AjaxFileUpload1.SaveAs(Server.MapPath(filePath));

                }
                else if (extension == ".jpg" || extension == ".png" || extension == ".gif" || extension == ".jpeg")
                {



                    gonderi.FileUrl = "/Files /Images / " + e.FileName;
                    filePath = "/Files/Images/" + e.FileName;
                    AjaxFileUpload1.SaveAs(Server.MapPath(filePath));
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "uy3", "Bilgilendirme('Dosya biçimi desteklenmiyor','error');", true);
                }
                else if (extension == ".rar" || extension == ".zip")
                {
                    gonderi.FileUrl = "/Files/Archiver/" + e.FileName;
                    filePath = "/Files/Archiver/" + e.FileName;
                    AjaxFileUpload1.SaveAs(Server.MapPath(filePath));

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "uy3", "Bilgilendirme('Dosya biçimi desteklenmiyor','error');", true);
                }


                if (islem.Ekle(gonderi))
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('Sınıf başarıyla eklendi.','success');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "js", "Bilgilendirme('HATA.','success');", true);
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void AjaxFileUpload1_UploadCompleteAll(object sender, AjaxControlToolkit.AjaxFileUploadCompleteAllEventArgs e)
        {

        }

        protected void AjaxFileUpload1_UploadStart(object sender, AjaxControlToolkit.AjaxFileUploadStartEventArgs e)
        {

        }

        //string OnlyFileName = e.FileName;
        //FileInfo uploadlanacak = new FileInfo(OnlyFileName);
        //FtpWebRequest ftpistek = (FtpWebRequest)WebRequest.Create("ftp://arizakombi.com/" + OnlyFileName);
        //ftpistek.Method = WebRequestMethods.Ftp.UploadFile;
        //ftpistek.Credentials = new NetworkCredential("arizakom", "WT6p15f8hi");
        //Stream ftpakım = ftpistek.GetRequestStream();
        //FileStream dosya = File.OpenRead(@"rizahanosman.com/Files/Documents/" + e.FileName);

        //int uzunluk = 1024;
        //byte[] buffer = new byte[uzunluk];
        //int okunanbayt = 0;
        //int OkunanBaytToplam = 0;
        //double progress_durum = 0;
        //int ToplamDonen = 0;
        //long boyutdd = dosya.Length;
        //do
        //{
        //    ToplamDonen++;
        //    okunanbayt = dosya.Read(buffer, 0, uzunluk);
        //    OkunanBaytToplam += okunanbayt;
        //    ftpakım.Write(buffer, 0, okunanbayt);

        //    double dIndex = (double)(OkunanBaytToplam);
        //    double dProgressPercentage = (dIndex / boyutdd);
        //    int iProgressPercentage = (int)(dProgressPercentage * 100);


        //}
        //while (okunanbayt != 0);
        //dosya.Close();
        //ftpakım.Close();


        private static void Upload(string ftpServer, string userName, string password, string filename)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                client.Credentials = new System.Net.NetworkCredential(userName, password);
                client.UploadFile(ftpServer + "/" + new FileInfo(filename).Name, "STOR", filename);
            }
        }


    }
}