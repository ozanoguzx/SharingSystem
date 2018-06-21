<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="AddStudent.cs" Inherits="BilgeAdamSharing.OgrenciEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Baslik" runat="server">
    Öğrenci Ekle
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="İcerik" runat="server">
    <section class="content_section">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="content row_spacer clearfix">
            <div class="hm-tabs tabs1">

                <ul class="tabs-body">
                    <li data-content="inbox" class="selected">
                        <div class="form_row clearfix">
                            

                            <div class="my_col_third">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <label for="birthday_day">
                                            <span class="hm_field_name"><b>Bölüm
                                            </b></span>
                                            <span class="hm_requires_star">*</span>
                                        </label>
                                        <asp:DropDownList ID="DropDownListBolum" OnSelectedIndexChanged="DropDownListBolum_SelectedIndexChanged" ClientIDMode="Static" AutoPostBack="true" CssClass="dropdown" runat="server"></asp:DropDownList>
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="DropDownListBolum" InitialValue="0" ErrorMessage="Lütfen Bölüm Seçiniz" />

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DropDownListBolum" EventName="SelectedIndexChanged" />

                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>


                            <div class="my_col_third">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <label for="birthday_day">
                                            <span class="hm_field_name"><b>Sınıf
                                            </b></span>
                                            <span class="hm_requires_star">*</span>
                                        </label>
                                        <asp:DropDownList ID="DropDownListSinif" ClientIDMode="Static" AutoPostBack="true" CssClass="dropdown" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListSinif" InitialValue="0" ErrorMessage="Lütfen Sınıf Seçiniz" />
                                    </ContentTemplate>

                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DropDownListSinif" EventName="SelectedIndexChanged" />

                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                        <div class="form_row clearfix">
                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Ad
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox runat="server" placeholder="Ad" ID="txtAd" Width="200" CssClass="form-control" ClientIDMode="Static" />
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtAd" runat="server" ErrorMessage="Boş geçilemez."></asp:RequiredFieldValidator>
                            </div>
                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Soyad
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox runat="server" placeholder="Soyad" ID="txtSoyad" Width="200" CssClass="form-control" ClientIDMode="Static" />
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtSoyad" runat="server" ErrorMessage="Boş geçilemez."></asp:RequiredFieldValidator>
                            </div>
                            
                            

                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Email
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" placeholder="Email" Width="200"  ID="txtMail" CssClass="form-control" ClientIDMode="Static" />
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtMail" runat="server" ErrorMessage="Boş geçilemez."></asp:RequiredFieldValidator>
                                        
                                    </ContentTemplate>
                                    <Triggers>
                                        
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        
                                        <div style="margin-bottom:20px">
                                            
                                        Aktif
                                        <asp:CheckBox ID="chAktif" runat="server" CssClass="hizala" />
                                            <asp:Button OnClick="btnEkle_Click" ID="btnEkle" Style="margin-left: 220px" Text="Ekle" CssClass="btn btn-default " runat="server" />
                                            </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnEkle" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="chAktif" EventName="CheckedChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            
                        </div>
            </div>
            <br />
            <br />

        </div>

    </section>
</asp:Content>
