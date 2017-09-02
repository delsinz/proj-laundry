
/// <reference path="/Scripts/jquery-1.6.4.min.js" />
/// <reference path="/Scripts/jquery.signalR-2.2.2.min.js" />
/// <reference path="/signalr/hubs" />

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
    //var connection = $.hubConnection();
    //var clientHub = connection.createHubProxy('clientHub');
    var clientHub = $.connection.clientHub123; // the generated client-side hub proxy
    //var clientHub = connection.createHubProxy('clientHub123');
    var $orderTable = $('#orderTable'),
        $orderTableBody = $orderTable.find('tbody'),
        rowTemplate = '<tr data-ID="{OrderID}"><td>{OrderID}</td><td ><a href="#">{Status}</a></td></tr>';
    //alert("clientHub successfully");
    function formatOrder(order) {
        return $.extend(order, {
            ID: order.ID,
            State: order.State

        });
    }

    function init() {
        var userid = document.cookie.split(";")[0].split("=")[1];
        alert(userid);
        clientHub.server.getAllOrder().done(function (order) {
            $orderTableBody.empty();
            $.each(order, function () {
                var order = formatOrder(this);
                $orderTableBody.append(rowTemplate.supplant(order));
            });
        });
        alert("init successfully");
    }

    // Add a client-side hub method that the server will call
    clientHub.client.updateOrder = function (order) {
        var displayOrder = formatOrder(order),
            $row = $(rowTemplate.supplant(displayOrder));

        $orderTableBody.find('tr[data-ID=' + order.ID + ']')
            .replaceWith($row);
    };

    // Start the connection
    $.connection.hub.start().done(init);

});