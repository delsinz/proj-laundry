<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ViewForm.aspx.cs" Inherits="Laundry_Platypus.ViewForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Complete Workwear</title>

    <meta name="description" content="Source code generated using layoutit.com">
    <meta name="author" content="LayoutIt!">

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/itemStyle.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class ="well">
            <div class="form-group">
                <label class="col-md-2">Start Date: </label>
                <div class="col-md-4">
                    <asp:TextBox ID="datebegin" runat="server" type="date" class="form-control" placeholder="yyyy-mm-dd"  aria-describedby="basic-addon2" lang="en"></asp:TextBox>
                </div>
                <label class="col-md-2">End Date: </label>
                <div class="col-md-4">
                    <asp:TextBox ID="dateend" runat="server" type="date" class="form-control" placeholder="yyyy-mm-dd"  aria-describedby="basic-addon2" lang="en"></asp:TextBox>
                </div>
                
            </div>   

            <div class="form-group">
                <div class="col-md-2">
                    <asp:CheckBox ID="CheckBox1" Text="Select Customer " runat="server" />
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="CustomerDropList" runat="server" EnableTheming="False" class="form-control"></asp:DropDownList>
                </div> 
                <div class="col-md-2">
                    <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-info" /> 
                    
               </div>

                <div class="col-md-2">
                    
                    <label>Total Price:</label>
                    <asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
               </div>


            </div>

        </div>     
    </div>

    
     
    
   <asp:Repeater ID="rpTest" runat="server">
   <HeaderTemplate>
     <table class="table table-hover">
       <tr>
         <th>OrderID</th>
         <th>Customer</th>
         <th>Price</th>
       </tr>
   </HeaderTemplate>

   <ItemTemplate>
       
           <tr>
             <td><asp:Label runat="server" ID="lblID" Text='<%# Eval("order_id") %>'></asp:Label></td>
             <td><asp:Label runat="server" ID="lblTitle" Text='<%# Eval("first_name") %>'></asp:Label></td>
             <td><asp:Label runat="server" ID="lblText" Text='<%# Eval("total_price") %>'></asp:Label></td>
           </tr>
        
   </ItemTemplate>
   <AlternatingItemTemplate>
       
           <tr>
              <td><asp:Label runat="server" ID="lblID" Text='<%# Eval("order_id") %>'></asp:Label></td>
              <td><asp:Label runat="server" ID="lblTitle" Text='<%# Eval("first_name") %>'></asp:Label></td>
              <td><asp:Label runat="server" ID="lblText" Text='<%# Eval("total_price") %>'></asp:Label></td>
            </tr>
          
   </AlternatingItemTemplate>
   <FooterTemplate>
     </table>
   </FooterTemplate>
 </asp:Repeater>
    
</asp:Content>
