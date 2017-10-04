<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ViewForm.aspx.cs" Inherits="Laundry_Platypus.ViewForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="datebegin" runat="server" type="date" class="form-control" placeholder="yyyy-mm-dd"  aria-describedby="basic-addon2" lang="en"></asp:TextBox>
     <asp:TextBox ID="dateend" runat="server" type="date" class="form-control" placeholder="yyyy-mm-dd"  aria-describedby="basic-addon2" lang="en"></asp:TextBox>
</asp:Content>
