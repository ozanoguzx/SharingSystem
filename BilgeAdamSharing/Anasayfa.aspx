<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="AddShare.cs" Inherits="BilgeAdamSharing.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
 

        .ajax__fileupload_fileItemInfo div.removeButton {
            width: 100px;
        }

        div.ajax__fileupload_uploadbutton {
            width: 120px;
        }

        .ajax__fileupload .ajax__fileupload_selectFileContainer {
            width: 110px;
        }

        .ajax__fileupload_selectFileContainer .ajax__fileupload_selectFileButton {
            width: 110px;
        }
    </style>
    <style>
        .ajax__fileupload, .ajax__fileupload_dropzone {
            height: 150px !important;
        }

        .ajax__fileupload {
            height: 300px !important;
        }
    </style>
     <script type="text/javascript">
     
         function Panel0Show() {
             document.getElementById("pnl0").style.display = "inline";
             document.getElementById("pnl50konu").style.display = "none";
             document.getElementById("pnl50sinif").style.display = "none";
             document.getElementById("pnlupload").style.display = "none";

         }
         function Panel50KonuShow() {
             document.getElementById("pnl0").style.display = "none";
             document.getElementById("pnl50konu").style.display = "inline";
             document.getElementById("pnl50sinif").style.display = "none";
             document.getElementById("pnlupload").style.display = "none";

         }
         function Panel50SinifShow() {
             document.getElementById("pnl0").style.display = "none";
             document.getElementById("pnl50konu").style.display = "none";
             document.getElementById("pnl50sinif").style.display = "inline";
             document.getElementById("pnlupload").style.display = "none";

         }
         function PanelUploadShow() {
             document.getElementById("pnl0").style.display = "none";
             document.getElementById("pnl50konu").style.display = "none";
             document.getElementById("pnl50sinif").style.display = "none";
             document.getElementById("pnlupload").style.display = "inline";

         }
          </script>
    <script type="text/javascript">
        $(document).ready(function () {
            AjaxFileUpload_change_text();

        });
        function AjaxFileUpload_change_text() {
            Sys.Extended.UI.Resources.AjaxFileUpload_SelectFile = "Dosya Yükle";
            Sys.Extended.UI.Resources.AjaxFileUpload_DropFiles = "Dosya yüklemek için sürükle.";
            Sys.Extended.UI.Resources.AjaxFileUpload_Pending = "bekleniyor";
            Sys.Extended.UI.Resources.AjaxFileUpload_Remove = "Sil";
            Sys.Extended.UI.Resources.AjaxFileUpload_Upload = "Yükle";
            Sys.Extended.UI.Resources.AjaxFileUpload_Uploaded = "Yüklendi";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadedPercentage = "yüklendi {0} %";
            Sys.Extended.UI.Resources.AjaxFileUpload_Uploading = "Uploading";
            Sys.Extended.UI.Resources.AjaxFileUpload_FileInQueue = "{0} dosya seçildi.";
            Sys.Extended.UI.Resources.AjaxFileUpload_AllFilesUploaded = "Tüm dosyalar başarıyla yüklendi.";
            Sys.Extended.UI.Resources.AjaxFileUpload_FileList = "Yüklenen dosyalar:";
            Sys.Extended.UI.Resources.AjaxFileUpload_SelectFileToUpload = "Dosya Seçilmedi.";
            Sys.Extended.UI.Resources.AjaxFileUpload_Cancelling = "İptal Ediliyor...";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadError = "Yükleme esnasında hata oluştu.";
            Sys.Extended.UI.Resources.AjaxFileUpload_CancellingUpload = "İptal Ediliyor...";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadingInputFile = "Yüklenen dosya: {0}.";
            Sys.Extended.UI.Resources.AjaxFileUpload_Cancel = "İptal";
            Sys.Extended.UI.Resources.AjaxFileUpload_Canceled = "iptal edildi";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadCanceled = "dosya yükleme iptal edildi";
            Sys.Extended.UI.Resources.AjaxFileUpload_DefaultError = "Dosya yükleme hatası";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadingHtml5File = "Dosya yükleniyor: {0} of size {1} bytes.";
            Sys.Extended.UI.Resources.AjaxFileUpload_error = "hata";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Baslik" runat="server">
    <asp:Label Text="Dosya Paylaş" Style="font-family: Arial" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="İcerik" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <section class="content_section">
        <div class="content row_spacer clearfix">
            <div class="hm-tabs tabs1">

                <ul class="tabs-body">
                    <li data-content="inbox" class="selected">
                        <div class="form_row clearfix">
                            <div class="my_col_third">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <label for="birthday_day">
                                            <span class="hm_field_name"><b>KONU
                                            </b></span>
                                            <span class="hm_requires_star">*</span>
                                        </label>
                                        <asp:DropDownList ID="DropDownListKonu" ValidationGroup="vd" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="DropDownListBolum_SelectedIndexChanged" CssClass="hizala" runat="server"></asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DropDownListKonu" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>       
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="my_col_third">
                                        <label for="birthday_day">
                                            <span class="hm_field_name"><b>SINIF</b></span>
                                            <span class="hm_requires_star">*</span>
                                        </label>
                                        <label>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ValidationGroup="vd" ID="DropDownSinif" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="DropDownSinif_SelectedIndexChanged" CssClass="hizala" runat="server"></asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="DropDownSinif" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <br />
                                            <asp:CheckBox OnCheckedChanged="chTumSinif_CheckedChanged" Font-Size="medium" ID="chTumSinif" Text="" AutoPostBack="true" runat="server" />
                                            Tüm sınıfları listele
                                            
                                        </label>

                                    </div>
                                    <div class="my_col_third">
                                        <asp:Panel Visible="false" ID="LBL" runat="server">
                                            <label for="birthday_day">
                                                <span class="hm_field_name"><b>TÜM SINIFLAR</b></span>
                                                <span class="hm_requires_star">*</span>
                                            </label>
                                        </asp:Panel>
                                        <label>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList Visible="false" ID="DropDownTumSinif" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="DropDownTumSinif_SelectedIndexChanged" CssClass="dropdown" runat="server"></asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="DropDownTumSinif" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </label>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="chTumSinif" EventName="CheckedChanged" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>
                        <asp:Label Text="" ID="lblDurum" runat="server" />
                        <div class="form_row clearfix">
                            <div class="my_col_full">
                                
                            <asp:Panel ID="pnlupload" ClientIDMode="Static" runat="server">  
                                
                                <asp:UpdatePanel   UpdateMode="Conditional" runat="server">
                                    <ContentTemplate> 
                                        <cc1:AjaxFileUpload   ValidationGroup="vd" ID="AjaxFileUpload1" runat="server" OnUploadComplete="AjaxFileUpload1_UploadComplete" ThrobberID="myThrobber" MaximumNumberOfFiles="10" OnUploadStart="AjaxFileUpload1_UploadStart" OnUploadCompleteAll="AjaxFileUpload1_UploadCompleteAll" AllowedFileTypes="jpg,jpeg,rar,pdf,txt,zip" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="AjaxFileUpload1" EventName="UploadStart" />
                                         <asp:AsyncPostBackTrigger ControlID="AjaxFileUpload1" EventName="UploadCompleteAll" />
                                        <asp:AsyncPostBackTrigger  ControlID="AjaxFileUpload1" EventName="UploadComplete"  />
                                    </Triggers>
                                </asp:UpdatePanel>
                                </asp:Panel>


                                       <asp:Panel ClientIDMode="Static" ID="pnl0"   runat="server">
                            <div class="progress_bar" data-progress-val="100" data-progress-animation="easeOutQuad" data-progress-delay="0" data-progress-color="#00BFFF">
						<div class="fill_con">
							<div class="fill">
								<span class="title">DOSYA PAYLAŞMAK İÇİN KONU VE SINIF SEÇİNİZ</span>
								
							</div>
						</div>
					</div>
                        </asp:Panel>
                                       <asp:Panel ClientIDMode="Static" ID="pnl50konu"   runat="server">
                            <div class="progress_bar" data-progress-val="50" data-progress-animation="easeOutQuad" data-progress-delay="500" data-progress-color="#64FE2E">
						<div class="fill_con">
							<div class="fill">
								<span class="title">LÜTFEN SINIF SEÇİMİ YAPINIZ.</span>
								<span class="value"><span class="num"></span><span>%</span></span>
							</div>
						</div>
					</div>
                        </asp:Panel>
                                       <asp:Panel ClientIDMode="Static" ID="pnl50sinif"   runat="server">
                            <div class="progress_bar" data-progress-val="50" data-progress-animation="easeOutQuad" data-progress-delay="500" data-progress-color="#64FE2E">
						<div class="fill_con">
							<div class="fill">
								<span class="title">LÜTFEN KONU SEÇİMİ YAPINIZ.</span>
								
							</div>
						</div>
					</div>
                        </asp:Panel>
                            </div>
                        </div>

                       
                        

                </ul>
            </div>
        </div>
    </section>

</asp:Content>
