$(function () {
    var refreshTable = function () {
        var $a = $(this);

        // Create the options for an ajax request:
        // - type is Get
        // - target url comes from the eelement href attribute
        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        // Perform the ajax request
        $.ajax(options).done(function (data) {
            // When the response is received, replace the existing table with the new table
            var target = $a.parents("div.async-table-host");
            target.replaceWith(data);
        });
        // Prevent the normal link operation
        return false;
    };

    // Refresh the table async
    // Handle clicking on a link in the table, and convert it into an async request
    //$(".body-content").on("click", ".async-table-host.async-table-link a", refreshTable);
    $(".body-content").on("click", ".async-table-host a.async-table-link", refreshTable);
});