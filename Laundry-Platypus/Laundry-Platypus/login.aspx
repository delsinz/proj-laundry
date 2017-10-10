<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Laundry_Platypus.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

     <title>Complete Workwear Login</title>
    <link rel='stylesheet prefetch' href='http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css' />
    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <div id="loginWindow">
                <div class="page-header">
                    <p class="left">
                        <span class="glyphicon glyphicon-lock" aria-hidden="true"></span>
                    </p>
                    <h1>Login</h1>
                </div>
                <div class="input-group">
                    <span class="input-group-addon" id="basic-addon1">User Name</span>
                    <asp:TextBox ID="username" runat="server" class="form-control" placeholder="userid" aria-describedby="basic-addon1"></asp:TextBox>

                </div>
                <div class="input-group">
                    <span class="input-group-addon" id="basic-addon2">Password</span>
                    <asp:TextBox ID="passwd" runat="server" type="password" class="form-control" placeholder="Password" aria-describedby="basic-addon2"></asp:TextBox>

                </div>
                <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary" type="submit" OnClick="Button1_Click" />

            </div>
        </div> 
    </form>
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script>
            $(document).ready(function () {
                $('#loginWindow').animate({ 'width': '100%' }, 500)
                    .delay(30)
                    .animate({ 'height': '300px' }, 500);
                $('.page-header, .input-group, .btn')
                    .delay(850)
                    .animate({ 'opacity': '100' }, 7000);
            });

        </script>
</body>
</html>
