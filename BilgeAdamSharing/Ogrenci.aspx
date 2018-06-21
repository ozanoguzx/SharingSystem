<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="Shares.cs" Inherits="BilgeAdamSharing.Ogrenci" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Baslik" runat="server">
    Paylaşımlar
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="İcerik" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
    <section class="content_section">

        <div class="container icons_spacer icon_boxes_con style1 clearfix">

            <asp:Repeater ID="dtVeri" OnItemCommand="dtVeri_ItemCommand" OnItemDataBound="dtVeri_ItemDataBound" runat="server">
                <ItemTemplate>
                    <div class="col-md-3">
                        <div class="service_box">
                            <span class="icon"><i class="ico-documents"></i></span>
                            <div class="service_box_con centered">
                                <h3>
                                    <asp:Label ID="lblKonu" runat="server" /></h3>
                                <span class="desc">Konu: <asp:Label ID="lblSubject" ClientIDMode="Static" runat="server" /></span>
                                <span style="font-size:x-small" class="desc"><b>Dosya:<%# Eval("FileName") %></b></span>
                                <span class="desc">Ekleyen: <asp:Label ID="lblTrainer" ClientIDMode="Static" runat="server" /></span>
                                <span class="desc">Tarih:<%# Eval("CreatedDate","{0:dd/MM/yy}") %></span>
   

                                <h5 class="ico-download6" style="margin-top: 5px">
                                   <a href="Download.aspx?id=<%# Eval("PresentationID") %>">İndir</a>
                                </h5>
                      
                                <a href='<%# Eval("FileUrl") %>' class="ser-box-link" style="margin-bottom: 25px"><span></span> </a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            
        </div>
           <div class="content row_spacer clearfix">
        <div class="form_row clearfix">
                <div class="my_col_half">
                     <asp:UpdatePanel runat="server">
        <ContentTemplate>   
                    <cc1:CollectionPager  ID="CollectionPager1" runat="server" BackNextDisplay="Buttons"
                        BackNextLinkSeparator="" BackNextLocation="Split" BackNextStyle=""
                        BackText="Geri" ControlCssClass="Sayfalama" ControlStyle=""
                        FirstText="İlk Sayfa" HideOnSinglePage="True" IgnoreQueryString="false"
                        LabelStyle="" LabelText="Sayfalar :" LastText="Son Sayfa" MaxPages="100"
                        NextText="İleri" PageNumbersDisplay="Numbers" PageNumbersSeparator=""
                        PageNumbersStyle="" PageNumberStyle="" PageSize="8" PagingMode="QueryString"
                        QueryStringKey="s"
                        ResultsFormat="{2} tane üründen {0} - {1} arası gösteriliyor"
                        ResultsLocation="None" ResultsStyle="" SectionPadding="10" ShowFirstLast="True"
                        ShowLabel="False" ShowPageNumbers="True" SliderSize="15" UseSlider="True">
                    </cc1:CollectionPager>
              </ContentTemplate>
    </asp:UpdatePanel>
                </div>
            </div>
               </div>
    </section>
          
</asp:Content>
