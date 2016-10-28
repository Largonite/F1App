$(function main() {
    var dt;
    $(document).ready(function () {
        dt = $(".dt").DataTable({
           "scrollX" : true
        });
    });

    $('.Dd').append($('<option>', {
        value: "None",
        text: 'None'
    }));

    $(".Dd").on("change", function () {
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
    });

    $(".Dd").css("width", "100%");
});