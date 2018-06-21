<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="Subjects.cs" Inherits="BilgeAdamSharing.KonuEkle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Baslik" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="İcerik" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
    
    <asp:UpdatePanel runat="server">
        <ContentTemplate>  
	<section class="content_section">
		<div class="content_spacer">
			<div class="content">
				
				
				<div class="table_container table-responsive">
					<asp:GridView ID="GridviewKonular"  OnRowCommand="GridviewKonular_RowCommand" EmptyDataText="Kayıt Bulunmamaktadır." CssClass="table table-striped" OnRowDataBound="GridviewKonular_RowDataBound"  AutoGenerateColumns="false" runat="server" OnPageIndexChanging="GridviewKonular_PageIndexChanging" AllowPaging="True" PageSize="10">
                                <Columns>
                                    
                                    <asp:TemplateField HeaderText="Bölüm Adı" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                          <%# Eval("Name") %>
                                        </ItemTemplate>
                                        <EditItemTemplate> 
                                            <asp:TextBox ID="txtAd" Width="70px"   Text='<%# Eval("Name") %>'  runat="server" />  
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
                                    <asp:TemplateField HeaderText="Durum" ItemStyle-CssClass="">
                                        <ItemTemplate>
                                       
                                            <asp:LinkButton ID="LinkbuttonAktif" runat="server"  CommandArgument='<%# Eval("ID") %> ' CommandName="aktif"></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                              
                                            <asp:LinkButton ID="LinkbuttonAktif" runat="server"  CommandArgument='<%# Eval("ID") %> ' CommandName="aktif"></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="İşlem">
                                        <ItemTemplate>
                                           
                                            <asp:Label Text='<%# Eval("SectionID") %>'  ID="Label1" Visible="false" runat="server" />
                                            <asp:LinkButton ID="LinkbuttonDuzenle" runat="server" ToolTip="Düzenle" CommandArgument='<%# Eval("ID") %>' Text="Düzenle"  CommandName="duzenle"> </asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                             <asp:Label Text='<%# Eval("ID") %>'  ID="lbltr" Visible="false" runat="server" />
                                            <asp:Label Text='<%# Eval("SectionID") %>'  ID="Label1" Visible="false" runat="server" />
                                            <asp:LinkButton Text="Güncelle" ID="LinkbuttonGuncelle"  runat="server" ToolTip="Güncelle"  CommandArgument='<%# Eval("ID") %> ' CommandName="guncelle" ValidationGroup="carpan"> </asp:LinkButton>
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