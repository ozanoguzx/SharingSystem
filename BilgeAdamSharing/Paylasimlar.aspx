<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="AllShares.cs" Inherits="BilgeAdamSharing.Paylasimlar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Baslik" runat="server">
    Paylaşımlar
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="İcerik" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
    
 
    <section class="content_section">
       
                <div class="content row_spacer clearfix">
                    <div class="hm-tabs tabs1">

                        <ul class="tabs-body">
                            <li data-content="inbox" class="selected">
                                <div class="form_row clearfix">
                                    <div class="my_col_full table-responsive">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate> 
                                        <asp:GridView ID="GridviewPaylasimlar" EmptyDataText="Kayıt Bulunmamaktadır." ClientIDMode="Static"  OnRowCommand="GridviewPaylasimlar_RowCommand" CssClass="table table-striped  table-bordered" OnRowDataBound="GridviewPaylasimlar_RowDataBound"  AutoGenerateColumns="false" runat="server" OnPageIndexChanging="GridviewPaylasimlar_PageIndexChanging" AllowPaging="True" PageSize="10">
                                <Columns>
                                    <asp:TemplateField HeaderText="Konu" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                          <asp:DropDownList ClientIDMode="Static" style="text-align:center" Enabled="false" Height="35px"  Width="150" ID="dropDownKonu" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                              <asp:DropDownList ClientIDMode="Static" style="text-align:center" Width="150" Height="35px" ID="dropDownKonu" runat="server">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Sınıf" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                          <asp:DropDownList ClientIDMode="Static" style="text-align:center" Enabled="false" Height="35px" Width="150" ID="dropDownSinif" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                              <asp:DropDownList ClientIDMode="Static" Width="150" style="text-align:center" Height="35px" ID="dropDownSinif" runat="server">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Dosya Adı" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                           <span style="font-size:small"><%# Eval("FileName") %></span>
                                        </ItemTemplate>
                                          </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Olş. Tarihi" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:Label Width="120px" style="font-size:small" Text='<%# Eval("CreatedDate","{0:dd.MM.yyyy H:mm}") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox Width="120px" runat="server" Text='<%# Eval("CreatedDate","{0:dd.MM.yyyy}") %>' ID="txtAcilis" />
                                            <cc1:CalendarExtender TargetControlID="txtAcilis" ID="CalendarExtender1" runat="server" />  
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Durum" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            
                                           <asp:LinkButton ID="LinkbuttonAktif" runat="server"  CommandArgument='<%# Eval("Id") %> ' CommandName="aktif"><i class="icon ico-clear"></i></asp:LinkButton> 
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="LinkbuttonAktif" runat="server"  CommandArgument='<%# Eval("PresentationID") %> ' CommandName="aktif"><i class="icon ico-clear"></i></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Id") %>'  ID="lblID" Visible="false" runat="server" />
                                            <asp:Label Text='<%# Eval("ClassroomID") %>'  ID="lbltr" Visible="false" runat="server" />
                                            <asp:Label Text='<%# Eval("SubjectID") %>'  ID="Label1" Visible="false" runat="server" />
                                            <asp:LinkButton ID="LinkbuttonDuzenle"  runat="server" ToolTip="Düzenle" CommandArgument='<%# Eval("ClassroomID") %>' Text="Düzenle"  CssClass="btn btn-success" CommandName="duzenle"><i  class="icon ico-edit2"></i> </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label Text='<%# Eval("PresentationID") %>'  ID="lblID" Visible="false" runat="server" />
                                             <asp:Label Text='<%# Eval("ClassroomID") %>'  ID="lbltr" Visible="false" runat="server" />
                                            <asp:Label Text='<%# Eval("Subject") %>'  ID="Label1" Visible="false" runat="server" />
                                            <asp:LinkButton Text="Güncelle" ID="LinkbuttonGuncelle" CssClass="btn btn-success btn-mini" runat="server" ToolTip="Güncelle"  CommandArgument='<%# Eval("PresentationID") %> ' CommandName="guncelle" ValidationGroup="carpan"> </asp:LinkButton>
                                            <asp:LinkButton ID="LinkbuttonIptal" Text="İptal" CssClass="btn btn-danger btn-mini" runat="server" ToolTip="İptal" CommandName="iptal"> </asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="true" />
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="İndir" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                             <asp:LinkButton OnClick="LinkButtonKaydet_Click" ID="LinkButtonKaydet" runat="server" Text="Kaydet"  CommandArgument='<%# Eval("FileUrl") %> ' CommandName="kaydet"><i  class="icon ico-download4"></i> </asp:LinkButton>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    
                                </Columns>
                                            <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                                          </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                   
                                    </div>
                                </div></div>
         </section>   
</asp:Content>