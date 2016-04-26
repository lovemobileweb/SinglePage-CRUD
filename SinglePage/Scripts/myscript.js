jQuery(function ($) {
    // Add event listener for opening and closing details
    $('#example tbody').on('click', 'span.details-control', function () {
        var tr = $(this).closest('tr');
        var detailedtr = tr.next();
        if (detailedtr.hasClass('detail-hidden') == true)
            detailedtr.removeClass('detail-hidden');
        else
            detailedtr.addClass('detail-hidden');
    });

    $('#example tbody').on('click', 'span.delete-control', function () {
        var tr = $(this).closest('tr');
        var detailedtr = tr.next();
        var btnDelete = detailedtr.find('.btn_delete_submit');
        btnDelete[0].click();
    });

    $('.btn_edit_submit').on('click', function () {
        var form = $(this).parents('form')[0];
        form.action = form.action.replace("/Delete", "/Edit");
        //form.submit();
    });

    $('.btn_delete_submit').on('click', function () {
        if (confirm("Are you sure you want to delete the item?") == true)
        {
            var form = $(this).parents('form')[0];
            form.action = form.action.replace("/Edit", "/Delete");
            //form.submit();
        }
    });

    $('td form').submit(function (e) {
        e.preventDefault();
        var form = $(this);
        $.post(form.attr("action"), form.serialize(), function (r) {
            if (r.indexOf("Edit_Invalid") >= 0)
                $("#Details").html(r);
            else
                location.reload();
        });
    });

    $('.from-btn-search').on('click', function () {
        var form = $(this).parents('form');
        $(this).parent().next('input').click();
    });

    $('.form-date').datepicker({
        dateFormat: 'yy/mm/dd'
    });

    $(".dropdown-analyst").shieldComboBox({
        dataSource: {
            remote: {
                read: "/Analyst/Index",
                param: "?key=",
                value: ".dropdown-analyst"
            },
            schema: {
                data: "components"
            },
            filter: {
                or: [
                    { path: "n", filter: "contains", value: "" }
                ]
            }
        },
        autoComplete: {
            enabled: true
        },
        textTemplate: "{n}",
        valueTemplate: "{n}",
        events: {
            select: function (e) {
                //$(".dropdown-analyst-value").focus();
                if (e.index >= 0)
                    $(".dropdown-analyst-Value").val($(".dropdown-analyst").val());
                else
                    $(".dropdown-analyst-Value").val("");
                $(".dropdown-analyst").trigger("onchange");
                $(".dropdown-analyst-Value").trigger("onchange");
                //$(".dropdown-analyst").focus();
            }
        }
    });
});
