<%@ Page Language="C#" MasterPageFile="~/Admins/View/Admin.Master" AutoEventWireup="true" CodeBehind="SuaSanPham.aspx.cs" Inherits="MobileCenter.Admins.View.SuaSanPham" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 820px">
        <tr>
            <td style="width: 300px" align="center">Tên sản phẩm</td>
            <td style="width: 700px">
                <asp:TextBox ID="txtTenSanPham" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenSanPham"
                    ErrorMessage="Tên sản phẩm không để trống"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 300px" align="center">Mô tả sản phẩm</td>
            <td style="width: 700px">
                <CKEditor:CKEditorControl ID="CKEditorControlMoTa" runat="server"></CKEditor:CKEditorControl>
        </tr>
        <tr>
            <td style="width: 300px" align="center">Đơn giá</td>
            <td style="width: 700px">
                <asp:TextBox ID="textGia" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textGia"
                    ErrorMessage="Giá sản phẩm không để trống"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 300px" align="center">Danh mục</td>
            <td style="width: 700px">
                <asp:DropDownList ID="dropDanhMucSanPham" runat="server" Width="156px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 300px" align="center">Hình</td>
            <td style="width: 700px">
                <asp:Image ID="imgHinhSanPham" runat="server" Height="125px" Width="100px" /></td>
        </tr>
        <tr>
            <td style="width: 300px"></td>
            <td style="width: 700px">
                <asp:FileUpload ID="fileuploadHinhSanPham" runat="server" /></td>
        </tr>
        <tr>
            <td style="width: 300px"></td>
            <td style="width: 700px">
                <asp:Button ID="btnCapNhat" runat="server" Text="Cập Nhật" OnClick="btnCapNhat_Click" />
                <asp:Button ID="btnBoQua" runat="server" Text="Bỏ Qua" OnClick="btnBoQua_Click" /></td>
        </tr>
    </table>
</asp:Content>

