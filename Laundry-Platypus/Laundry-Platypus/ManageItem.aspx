<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ManageItem.aspx.cs" Inherits="Laundry_Platypus.ManageItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Complete Workwear</title>

    <meta name="description" content="Source code generated using layoutit.com">
    <meta name="author" content="LayoutIt!">

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/itemStyle.css" rel="stylesheet">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: -2147483648%;
            left: 0px;
            top: 0px;
            height: 455px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid">
	<div class="row">
		<div class="col-md-12">
            <asp:HiddenField ID="itemId" runat="server" />

            <asp:DataList ID="DataList1" runat="server" Width="100%" onitemcommand="DataList1_ItemCommand" >
                 
                <HeaderTemplate>
                <table class="table table-hover"  >
                    <thead>
                        <tr>
                            <th>
                                Item ID
                            </th>
                            <th>
                                Name
                            </th>
                            <th>
                                Abbreviation
                            </th>
                            <th>
                                Actions
                            </th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                     <tbody>
                         <tr>
                            <td>
                                <asp:Label ID="Item_ID" runat="server" ></asp:Label>
                                <%#DataBinder.Eval(Container.DataItem, "garment_id")%>
                            </td>
                            
                            <td>

                                <asp:Label ID="Item_Name" runat="server" Font-Size="9pt" Height="19px" Width="1px"></asp:Label>
                                <%#DataBinder.Eval(Container.DataItem, "type_name")%>
                            </td>
                            <td>

                                <asp:Label ID="Label1" runat="server" Font-Size="9pt" Height="19px" Width="1px"></asp:Label>
                                <%#DataBinder.Eval(Container.DataItem, "abbreviation")%>
                            </td>
                            
                            <td>
                                <input type="button" name="Submit" value="Edit" onclick="edit(this)" class="btn btn-default"/>
                                
                                <asp:Button ID="Button3" class="btn btn-danger" runat="server"  Text="Remove" CommandName="remove" />
                            </td>                           
                        </tr>
                     </tbody>   
                </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
            </asp:DataList>
                    			
			<a id="modal-add" href="#modal-container-add" role="button" class="btn btn-primary" data-toggle="modal">Add Item</a>
            
            <asp:Button ID="Button4" runat="server" Text="Test" OnClick="Test"/>
            <!-- Start Add Item Modal -->
			<div class="modal fade" id="modal-container-add" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">

							<button type="button" class="close" data-dismiss="modal" aria-hidden="true">
								×
							</button>
							<h4 class="modal-title" id="add-modal-label">
								Add Item
							</h4>
						</div>
						<div class="modal-body">
                            <div class="form-group">
                                <label for="name-add">Name:</label>
                                <asp:TextBox ID="AddNameTextBox" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="abb-add">Abbreviation:</label>
                                <asp:TextBox ID="AddAbbrTextBox" runat="server" class="form-control"></asp:TextBox>
                            </div>
						</div>
						<div class="modal-footer">
							<button type="button" class="btn btn-default" data-dismiss="modal">
								Cancel
							</button>

                            <asp:Button ID="Button2" runat="server" Text="Add" OnClick="Add_Click" type="button" class="btn btn-primary" UseSubmitBehavior="false" data-dismiss="modal"/>
							
						</div>
					</div>
				</div>
			</div>
            <!-- End Add Item Modal -->
            <!-- Start Edit Item Modal -->
			<div class="modal fade" id="modal-container-edit" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">

							<button type="button" class="close" data-dismiss="modal" aria-hidden="true">
								×
							</button>
							<h4 class="modal-title" id="edit-modal-label">
								Edit Item
							</h4>
						</div>
						<div class="modal-body">
                            <div class="form-group">
                                <label for="name-add">Name:</label>
                                <asp:TextBox ID="NameTextBox" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="abb-add">Abbreviation:</label>
                                <asp:TextBox ID="AbbrTextBox" runat="server" class="form-control"></asp:TextBox>
                                
                            </div>
						</div>
						<div class="modal-footer">
							<button type="button" class="btn btn-default" data-dismiss="modal">
								Cancel
							</button>
                            <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Save_Edit_Click" type="button" class="btn btn-primary" UseSubmitBehavior="false"  data-dismiss="modal"/>
						
						</div>
					</div>
				</div>
			</div>
            <!-- End Edit Item Modal -->
		</div>
	</div>
</div>
    
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/scripts.js"></script>
    <script src="js/cookie.min.js"></script>
    
    <script>
        function edit(obj) {
            
            var itemId = $(obj).parent().siblings(":first").text();
            //var msg = document.getElementById('itemId');
            //var value = msg.value;
            //msg.value = '1';
                //$(obj).parent().siblings(":first").text();
            
            document.cookie = "itemId =" + itemId + ";" 
            //document.cookie = "itemId=" + itemId + "; expires=Wed, 1 Jan 2070 13:47:11 UTC; path=/"
            //document.cookie = 'itemId =' + display + '; expires=Wed, 1 Jan 2070 13:47:11 UTC; path=/';
            //var x = document.cookie
            //alert(msg);

             jQuery.noConflict(); 
             $('#modal-container-edit').modal('show');
             
        }
        
    </script>

     

        
</asp:Content>
