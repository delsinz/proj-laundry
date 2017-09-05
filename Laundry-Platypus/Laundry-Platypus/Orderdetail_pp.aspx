﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Orderdetail_pp.aspx.cs" Inherits="Laundry_Platypus.Orderdetail_pp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title> Order List</title>
     <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">-->
    <!--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>-->  
    <!--<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>-->
    <link href='http://fonts.googleapis.com/css?family=Cookie' rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="css/dropoffOrder.css"> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-12">
                <table>
                    <thead>
                        <tr>
                            <th width="25%"> Type </th>
                            <th width="25%"> Picked Quantity </th>
                            <th width="25%"> Clean Quantity </th>
                            <th width="25%"> Check Box </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Coloured Suit</td>
                            <td> 17 </td>
                            <td>
                                <div >
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button type="button" class="quantity-left-minus1 btn btn-danger btn-number"  data-type="minus" data-field="">
                                                <span class="glyphicon glyphicon-minus"></span>
                                            </button>
                                        </span>
                                        <input type="text" id="quantity1" name="quantity" class="form-control input-number" value="0" min="1" max="100">
                                        <span class="input-group-btn">
                                            <button type="button" class="quantity-right-plus1 btn btn-success btn-number" data-type="plus" data-field="">
                                                <span class="glyphicon glyphicon-plus"></span>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div>
                                    <span class="button-checkbox">
                                        <button type="button" class="btn" data-color="primary">Checked</button>
                                        <input type="checkbox" class="hidden" />
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td> Coat </td>
                            <td> 3 </td>
                            <td>
                                <div >
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button type="button" class="quantity-left-minus2 btn btn-danger btn-number"  data-type="minus" data-field="">
                                                <span class="glyphicon glyphicon-minus"></span>
                                            </button>
                                        </span>
                                        <input type="text" id="quantity2" name="quantity" class="form-control input-number" value="0" min="1" max="100">
                                        <span class="input-group-btn">
                                            <button type="button" class="quantity-right-plus2 btn btn-success btn-number" data-type="plus" data-field="">
                                                <span class="glyphicon glyphicon-plus"></span>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div>
                                    <span class="button-checkbox">
                                        <button type="button" class="btn" data-color="primary">Checked</button>
                                        <input type="checkbox" class="hidden" />
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td> Gown </td>
                            <td> 25 </td>
                            <td>
                                <div >
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button type="button" class="quantity-left-minus3 btn btn-danger btn-number"  data-type="minus" data-field="">
                                                <span class="glyphicon glyphicon-minus"></span>
                                            </button>
                                        </span>
                                        <input type="text" id="quantity3" name="quantity" class="form-control input-number" value="0" min="1" max="100">
                                        <span class="input-group-btn">
                                            <button type="button" class="quantity-right-plus3 btn btn-success btn-number" data-type="plus" data-field="">
                                                <span class="glyphicon glyphicon-plus"></span>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div>
                                    <span class="button-checkbox">
                                        <button type="button" class="btn" data-color="primary">Checked</button>
                                        <input type="checkbox" class="hidden"/>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td> Shirt </td>
                            <td> 9 </td>
                            <td>
                                <div >
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button type="button" class="quantity-left-minus4 btn btn-danger btn-number"  data-type="minus" data-field="">
                                                <span class="glyphicon glyphicon-minus"></span>
                                            </button>
                                        </span>
                                        <input type="text" id="quantity4" name="quantity" class="form-control input-number" value="0" min="1" max="100">
                                        <span class="input-group-btn">
                                            <button type="button" class="quantity-right-plus4 btn btn-success btn-number" data-type="plus" data-field="">
                                                <span class="glyphicon glyphicon-plus"></span>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div>
                                    <span class="button-checkbox">
                                        <button type="button" class="btn" data-color="primary">Checked</button>
                                        <input type="checkbox" class="hidden" />
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td> Jumper </td>
                            <td> 1 </td>
                            <td>
                                <div >
                                    <div class="input-group">
                                        <span class="input-group-btn">
                                            <button type="button" class="quantity-left-minus5 btn btn-danger btn-number"  data-type="minus" data-field="">
                                                <span class="glyphicon glyphicon-minus"></span>
                                            </button>
                                        </span>
                                        <input type="text" id="quantity5" name="quantity" class="form-control input-number" value="0" min="1" max="100">
                                        <span class="input-group-btn">
                                            <button type="button" class="quantity-right-plus5 btn btn-success btn-number" data-type="plus" data-field="">
                                                <span class="glyphicon glyphicon-plus"></span>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div>
                                    <span class="button-checkbox">
                                        <button type="button" class="btn" data-color="primary">Checked</button>
                                        <input type="checkbox" class="hidden" />
                                    </span>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="well">

                    <div class="row">
                        <div class="col-md-6">
                            <div>
                                <label> Driver Notes </label>
                                <textarea class="form-control" rows="4" id="driverNote" readonly>
                                    3 coloured suits were dirty.
                                    2 gowns needed repaired.
                                    9 shirts were branded.
                                </textarea>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div>
                                <label> Your Notes </label>
                                <textarea class="form-control" rows="4" id="packerNote" placeholder="Write notes here..."></textarea>
                            </div>
                        </div>
                    </div>

                    <div class="well">
                        <a href="packerOrderMain.html" class="btn btn-default">Back</a>
                        <input id="button" type="submit" class="btn btn btn-default" value="Finish" >


                    </div>


                 </div>

        </div>
    </div>
</body>
</asp:Content>
