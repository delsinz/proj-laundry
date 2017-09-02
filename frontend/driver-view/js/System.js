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
        //up = '▲',
        //down = '▼',
        $orderTable = $('#orderTable'),
        $orderTableBody = $orderTable.find('tbody'),
        rowTemplate = '<tr data-ID="{OrderID}"><td>{OrderID}</td><td ><a href="#">{Status}</a></td></tr>';

    function formatOrder(order) {
        return $.extend(order, {
            ID: order.ID,
            State: order.State
          
        });
    }

    function init() {
        clientHub.server.getAllOrder().done(function (order) {
            $orderTableBody.empty();
            $.each(order, function () {
                var order = formatOrder(this);
                $orderTableBody.append(rowTemplate.supplant(order));
            });
        });
    }

    // Add a client-side hub method that the server will call
    clientHub.client.updateOrder = function (order) {
        var displayOrder = formatOrder(order),
            $row = $(rowTemplate.supplant(displayOrder));

        $orderTableBody.find('tr[data-ID=' + order.ID + ']')
            .replaceWith($row);
    }

    // Start the connection
    $.connection.hub.start().done(init);

});