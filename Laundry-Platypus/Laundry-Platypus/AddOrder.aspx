<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="Laundry_Platypus.AddOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="input-group">
        <span class="input-group-addon" id="basic-addon1">Customer First Name</span>
        <asp:DropDownList ID="CustomerDropList" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Text="<Select customer>" Value="0" />
        </asp:DropDownList>
    </div>
    <div class="input-group">
        <span class="input-group-addon" id="basic-addon2">Pick Up Date</span>
        <asp:TextBox ID="date" runat="server" type="date" class="form-control" placeholder="yyyy-mm-dd"  aria-describedby="basic-addon2" lang="en"></asp:TextBox>
    </div>
    <div class="input-group">
        <span class="input-group-addon" id="basic-addon3">Assignee First Name</span>
        <asp:DropDownList ID="AssigneeDropList" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Text="<Select driver>" Value="0" />
        </asp:DropDownList>
    </div>
    
    <asp:TextBox ID="garment_number" runat="server" class="form-control" placeholder="number of garment types"  aria-describedby="basic-addon2" lang="en"></asp:TextBox>
    <asp:Button ID="add_garment" runat="server" OnClick=add_Click" Text="Add garments" />
    <asp:DropDownList ID="garment_type" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Text="<Select garment>" Value="0" />
    </asp:DropDownList>

 
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save order" />
</asp:Content>
