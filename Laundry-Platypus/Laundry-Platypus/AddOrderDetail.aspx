<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="AddOrderDetail.aspx.cs" Inherits="Laundry_Platypus.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Add order details</title>

    <meta name="description" content="Source code generated using layoutit.com">
    <meta name="author" content="LayoutIt!">

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/itemStyle.css" rel="stylesheet">

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
                                    <th></th>
                                    <th></th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td width="25%"> <asp:DropDownList ID="DropDownList1" runat="server"  ></asp:DropDownList></td>
                                <td width="25%">
                                    <div>
                                        <div class="input-group">
                                             
                                            
                                            <asp:TextBox ID="TextBox1"  type="text" runat="server" class="form-control input-number" min="0" max="100" name="quantity" Text='<%#DataBinder.Eval(Container.DataItem, "garment_number")%>'></asp:TextBox>
                                             
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
                    <asp:TextBox ID="TextBox3" class="form-control" rows="4"  Text="Write notes here..." runat="server"></asp:TextBox>
                </div>
                <div class="col-md-12">
                    <a href="driverOrderMain.html" class="btn btn-default">Back</a>
                    <asp:Label ID="Label1" runat="server" Text="Total Price:"></asp:Label>
                    <asp:TextBox ID="price" runat="server"></asp:TextBox>
                   <asp:Button ID="save" runat="server" Text="Save Order" onClick ="save_click" class="btn btn-default"/>
                </div>
            </div>
        </div>
    </div>



    <script>
        $(document).ready(function () {

            var quantitiy = 0;
            $('.quantity-right-plus1').click(function (e) {

                // Stop acting like a button
                e.preventDefault();
                // Get the field name
                var quantity = parseInt($('#quantity1').val());

                // If is not undefined

                $('#quantity1').val(quantity + 1);


                // Increment

            });

            $('.quantity-left-minus1').click(function (e) {
                // Stop acting like a button
                e.preventDefault();
                // Get the field name
                var quantity = parseInt($('#quantity1').val());

                // If is not undefined

                // Increment
                if (quantity > 0) {
                    $('#quantity1').val(quantity - 1);
                }
            });

            $('.quantity-right-plus2').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity2').val());
                $('#quantity2').val(quantity + 1);
            });

            $('.quantity-left-minus2').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity2').val());
                if (quantity > 0) {
                    $('#quantity2').val(quantity - 1);
                }
            });

            $('.quantity-right-plus3').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity3').val());
                $('#quantity3').val(quantity + 1);
            });

            $('.quantity-left-minus3').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity3').val());
                if (quantity > 0) {
                    $('#quantity3').val(quantity - 1);
                }
            });

            $('.quantity-right-plus4').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity4').val());
                $('#quantity4').val(quantity + 1);
            });

            $('.quantity-left-minus4').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity4').val());
                if (quantity > 0) {
                    $('#quantity4').val(quantity - 1);
                }
            });

            $('.quantity-right-plus5').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity5').val());
                $('#quantity5').val(quantity + 1);
            });

            $('.quantity-left-minus5').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity5').val());
                if (quantity > 0) {
                    $('#quantity5').val(quantity - 1);
                }
            });

            $('.quantity-right-plus6').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity6').val());
                $('#quantity6').val(quantity + 1);
            });

            $('.quantity-left-minus6').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity6').val());
                if (quantity > 0) {
                    $('#quantity6').val(quantity - 1);
                }
            });

            $('.quantity-right-plus7').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity7').val());
                $('#quantity7').val(quantity + 1);
            });

            $('.quantity-left-minus7').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity7').val());
                if (quantity > 0) {
                    $('#quantity7').val(quantity - 1);
                }
            });

            $('.quantity-right-plus8').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity8').val());
                $('#quantity8').val(quantity + 1);
            });

            $('.quantity-left-minus8').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity8').val());
                if (quantity > 0) {
                    $('#quantity8').val(quantity - 1);
                }
            });

            $('.quantity-right-plus9').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity9').val());
                $('#quantity9').val(quantity + 1);
            });

            $('.quantity-left-minus9').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity9').val());
                if (quantity > 0) {
                    $('#quantity9').val(quantity - 1);
                }
            });

            $('.quantity-right-plus10').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity10').val());
                $('#quantity10').val(quantity + 1);
            });

            $('.quantity-left-minus10').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity10').val());
                if (quantity > 0) {
                    $('#quantity10').val(quantity - 1);
                }
            });
            $('.quantity-right-plus11').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity11').val());
                $('#quantity11').val(quantity + 1);
            });

            $('.quantity-left-minus11').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity11').val());
                if (quantity > 0) {
                    $('#quantity11').val(quantity - 1);
                }
            });
            $('.quantity-right-plus12').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity12').val());
                $('#quantity12').val(quantity + 1);
            });

            $('.quantity-left-minus12').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity12').val());
                if (quantity > 0) {
                    $('#quantity12').val(quantity - 1);
                }
            });
            $('.quantity-right-plus13').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity13').val());
                $('#quantity13').val(quantity + 1);
            });

            $('.quantity-left-minus13').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity13').val());
                if (quantity > 0) {
                    $('#quantity13').val(quantity - 1);
                }
            });
            $('.quantity-right-plus14').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity14').val());
                $('#quantity14').val(quantity + 1);
            });

            $('.quantity-left-minus14').click(function (e) {
                e.preventDefault();
                var quantity = parseInt($('#quantity14').val());
                if (quantity > 0) {
                    $('#quantity14').val(quantity - 1);
                }
            });

        });

    </script>
   
</asp:Content>