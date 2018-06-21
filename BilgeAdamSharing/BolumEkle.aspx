<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="AddSection.cs" Inherits="BilgeAdamSharing.BolumEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Baslik" runat="server">
    Bölüm Ekle
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="İcerik" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        
        <ContentTemplate>  
    <section class="content_section">
       
                <div class="content row_spacer clearfix">
                    <div class="hm-tabs tabs1">

                        <ul class="tabs-body">
                            <li data-content="inbox" class="selected">
                                <div class="form_row clearfix">
                                    <div class="my_col_third">
                                        <label for="birthday_day">
                                            <span class="hm_field_name"><b>Bölüm Adı
                                                                        </b></span>
                                            <span class="hm_requires_star">*</span>
                                        </label>
                                        <asp:TextBox ID="txtBolum"   ClientIDMode="Static" PlaceHolder="Bölüm adı Giriniz" runat="server" Width="250" CssClass="form-control"  onfocus="isBlurred=true;" onblur="isBlurred=false;" />
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtBolum" runat="server" ErrorMessage="Boş geçilemez."></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="my_col_third">
                                        <label for="birthday_day">
                                            <span class="hm_field_name"><b>Aktif
                                                                        </b></span>
                                            <span class="hm_requires_star">*</span>
                                        </label>
                                         
                                        <asp:CheckBox ID="chAktif" runat="server"  CssClass="hizala"  />

                                    </div>
                                    <div class="my_col_third">
                                        <label for="birthday_day">
                                            <span class="hm_field_name"><b>
                                                                        </b></span>
                                            <span class="hm_requires_star">*</span>
                                        </label>
                                        <asp:Button OnClick="btnEkle_Click" ID="btnEkle"  Text="Ekle" CssClass="btn btn-default " runat="server" />
                                    </div>
                                    </div>
                                
                                <br />
                                
                                    
                                <br />
                                </div>
                   
                    </div>
         </section>
             </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnEkle" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>

