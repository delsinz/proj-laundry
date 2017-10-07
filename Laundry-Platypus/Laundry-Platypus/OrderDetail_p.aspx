<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="OrderDetail_p.aspx.cs" Inherits="Laundry_Platypus.OrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Cookie' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="css/dropoffOrder.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:DataList ID="DataList1" runat="server" Width="100%">
                    <HeaderTemplate>
                        <table class="table-striped table-condensed">
                            <thead>
                                <tr>
                                    <th>Type </th>
                                    <th>Quantity </th>
                                    
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td width="25%"><%#DataBinder.Eval(Container.DataItem, "type_name")%> </td>
                                <asp:Label ID="Label1" runat="server" Visible="False"><%#DataBinder.Eval(Container.DataItem, "garment_id")%></asp:Label>
                                <td width="25%">
                                    <div>
                                        <div class="input-group">
                                            <span class="input-group-btn">
                                                
                                            </span>
                                            
                                            <asp:TextBox ID="TextBox1"  type="text" runat="server" class="form-control input-number" min="0" max="100" name="quantity" Text='<%#DataBinder.Eval(Container.DataItem, "amount")%>'></asp:TextBox>
                                            <span class="input-group-btn">
                                               
                                            </span>
                                        </div>
                                    </div>
                                </td>
                        </tbody>
                    </ItemTemplate>
                   <FooterTemplate>
                </table>
                </FooterTemplate>
                </asp:DataList>


                <div class="form-group">
                    <textarea class="form-control" rows="4" id="comment" placeholder="Write notes here..."></textarea>
                </div>
                <div class="col-md-12">
                    <a href="driverOrderMain.html" class="btn btn-default">Back</a>
                   <asp:Button ID="Button1" runat="server" Text="Complete " class="btn btn btn-default" type="submit" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>



</asp:Content>
