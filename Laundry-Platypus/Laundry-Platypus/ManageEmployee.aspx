<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="ManageEmployee.aspx.cs" Inherits="Laundry_Platypus.ManageEmployee" %>
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
	<div class="row">
		<div class="col-md-12">
			<asp:HiddenField ID="Hidden1" runat="server" />
            <asp:HiddenField ID="HiddenEditRole" runat="server" />
            <asp:HiddenField ID="HiddenEditStatus" runat="server" />
            <asp:DataList ID="DataList1" runat="server" Width="100%" >
			    <HeaderTemplate>
                    <table class="table table-hover"  >
                        <thead>
                            <tr>
                                <th>
                                    Employee ID
                                </th>
                                <th>
                                    Name
                                </th>
                                <th>
                                    Role
                                </th>
                                <th>
                                    Status
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
                                <asp:Label ID="User_ID" runat="server" ></asp:Label>
                                <%#DataBinder.Eval(Container.DataItem, "user_id")%>
                            </td>
                            <td>
                                <asp:Label ID="User_Name" runat="server" Font-Size="9pt" Height="19px" Width="1px"></asp:Label>
                                <%#DataBinder.Eval(Container.DataItem, "user_name")%>
                            </td>
                            <td>
                                <asp:Label ID="User_Role" runat="server" Font-Size="9pt" Height="19px" Width="1px"></asp:Label>
                                
                                <%#DataBinder.Eval(Container.DataItem, "role_name")%>
                            </td>
                            <td> 
                                  
                                <asp:Label ID="Label1" runat="server" Font-Size="9pt" Height="19px" Width="1px" Text='<%# Eval("user_active").Equals("1")?"active":"inactive" %>'></asp:Label>
                                       
                            </td>
                            <td>
                                <input type="button" name="Submit" value="Edit" onclick="edit(this)" class="btn btn-default"/>
                                <input type="button" name="Submit" value="Active" onclick="active(this)" class="btn btn-success"/>
                                <input type="button" name="Submit" value="Inactive" onclick="inactive(this)" class="btn btn-danger"/>  
                            </td> 
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:DataList>	
			
            <!-- Start Add User Modal -->
            <a id="modal-add" href="#modal-container-add" role="button" class="btn btn-primary" data-toggle="modal">Add User</a>
            <!-- Start Add User Modal -->
			<div class="modal fade" id="modal-container-add" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content"> 
						<div class="modal-header">

							<button type="button" class="close" data-dismiss="modal" aria-hidden="true">
								×
							</button>
							<h4 class="modal-title" id="add-modal-label">
								Add User
							</h4>
						</div>
						<div class="modal-body">
                            <div class="form-group">
                                <label for="name-add">Name:</label>
                                <asp:TextBox ID="AddNameTextBox" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="abb-add">Role:</label>
                                <asp:DropDownList ID="add_role_list" runat="server" UseSubmitBehavior="false">
                                    <asp:ListItem Text="Manager" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Packer" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Driver" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Customer" Value="4"></asp:ListItem> 
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="abb-add">Status:</label>
                                <asp:DropDownList ID="add_status_list" runat="server" UseSubmitBehavior="false">
                                    <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                                </asp:DropDownList>
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
            <!-- End Add User Modal -->
            <!-- Start Edit User Modal -->
			<div class="modal fade" id="modal-container-edit" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
								×
							</button>
							<h4 class="modal-title" id="edit-modal-label">
								Edit User
							</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label for="name-add">Name:</label>
                                <asp:TextBox ID="EditNameTextBox" runat="server" class="form-control"></asp:TextBox>                      
                            </div>
                            <div class="form-group">
                                <label for="abb-add">Role:</label>
                                <asp:DropDownList ID="edit_role_list" runat="server" UseSubmitBehavior="false">
                                    <asp:ListItem Text="Manager" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Packer" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Driver" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Customer" Value="4"></asp:ListItem> 
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
								Cancel
							</button>
							<asp:Button ID="Button5" runat="server" Text="Save" OnClick="Save_Edit_Click" type="button" class="btn btn-primary" UseSubmitBehavior="false" data-dismiss="modal"/>
                        </div>
                    </div>
                </div>									 				  
			</div>
            <!-- End Edit User Modal -->
            <!-- Start Active User Modal -->
			<div class="modal fade" id="modal-container-active" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">

							<button type="button" class="close" data-dismiss="modal" aria-hidden="true">
								×
							</button>
							<h4 class="modal-title" id="acitve-modal-label">
								 Active
							</h4>
						</div>
                        <div class="modal-body">
                            <br />
                            <br />
                            <h4 class="modal-title"  >
								 Do you want to set this user to active?
							</h4>
                            <br />
                            <br />
                        </div>
						
						<div class="modal-footer">
							<button type="button" class="btn btn-default" data-dismiss="modal">
								Cancel
							</button>
                            <asp:Button ID="Button3" runat="server" Text="Ok" OnClick="Save_Active_Click" type="button" class="btn btn-primary" UseSubmitBehavior="false"  data-dismiss="modal"/>
						
						</div>
					</div>
				</div>
			</div>
            <!-- End Active User Modal -->
            <div class="modal fade" id="modal-container-inactive" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">

							<button type="button" class="close" data-dismiss="modal" aria-hidden="true">
								×
							</button>
							<h4 class="modal-title" id="inactive-modal-label">
								 Inactive
							</h4>
						</div>
                        <div class="modal-body">
                            <br />
                            <br />
                            <h4 class="modal-title"  >
								 Do you want to set this user to inactive?
							</h4>
                            <br />
                            <br />
                        </div>
						
						<div class="modal-footer">
							<button type="button" class="btn btn-default" data-dismiss="modal">
								Cancel
							</button>
                            <asp:Button ID="Button1" runat="server" Text="Ok" OnClick="Save_Inactive_Click" type="button" class="btn btn-primary" UseSubmitBehavior="false"  data-dismiss="modal"/>
						
						</div>
					</div>
				</div>
			</div>
            <!-- End Inactive User Modal -->
		</div>
	</div>
</div>

    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/scripts.js"></script>
    <script>
        $(".modal-body input").val("")

        function edit(obj) {

            var userId = $(obj).parent().siblings(":first").text();
            document.getElementById('<% =Hidden1.ClientID %>').value = userId;

            jQuery.noConflict();
            $('#modal-container-edit').modal('show');

        }

        function active(obj) {

            var userId = $(obj).parent().siblings(":first").text();
            document.getElementById('<% =Hidden1.ClientID %>').value = userId;

            jQuery.noConflict();
            $('#modal-container-active').modal('show');

        }
        function inactive(obj) {

            var userId = $(obj).parent().siblings(":first").text();
            document.getElementById('<% =Hidden1.ClientID %>').value = userId;

            jQuery.noConflict();
            $('#modal-container-inactive').modal('show');

        }
 


    </script>
</asp:Content>
