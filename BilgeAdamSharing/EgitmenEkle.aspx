<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="AddTrainer.cs" Inherits="BilgeAdamSharing.EgitmenEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Baslik" runat="server">
    Eğitmen Ekle-Güncelle
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
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>İsim
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox ID="txtAd" PlaceHolder="İsim Giriniz" runat="server" Width="250" CssClass="form-control" onfocus="isBlurred=true;" onblur="isBlurred=false;" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtAd" runat="server" ErrorMessage="Lütfen boş bırakmayınız."></asp:RequiredFieldValidator>
                            </div>
                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Soyisim
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox ID="txtSoyad" PlaceHolder="Soyisim Giriniz" runat="server" Width="250" CssClass="form-control" onfocus="isBlurred=true;" onblur="isBlurred=false;" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtSoyad" runat="server" ErrorMessage="Lütfen boş bırakmayınız."></asp:RequiredFieldValidator>
                            </div>
                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Kullanıcı Adı
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox ID="txtUsername" PlaceHolder="Kullanıcı Adı" runat="server" Width="250" CssClass="form-control" onfocus="isBlurred=true;" onblur="isBlurred=false;" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUsername" runat="server" ErrorMessage="Lütfen boş bırakmayınız."></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="form_row clearfix">
                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Mail
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox ID="txtMailadmin" PlaceHolder="E-Mail" TextMode="Email" runat="server" Width="250" CssClass="form-control" required="" onfocus="isBlurred=true;" onblur="isBlurred=false;" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtMailadmin" runat="server" ErrorMessage="Lütfen boş bırakmayınız."></asp:RequiredFieldValidator>
                            </div>
                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Şifre
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox TextMode="Password" ID="txtSifreadmin" PlaceHolder="Şifre Giriniz" runat="server" Width="250" CssClass="form-control" onfocus="isBlurred=true;" onblur="isBlurred=false;" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtSifreadmin" runat="server" ErrorMessage="Lütfen boş bırakmayınız."></asp:RequiredFieldValidator>

                            </div>
                            <div class="my_col_third">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <label for="birthday_day">
                                            <span class="hm_field_name"><b>Bölüm
                                            </b></span>
                                            <span class="hm_requires_star">*</span>
                                        </label>
                                        <asp:DropDownList ID="DropDownListBolum" ClientIDMode="Static" AutoPostBack="true" CssClass="dropdown" runat="server"></asp:DropDownList>
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="DropDownListBolum" InitialValue="0" ErrorMessage="Lütfen Bölüm Seçiniz" />

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DropDownListBolum" EventName="SelectedIndexChanged" />

                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                        <asp:Label Text="Aktif" runat="server" />
                        <asp:CheckBox Style="margin-left: 5px; margin-top: 5px" ID="chAktif" runat="server" CssClass="hizala " OnCheckedChanged="chAktif_CheckedChanged" />

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button OnClick="btnKullanici_Click" Style="margin-left: 250px" Width="125px" ID="btnKullanici" Text="Ekle" CssClass="btn btn-danger pull-right " runat="server" />
                                <br />
                                <br />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnKullanici" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
            </div>
        </div>

    </section>


</asp:Content>
