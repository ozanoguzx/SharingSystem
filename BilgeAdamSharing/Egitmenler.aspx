<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="Trainers.cs" Inherits="BilgeAdamSharing.Egitmenler" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="Baslik" runat="server">
    Eğitmenler
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="İcerik" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>  
	<section class="content_section">
		<div class="content_spacer">
			<div class="content">
				
				
				<div class="table_container table-responsive">
					<asp:GridView ID="GridviewSiniflar"  OnRowCommand="GridviewSiniflar_RowCommand" EmptyDataText="Kayıt Bulunmamaktadır." CssClass="table table-striped" OnRowDataBound="GridviewSiniflar_RowDataBound"  AutoGenerateColumns="false" runat="server" OnPageIndexChanging="GridviewSiniflar_PageIndexChanging1" AllowPaging="True" PageSize="10">
                                <Columns>
                                    <asp:TemplateField HeaderText="İsim" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                          <%# Eval("FirstName") %>
                                        </ItemTemplate>
                                        <EditItemTemplate> 
                                            <asp:TextBox ID="txtAd" Width="70px"   Text='<%# Eval("FirstName") %>'  runat="server" />  
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Soyisim"  ItemStyle-CssClass="">
                                        <ItemTemplate>
                                          <asp:Label ID="txtSoyad" Target="_blank"  Text='<%# Eval("LastName") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtSoyad" Width="100px"  Text='<%# Eval("LastName") %>'  runat="server" />  
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="K.Adı" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                          <%# Eval("UserName") %>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtusername" Width="120px"  Text='<%# Eval("UserName") %>'  runat="server" />  
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mail" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                          <%# Eval("EMail") %>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtmail" Width="170px"  Text='<%# Eval("EMail") %>'  runat="server" />  
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bölüm" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                          <asp:DropDownList ClientIDMode="Static" Enabled="false"  ID="dropdownBolum" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                              <asp:DropDownList ClientIDMode="Static"  ID="dropdownBolum" runat="server">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Kayıt Tarihi" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                            <asp:Label Width="120px" Text='<%# Eval("CreatedDate","{0:dd.MM.yyyy}") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox Width="120px" runat="server" Text='<%# Eval("CreatedDate","{0:dd.MM.yyyy}") %>' ID="txtAcilis" />
                                            <cc1:CalendarExtender TargetControlID="txtAcilis" ID="CalendarExtender1" runat="server" />  
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Durum" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                       
                                            <asp:LinkButton ID="LinkbuttonAktif" runat="server"  CommandArgument='<%# Eval("Id") %> ' CommandName="aktif"></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                              
                                            <asp:LinkButton ID="LinkbuttonAktif" runat="server"  CommandArgument='<%# Eval("TrainerID") %> ' CommandName="aktif"></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="İşlem">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Id") %>'  ID="lbltr" Visible="false" runat="server" />
                                            <asp:Label Text='<%# Eval("SectionID") %>'  ID="Label1" Visible="false" runat="server" />
                                            <asp:LinkButton ID="LinkbuttonDuzenle" runat="server" ToolTip="Düzenle" CommandArgument='<%# Eval("Id") %>' Text="Düzenle"  CommandName="duzenle"> </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                             <asp:Label Text='<%# Eval("TrainerID") %>'  ID="lbltr" Visible="false" runat="server" />
                                            <asp:Label Text='<%# Eval("SectionID") %>'  ID="Label1" Visible="false" runat="server" />
                                            <asp:LinkButton Text="Güncelle" ID="LinkbuttonGuncelle"  runat="server" ToolTip="Güncelle"  CommandArgument='<%# Eval("TrainerID") %> ' CommandName="guncelle" ValidationGroup="carpan"> </asp:LinkButton>
                                            <asp:LinkButton ID="LinkbuttonIptal" Text="İptal"  runat="server" ToolTip="İptal" CommandName="iptal"> </asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="true" />
                                      
                                    </asp:TemplateField>
                                    
                                </Columns>
                        <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
				</div>
				<div class="highlight">
					 <asp:Label ID="LabelSayi" Text="" runat="server" />
                        </code></div></div></div></section>
             </ContentTemplate>
        <Triggers>
            
        </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>