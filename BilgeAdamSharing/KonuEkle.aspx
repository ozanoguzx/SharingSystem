<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="AddSubject.cs" Inherits="BilgeAdamSharing.Konular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Baslik" runat="server">
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
                                    <span class="hm_field_name"><b>Konu Adı
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox ID="txtBolum" PlaceHolder="Konu adı Giriniz" runat="server" Width="250" CssClass="form-control" onfocus="isBlurred=true;" onblur="isBlurred=false;" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtBolum" runat="server" ErrorMessage="Boş geçilemez."></asp:RequiredFieldValidator>
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
                                Aktif
                                        <asp:CheckBox Style="margin-left: 15px" ID="chAktif" runat="server" CssClass="hizala" />

                            </div>
                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b></b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Button OnClick="btnEkle_Click" ID="btnEkle" Text="Ekle" CssClass="btn btn-default " runat="server" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnEkle" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <br />


                        <br />
            </div>

        </div>
    </section>

</asp:Content>


