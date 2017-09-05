<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="Laundry_Platypus.AddOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="input-group">
        <span class="input-group-addon" id="basic-addon1">Customer First Name</span>
        <asp:TextBox ID="customer" runat="server" class="form-control" aria-describedby="basic-addon1"></asp:TextBox>
    </div>
    <div class="input-group">
        <span class="input-group-addon" id="basic-addon2">Pick Up Date</span>
        <asp:TextBox ID="date" runat="server" type="date" class="form-control" placeholder="yyyy-mm-dd"  aria-describedby="basic-addon2" lang="en"></asp:TextBox>
    </div>
    <div class="input-group">
        <span class="input-group-addon" id="basic-addon3">Assignee First Name</span>
        <asp:TextBox ID="assignee" runat="server" type="assignee" class="form-control"  aria-describedby="basic-addon2"></asp:TextBox>
    </div>
    <asp:Table ID="myTable" runat="server" Width="100%"> 
        <asp:TableRow>
            <asp:TableCell>Garment type</asp:TableCell>
            <asp:TableCell>Amount</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:DropDownList ID="garment_type" runat="server" AppendDataBoundItems="true">
                    <asp:ListItem Text="<Select garment type>" Value="0" />
                </asp:DropDownList>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="amount" runat="server" type="amount" class="form-control"  aria-describedby="basic-addon2"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>  


 
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save order" />
</asp:Content>
