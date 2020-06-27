<%@ Page Language="C#" MasterPageFile="~/Admins/View/Admin.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="MobileCenter.Admins.View.SanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Button ID="bntThemSanPham" runat="server" Text="Thêm Sản Phẩm" OnClick="bntThemSanPham_Click" /><br/>
    <div>
        
        <asp:DataList ID="dtlSanpham" runat="server"  RepeatColumns="3" Width="750px" CellPadding="0">
        <ItemTemplate>
        <asp:Panel ID="Panel1" runat="server" BorderColor="#E0E0E0" BorderStyle="Solid" BorderWidth="1px" Width="250px">
            <table cellpadding="0" cellspacing="0" style="width: 250px; height:300px">
                <tr>
                    <td rowspan="1" style="width: 125px; height: 150px" align="center" valign="middle">
                        <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl='<%# Eval("IdHinhSanPham","~/View/HienThiHinhSanPham.ashx?IdHinhSanPham={0}") %>'
                            Width="125px" /></td>
                    <td style="width: 125px; height: 150px" align="center" valign="middle">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("IdSanPham","SuaSanPham.aspx?IdSanPham={0}") %>'
                            Text='<%# Eval("TenSanPham") %>'></asp:HyperLink>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("GiaSanPham","{0:###,###,###} VND") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" rowspan="1" style="width: 250px">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("MoTaSanPham") %>'></asp:Label></td>
                </tr>
            </table>
        </asp:Panel>
        </ItemTemplate>
    </asp:DataList>
    </div>
</asp:Content>


