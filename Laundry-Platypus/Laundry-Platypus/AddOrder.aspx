<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="Laundry_Platypus.AddOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="input-group">
        <span class="input-group-addon" id="basic-addon1">Customer's ID</span>
        <asp:TextBox ID="customer_id" runat="server" class="form-control" aria-describedby="basic-addon1"></asp:TextBox>
        
    </div>
    <div class="input-group">
        <span class="input-group-addon" id="basic-addon3">Pick Up Date</span>
        <asp:TextBox ID="date" runat="server" type="date" class="form-control" placeholder="yyyy-mm-dd"  aria-describedby="basic-addon2"></asp:TextBox>
       
    </div>
    <div class="input-group">
        <span class="input-group-addon" id="basic-addon4">Garment type</span>
        <asp:TextBox ID="garment_type" runat="server" type="garment_type" class="form-control" placeholder="e.g. Shirt"  aria-describedby="basic-addon2"></asp:TextBox>
    </div>
    <div class="input-group">
        <span class="input-group-addon" id="basic-addon5">Amount</span>
        <asp:TextBox ID="amount" runat="server" type="amount" class="form-control"  aria-describedby="basic-addon2"></asp:TextBox>
    </div>
    <div class="input-group">
        <span class="input-group-addon" id="basic-addon6">Assignee ID</span>
        <asp:TextBox ID="assignee" runat="server" type="assignee" class="form-control"  aria-describedby="basic-addon2"></asp:TextBox>
    </div>
    
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save order" />
</asp:Content>
