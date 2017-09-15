<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ManageItem.aspx.cs" Inherits="Laundry_Platypus.ManageItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Complete Workwear</title>

    <meta name="description" content="Source code generated using layoutit.com">
    <meta name="author" content="LayoutIt!">

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
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
		<div class="auto-style1">
			<table class="table table-hover">
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
							Action
						</th>
					</tr>
				</thead>
                <tbody>
                       <asp:DataList ID="DataList1" runat="server">
                        <EditItemStyle Width="800px" />
    
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
                </asp:DataList>
                    
                </tbody>
			</table>
			<a id="modal-add" href="#modal-container-add" role="button" class="btn btn-primary" data-toggle="modal">Add Item</a>
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

                            <asp:Button ID="Button2" runat="server" Text="Add" OnClick="Add_Click" type="button" class="btn btn-primary" data-dismiss="modal"/>
							
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
                            <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Save_Edit_Click" type="button" class="btn btn-primary" data-dismiss="modal"/>
						
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
    <script>
        function edit(obj) {
            var selectedTr = obj;
            var itemId = selectTr.cells[0].childNodes[0].value;
            document.cookie = "item_id = {itemId}";
            window.location.href = "#modal-container-edit";
        }
    </script>
</asp:Content>
