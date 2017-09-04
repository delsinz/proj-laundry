// This is a sample js mocking from offical direaction
if (!String.prototype.supplant) {
    String.prototype.supplant = function (o) {
        return this.replace(/{([^{}]*)}/g,
            function (a, b) {
                var r = o[b];
                return typeof r === 'string' || typeof r === 'number' ? r : a;
            }
        );
    };
}

$(function () {

    var clientHub = $.connection.clientHub, // the generated client-side hub proxy
        $orderTable = $('#orderTable'),
        $orderTableBody = $orderTable.find('tbody'),
        rowTemplate = '<tr data-OrderID="{OrderID}"><td> {OrderID} </td><td> {CustomerName} </td><td > <a href="#"> {StateName} </a></td></tr>';
   
    function formatOrder(order) {
        return $.extend(order, {
            OrderID: order.ID,
            StateID: order.State,
            CustomerName: order.CustomerName,
            StateName: order.StateName,
            CustomerID: order.CustomerID

        });
       
    }

    function init() {
        var userid = document.cookie.split("&")[0].split("=")[2]; 
        var passwd = document.cookie.split("&")[1].split("=")[1]; 
        //alert(userid + passwd);
        //alert("clientHub created successfully");
        clientHub.server.getAllOrder(userid+";"+passwd).done(function (order) {
            $orderTableBody.empty();
            $.each(order, function () {
                // 
                var order = formatOrder(this);
                $orderTableBody.append(rowTemplate.supplant(order));
            });
        });
    }

    // Add a client-side hub method that the server will call
    clientHub.client.updateOrder = function (order) {
        var displayOrder = formatOrder(order),
            $row = $(rowTemplate.supplant(displayOrder));

        $orderTableBody.find('tr[data-OrderID=' + order.ID + ']')
            .replaceWith($row);
    };

    //insert order 

    // Start the connection
    $.connection.hub.start().done(init);


});