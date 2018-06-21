<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="Classes.cs" Inherits="BilgeAdamSharing.Siniflar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Baslik" runat="server">
    Sınıflar
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="İcerik" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>  
    <section class="content_section">
       
                <div class="content row_spacer clearfix">
                    <div class="hm-tabs tabs1">

                        <ul class="tabs-body">
                            <li data-content="inbox" class="selected">
                                <div class="form_row clearfix">
                                    <div class="my_col_full table-responsive">
                                       
                                        <asp:GridView ID="GridviewSiniflar" EmptyDataText="Kayıt Bulunmamaktadır."  OnRowCommand="GridviewSiniflar_RowCommand" CssClass="table table-responsive table-hover" OnRowDataBound="GridviewSiniflar_RowDataBound"  AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sınıf Adı" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                          <asp:Label ID="lblAd" Target="_blank" Width="100px" Text='<%# Eval("Name") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtAd" Width="100px" Text='<%# Eval("Name") %>'  runat="server" />  
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Bölüm" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                          <asp:DropDownList ClientIDMode="Static" Enabled="false" Width="150" ID="dropdownBolum" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                              <asp:DropDownList ClientIDMode="Static" Width="150" ID="dropdownBolum" runat="server">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Eğitmen" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                          <asp:DropDownList ClientIDMode="Static" Enabled="false" Width="150" ID="dropdownEgitmen" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                              <asp:DropDownList ClientIDMode="Static" Width="150" ID="dropdownEgitmen" runat="server">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Açılış Tarihi" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:Label Width="120px" Text='<%# Eval("CreatedDate","{0:dd.MM.yyyy}") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox Width="120px" runat="server" Text='<%# Eval("CreatedDate","{0:dd.MM.yyyy}") %>' ID="txtAcilis" />
                                            <cc1:CalendarExtender TargetControlID="txtAcilis" ID="CalendarExtender1" runat="server" />  
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Kapanış Tarihi" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                          <asp:Label Width="120px" Text='<%# Eval("ClosedDate","{0:dd.MM.yyyy}") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                               <asp:TextBox Width="120px" Text='<%# Eval("ClosedDate","{0:dd.MM.yyyy}") %>' runat="server" ID="txtKapanis" />
                                            <cc1:CalendarExtender TargetControlID="txtKapanis" ID="CalendarExtender2" runat="server" />  
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Durum" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                        <%-- <%# Eval("IsActive").ToString() == "True" ? "<span class='label label-success'>Aktif</span>" : "<span class='label label-important'>Pasif</span>" %>--%>
                                            <asp:LinkButton ID="LinkbuttonAktif" runat="server"  CommandArgument='<%# Eval("Id") %> ' CommandName="aktif"></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                              <%-- <%# Eval("IsActive").ToString() == "True" ? "<span class='label label-success'>Aktif</span>" : "<span class='label label-important'>Pasif</span>" %>--%>
                                            <asp:LinkButton ID="LinkbuttonAktif" runat="server"  CommandArgument='<%# Eval("Id") %> ' CommandName="aktif"></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                 
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Id") %>'  ID="lblID" Visible="false" runat="server" />
                                            <asp:Label Text='<%# Eval("TrainerID") %>'  ID="lbltr" Visible="false" runat="server" />
                                            <asp:Label Text='<%# Eval("SectionID") %>'  ID="Label1" Visible="false" runat="server" />
                                            <asp:LinkButton ID="LinkbuttonDuzenle" runat="server" ToolTip="Düzenle" CommandArgument='<%# Eval("Id") %>' Text="Düzenle" CssClass="btn btn-success btn-mini" CommandName="duzenle"> </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label Text='<%# Eval("Id") %>'  ID="lblID" Visible="false" runat="server" />
                                             <asp:Label Text='<%# Eval("TrainerID") %>'  ID="lbltr" Visible="false" runat="server" />
                                            <asp:Label Text='<%# Eval("SectionID") %>'  ID="Label1" Visible="false" runat="server" />
                                            <asp:LinkButton Text="Güncelle" ID="LinkbuttonGuncelle" CssClass="btn btn-success btn-mini" runat="server" ToolTip="Güncelle"  CommandArgument='<%# Eval("Id") %> ' CommandName="guncelle" ValidationGroup="carpan"> </asp:LinkButton>
                                            <asp:LinkButton ID="LinkbuttonIptal" Text="İptal" CssClass="btn btn-danger btn-mini" runat="server" ToolTip="İptal" CommandName="iptal"> </asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="true" />
                                      
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>


                                    </div>
                                   
                                    </div>
                                
         </section>
             </ContentTemplate>
        <Triggers>
            
        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>
