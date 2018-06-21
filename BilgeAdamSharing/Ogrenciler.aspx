<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="Students.cs" Inherits="BilgeAdamSharing.Ogrenciler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Baslik" runat="server">
    Öğrenciler
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="İcerik" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <section class="content_section">
                <div class="content_spacer">
                    <div class="content">
                        <div class="form_row clearfix">
                            <div class="my_col_third">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <label for="birthday_day">
                                            <span class="hm_field_name"><b>Sınıf
                                            </b></span>
                                            <span class="hm_requires_star">*</span>
                                        </label>
                                        <asp:DropDownList ID="DropDownListSinif" OnSelectedIndexChanged="DropDownListSinif_SelectedIndexChanged" ClientIDMode="Static" AutoPostBack="true" CssClass="dropdown" runat="server"></asp:DropDownList>
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="DropDownListSinif" InitialValue="0" ErrorMessage="Lütfen Bölüm Seçiniz" />
                                    </ContentTemplate>
                                   
                                </asp:UpdatePanel>
                            
                            </div>
                        </div>
                        <div class="table_container table-responsive">
                            <asp:GridView ID="GridviewOgrenciler" EmptyDataText="Kayıt Bulunmamaktadır." OnRowCommand="GridviewOgrenciler_RowCommand" CssClass="table table-striped" OnRowDataBound="GridviewOgrenciler_RowDataBound" AutoGenerateColumns="false" runat="server" OnPageIndexChanging="GridviewOgrenciler_PageIndexChanging" AllowPaging="True" PageSize="10">
                                <Columns>
                                    <asp:TemplateField HeaderText="İsim" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <%# Eval("FirstName") %>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtAd" Width="70px" Text='<%# Eval("FirstName") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Soyisim" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:Label ID="txtSoyad" Target="_blank" Text='<%# Eval("LastName") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtSoyad" Width="100px" Text='<%# Eval("LastName") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mail" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <%# Eval("EMail") %>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtmail" Width="170px" Text='<%# Eval("EMail") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Password" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            *******
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtpassword" Width="170px" Text='<%# Eval("Password") %>' runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bölüm" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:DropDownList ClientIDMode="Static" Enabled="false" ID="dropdownBolum" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ClientIDMode="Static" ID="dropdownBolum" runat="server">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sınıf" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:DropDownList ClientIDMode="Static" Enabled="false" ID="dropdownSinif" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ClientIDMode="Static" ID="dropdownSinif" runat="server">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Durum" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkbuttonAktif" runat="server" CommandArgument='<%# Eval("Id") %> ' CommandName="aktif"><i class="icon ico-clear"></i></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>

                                            <asp:LinkButton ID="LinkbuttonAktif" runat="server" CommandArgument='<%# Eval("Id") %> ' CommandName="aktif"><i class="icon ico-clear"></i></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="İşlem">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Id") %>' ID="lbltr" Visible="false" runat="server" />
                                            <asp:Label Text='<%# Eval("SectionId") %>' ID="Label1" Visible="false" runat="server" />
                                            <asp:LinkButton ID="LinkbuttonDuzenle" runat="server" ToolTip="Düzenle" CommandArgument='<%# Eval("Id") %>' Text="Düzenle" CommandName="duzenle"> </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label Text='<%# Eval("Id") %>' ID="lbltr" Visible="false" runat="server" />
                                            <asp:Label Text='<%# Eval("SectionId") %>' ID="Label1" Visible="false" runat="server" />
                                           
                                            <asp:LinkButton ID="LinkbuttonIptal" runat="server" CssClass="btn btn-warning btn-mini " CommandName="iptal"><i class="icon ico-remove"></i> </asp:LinkButton>
                                             <asp:LinkButton ID="LinkbuttonGuncelle" runat="server" CssClass="btn btn-success btn-mini" CommandArgument='<%# Eval("Id") %> ' CommandName="guncelle" ValidationGroup="carpan"><i class="icon ico-tick"></i> </asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="true" />

                                    </asp:TemplateField>

                                </Columns>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>
                        <div class="highlight">
                            <asp:Label ID="LabelSayi" Text="" runat="server" />
                            </code>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>

