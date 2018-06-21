using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using System.IO;

namespace BilgeAdamSharing
{
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int gelenid = Convert.ToInt32(Request.QueryString["id"]);
            PresentationRepository islem = new PresentationRepository();
            Presentation sunum = islem.TekGetir(gelenid);
            string filePath = sunum.FileUrl;

            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }
    }
}