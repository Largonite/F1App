$(function main() {
    var dt;
    $(document).ready(function () {
        dt = $(".dt").DataTable();
    });

    $(".Dd").on("change", function () {
        if (this.value !== "") {
            if ($(this).attr("withid")) {
                dt.column($(this).attr("column")).search(this.value, true, false).draw();
            } else {
                dt.column($(this).attr("column")).search('^' + this.value + '$', true, false).draw();
            }
        } else {
            dt.column($(this).attr("column")).search('').draw();
        }
    })
});