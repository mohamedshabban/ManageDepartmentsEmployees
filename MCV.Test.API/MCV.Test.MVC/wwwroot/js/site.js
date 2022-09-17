// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


<script type="text/javascript">
    $(document).ready(
    function() {
        alert("1");
    var data = $("#employee").val();
    alert("2");
    $.ajax({

        url :'http://localhost:8080/online/fecthcourse',
    type :'GET',
    dataType :'JSON',
    success :function(data) {
        alert("3");
    $(data).each(
    function() {
        $('#tbody').append(
            '<tr><td>' + this.id
            + '</td><td>'
            + this.question
            + '</td><td>'
            + this.course
            + '</td><td>'
            + this.answerEntities
            + '</td><td>'
            + this.ans
            + '</td><td>'
            + this.status
            + '</td></tr>')
    });
                },
    error :function(data) {
        alert("4");
                }
 
            });
        });
</script>
