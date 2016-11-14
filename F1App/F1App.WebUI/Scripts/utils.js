$(function main() {
    var dt;
    $(document).ready(function () {
        dt = $(".dt").DataTable({
           "scrollX" : true
        });
    });

    /*$(".Dd").on("change", function () {
        var column = dt.column($(this).attr('column'));
        if (this.value === "None") {
            column.visible(false);
        } else if (this.value !== "") {
            column.visible(true);
            if ($(this).attr("withid") === "True") {
                console.log("withId");
                dt.column($(this).attr("column")).search(this.value, true, false).draw();
            } else {
                console.log("without Id");
                dt.column($(this).attr("column")).search('^' + this.value + '$', true, false).draw();
            }
        } else {
            column.visible(true);
            dt.column($(this).attr("column")).search('').draw();
        }
    });*/

    $(".Dd").css("width", "100%");

    $(".edit").on("click", function () {
        var tr = $(this).closest("tr");
        var td = $(this).closest("td");
        $(td).find("button").each(function () {
            if ($(this).hasClass("hidden")) {
                $(this).removeClass("hidden");
            } else {
                $(this).addClass("hidden");
            }
        })

        $(tr).children().each(function () {
            var temp = this.innerHTML;
            if (!$(this).hasClass("crud")) {
                this.innerHTML = '<div class="form-group"><input name="' + $(this).attr("name") + '" class="form-control" type="text" value="' + temp + '" size=' + temp.length + '></input></div>'
            }
        });

        $(".edit").attr("disabled", "disabled");
        $(".remove").attr("disabled", "disabled");
    });

    $(".cancel").on("click", function () {
        var tr = $(this).closest("tr");
        var td = $(this).closest("td");
        $(td).find("button").each(function () {
            if ($(this).hasClass("hidden")) {
                $(this).removeClass("hidden");
            } else {
                $(this).addClass("hidden");
            }
        })


        $(tr).children().each(function () {
            var input = $(this).find("input")[0];
            if (input) {
                var temp = input.value;
                if (!$(this).hasClass("crud")) {
                    this.innerHTML = temp;
                }
            }
        });
        $(".edit").removeAttr("disabled");
        $(".remove").removeAttr("disabled");
    });

    $("#submitButton").on("click", function () {
        editPilot($(this));
    });

});

function confirmDelete(msg, location) {
    if (confirm(msg) === true) {
        document.location.href = location;
    }
}

function editPilot(button) {
    var tr = button.closest("tr");
    var data = {};

    $(tr).find("input").each(function () {
        data[$(this).attr("name")] = $(this).val();
    });

    var jsonData = JSON.stringify(data);
    console.log(jsonData);
    $.ajax({
        type: "POST",
        url: "EditPilot",
        contentType: "json",
        data: jsonData,
        error: function (e) {
            console.log("error edit pilot : " + e);
        }
    });
}