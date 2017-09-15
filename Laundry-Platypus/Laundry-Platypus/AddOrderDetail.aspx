<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="AddOrderDetail.aspx.cs" Inherits="Laundry_Platypus.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ItemTemplate>

                        <tr>
                            <td>
                                <asp:Label ID="Item_ID" runat="server" Font-Size="9pt" Height="19px" Width="1px"></asp:Label>
                                <%#DataBinder.Eval(Container.DataItem, "")%>
                            </td>
                            <td>
                                <asp:Label ID="Item_Name" runat="server" Font-Size="9pt" Height="19px" Width="1px"></asp:Label>
                                <%#DataBinder.Eval(Container.DataItem, "")%>
                            </td>
                            <td>
                                <asp:Label ID="Item_Abbr" runat="server" Font-Size="9pt" Height="19px" Width="1px"></asp:Label>
                                <%#DataBinder.Eval(Container.DataItem, "")%>
                            </td>
                            <td>
                                <input type="button" name="Submit" value="Edit" onclick="edit(this)"/>
                                
                                <asp:Button ID="RemoveButton" type="button" class="btn btn-primary" runat="server" OnClick="Remove_Click" Text="Remove" />
                            </td>                    

                        </tr>
                
                </ItemTemplate>
    <asp:Button ID="return" runat="server" Text="Return" onClick ="return_click"/>
    <asp:Button ID="save" runat="server" Text="Save Order" onClick ="save_click"/>
</asp:Content>
