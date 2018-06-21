<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="AddClass.cs" Inherits="BilgeAdamSharing.SinifEkle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Baslik" runat="server">
   <h4>
       <asp:Label Text="" ID="lblDurum" runat="server" /></h4>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="İcerik" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>

    <section class="content_section">

        <div class="content row_spacer clearfix">
            <div class="hm-tabs tabs1">

                <ul class="tabs-body">
                    <li data-content="inbox" class="selected">
                        <div class="form_row clearfix">
                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Sınıf Adı
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox runat="server" ID="txtSinif" />
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtSinif" runat="server" ErrorMessage="Sınıf adı giriniz."></asp:RequiredFieldValidator>

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


                            <div class="my_col_third">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <label for="birthday_day">
                                            <span class="hm_field_name"><b>Eğitmen
                                            </b></span>
                                            <span class="hm_requires_star">*</span>
                                        </label>
                                        <asp:DropDownList ID="DropDownListEgitmen" ClientIDMode="Static" AutoPostBack="true" CssClass="dropdown" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DropDownListEgitmen" InitialValue="0" ErrorMessage="Lütfen Eğitmen Seçiniz" />
                                    </ContentTemplate>

                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DropDownListEgitmen" EventName="SelectedIndexChanged" />

                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                        <div class="form_row clearfix">
                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Açılış Tarihi
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox runat="server" placeholder="Açılış Tarihi" ID="txtAcilisTarihi" CssClass="form-control" ClientIDMode="Static" />
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtAcilisTarihi" runat="server" ErrorMessage="Lütfen bir tarih seçiniz.."></asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="CalendarExtender1" ClearTime="true" TargetControlID="txtAcilisTarihi"
                                    runat="server" />
                            </div>
                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Kapanış Tarihi
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:TextBox runat="server" placeholder="Kapanış Tarihi" ID="txtKapanisTarihi" CssClass="form-control" ClientIDMode="Static" />
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtKapanisTarihi" runat="server" ErrorMessage="Lütfen bir tarih seçiniz.."></asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="CalendarExtender2" ClearTime="true" TargetControlID="txtKapanisTarihi"
                                    runat="server" />

                            </div>
                            <div class="my_col_third">
                                <label for="birthday_day">
                                    <span class="hm_field_name"><b>Aktif
                                    </b></span>
                                    <span class="hm_requires_star">*</span>
                                </label>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chAktif" runat="server" CssClass="hizala" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="chAktif" EventName="CheckedChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Button OnClick="btnEkle_Click" ID="btnEkle" Style="margin-left: 220px" Text="Ekle" CssClass="btn btn-default " runat="server" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnEkle" EventName="Click" />
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
