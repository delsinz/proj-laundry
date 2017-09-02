﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="DriverOverview.aspx.cs" Inherits="Laundry_Platypus.DriverOverview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ASP.NET SignalR Stock Ticker</title>
     <title>driver view</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>
    <link href='http://fonts.googleapis.com/css?family=Cookie' rel='stylesheet' type='text/css'>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>ASP.NET SignalR DriverOverview Sample</h1>

    <h2>Driver Order Table</h2>
    <div id="orderTable">
        <table border="1">
        <thead>
        <tr>
            <th>OrderID</th>
            <th>Status</th>
        </tr>
        </thead>
            <tbody>
                <tr class="loading"><td colspan="5">loading...</td></tr>
            </tbody>
        </table>
    </div>
    <!--Script references. -->
    <!--Reference the jQuery library. -->
    <script src="Scripts/jquery-3.1.1.min.js" ></script>
    <!--Reference the SignalR library. -->
    <script src="Scripts/jquery.signalR-2.2.2.js"></script>
    <!--Reference the autogenerated SignalR hub script. -->
    <script src="signalr/hubs"></script>
    <!--Reference the StockTicker script. -->
    <script src="Scripts/System.js"></script>
</asp:Content>
