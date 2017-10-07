<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ViewForm.aspx.cs" Inherits="Laundry_Platypus.ViewForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="datebegin" runat="server" type="date" class="form-control" placeholder="yyyy-mm-dd"  aria-describedby="basic-addon2" lang="en"></asp:TextBox>
     <asp:TextBox ID="dateend" runat="server" type="date" class="form-control" placeholder="yyyy-mm-dd"  aria-describedby="basic-addon2" lang="en"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <asp:CheckBox ID="CheckBox1" Text="Select Customer" runat="server" /><asp:DropDownList ID="CustomerDropList" runat="server" EnableTheming="False">    </asp:DropDownList>
   <asp:Repeater ID="rpTest" runat="server">
   <HeaderTemplate>
     <table>
       <tr>
         <th>OrderID</th>
         <th>Customer</th>
         <th>Price</th>
       </tr>
   </HeaderTemplate>
   <ItemTemplate>
     <tr>
       <td><asp:Label runat="server" ID="lblID" Text='<%# Eval("order_id") %>'></asp:Label></td>
       <td><asp:Label runat="server" ID="lblTitle" Text='<%# Eval("first_name") %>'></asp:Label></td>
       <td><asp:Label runat="server" ID="lblText" Text='<%# Eval("total_price") %>'></asp:Label></td>
     </tr>
   </ItemTemplate>
   <AlternatingItemTemplate>
     <tr>
       <td><asp:Label runat="server" ID="lblID" Text='<%# Eval("order_id") %>'></asp:Label></td>
       <td><asp:Label runat="server" ID="lblTitle" Text='<%# Eval("first_name") %>'></asp:Label></td>
       <td><asp:Label runat="server" ID="lblText" Text='<%# Eval("total_price") %>'></asp:Label></td>
     </tr>
   </AlternatingItemTemplate>
   <FooterTemplate>
     </table>
   </FooterTemplate>
 </asp:Repeater>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
