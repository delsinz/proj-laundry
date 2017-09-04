<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="OrderDetail_d.aspx.cs" Inherits="Laundry_Platypus.OrderDetail_d" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href='http://fonts.googleapis.com/css?family=Cookie' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="css/dropoffOrder.css"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="main">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <table class="table-striped table-condensed">
                        <thead>
                            <tr>
                                <th> Type </th>
                                <th> Quantity </th>
                                <th> Type </th>
                                <th> Quantity </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td> Coloured Suit</td>
                                <td> <label>17</label></td>
                                <td> Coat </td>
                                <td> <label> 3 </label></td>
                            </tr>
                            <tr>
                                <td> Gown</td>
                                <td> <label>25</label></td>
                                <td> Shirt </td>
                                <td> <label> 9 </label></td>
                            </tr>
                            <tr>
                                <td> Jumper</td>
                                <td> <label>1</label></td>
                            </tr>
                        </tbody>

                    </table>

                    <div class="form-group">
                        <textarea class="form-control" rows="4" id="comment"> Shits need branding</textarea>
                    </div>

                    <div class="col-md-12">
                        <a href="driverOrderMain.html" class="btn btn-default">Back</a>
                        <input type="submit" class="btn btn btn-default" value="Complete Drop-Off">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
