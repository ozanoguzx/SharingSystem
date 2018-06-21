<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.cs" Inherits="BilgeAdamSharing.ProfilGuncelle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Baslik" runat="server">
    Profili Düzenle
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
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Ad
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox ValidationGroup="detay" runat="server" placeholder="Ad" ID="txtAd" Width="200" CssClass="form-control" ClientIDMode="Static" />
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtAd" runat="server" ErrorMessage="Boş geçilemez."></asp:RequiredFieldValidator>
                            </div>
                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Soyad
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox ValidationGroup="detay" runat="server" placeholder="Soyad" ID="txtSoyad" Width="200" CssClass="form-control" ClientIDMode="Static" />
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
                                        <asp:TextBox runat="server" ValidationGroup="detay" placeholder="Email" Width="200" ID="txtMail" CssClass="form-control" ClientIDMode="Static" />
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtMail" runat="server" ErrorMessage="Boş geçilemez."></asp:RequiredFieldValidator>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div style="margin-bottom: 20px">
                                            <asp:Button ValidationGroup="detay" OnClick="btnEkle_Click" ID="btnEkle" Style="margin-left: 220px" Text="Güncelle" CssClass="btn btn-success " runat="server" />
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnEkle" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </div>



                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ValidationGroup="s" ID="btnSifre" OnClick="btnSifre_Click" Text="Şifre Güncelle" runat="server" />
                                <asp:Panel ID="pnlSifreGuncelle" Visible="false" runat="server">
                                    <div class="form_row clearfix">
                                        <div class="my_col_third">
                                            <label for="birthday_day">
                                                <span class="hm_field_name"><b>Yeni Şifre
                                                </b></span>
                                                <span class="hm_requires_star">*</span>
                                            </label>
                                            <asp:TextBox ValidationGroup="sifre" runat="server" TextMode="Password" placeholder="Şifre" ID="txtGuncelleSifre" Width="200" CssClass="form-control" ClientIDMode="Static" />
                                             <asp:RequiredFieldValidator ValidationGroup="sifre" ID="RequiredFieldValidator32" ControlToValidate="txtGuncelleSifre" runat="server" ErrorMessage="Boş geçilemez."></asp:RequiredFieldValidator>
                                            <cc1:PasswordStrength ID="PS" runat="server"
                                                TargetControlID="txtGuncelleSifre"
                                                DisplayPosition="RightSide"
                                                StrengthIndicatorType="Text"
                                                PreferredPasswordLength="10"
                                                PrefixText="Güvenlik:"
                                                TextCssClass="TextIndicator_TextBox1"
                                                MinimumNumericCharacters="0"
                                                MinimumSymbolCharacters="0"
                                                RequiresUpperAndLowerCaseCharacters="false"
                                                TextStrengthDescriptions="Düşük;Orta;İyi;Güçlü;Çok Güçlü"
                                                TextStrengthDescriptionStyles="cssClass1;cssClass2;cssClass3;cssClass4;cssClass5"
                                                CalculationWeightings="50;15;15;20" />
                                            <br />

                                        </div>

                                        <div class="my_col_third">
                                            <label for="birthday_day">
                                                <span class="hm_field_name"><b>Şifre Tekrarı
                                                </b></span>
                                                <span class="hm_requires_star">*</span>
                                            </label>
                                            <asp:TextBox ValidationGroup="sifre" runat="server" placeholder="Şifre Tekrarı" TextMode="Password" ID="txtTekrar" Width="200" CssClass="form-control" ClientIDMode="Static" />
                                            <cc1:PasswordStrength ID="PasswordStrength1" runat="server"
                                                TargetControlID="txtTekrar"
                                                DisplayPosition="RightSide"
                                                StrengthIndicatorType="Text"
                                                PreferredPasswordLength="10"
                                                PrefixText="Güvenlik:"
                                                TextCssClass="TextIndicator_TextBox1"
                                                MinimumNumericCharacters="0"
                                                MinimumSymbolCharacters="0"
                                                RequiresUpperAndLowerCaseCharacters="false"
                                                TextStrengthDescriptions="Düşük;Orta;İyi;Güçlü;Çok Güçlü"
                                                TextStrengthDescriptionStyles="cssClass1;cssClass2;cssClass3;cssClass4;cssClass5"
                                                CalculationWeightings="50;15;15;20" />
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtTekrar" runat="server" ErrorMessage="Boş geçilemez."></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="my_col_third">
                                            <label for="birthday_day">
                                                <span class="hm_field_name"><b></b></span>
                                                <span class="hm_requires_star">*</span>
                                            </label>
                                            <asp:Button ValidationGroup="sifre" OnClick="btnGuncelle_Click" ID="btnGuncelle" Text="Şifre Güncelle" CssClass="btn btn-info " runat="server" />
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>

                                                    <br />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </div>

                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSifre" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>


            </div>
            <br />
            <br />

        </div>

    </section>




</asp:Content>
