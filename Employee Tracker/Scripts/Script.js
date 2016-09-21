var empScript = (function () {
    
    var init = function () {
        $('#saveEmployee').click(function () { onSaveEmpClick(); });
    };

    var onSaveEmpClick = function () {
        $.ajax('/Home/AddEmployee', {
            async: true,
            data: {
                name: $('#name').val(),
                gender: $('#gender').val(),
                salary: $('#salary').val(),
                rating: $('#rating').val(),
                department: $('#department').val()
            },
            type: 'POST',
            success: onSavedEmp
        });
    };

    var onSavedEmp = function(){
        $("#name, #gender, #salary, #rating, #department").val('');
    };

    return {
        init: init
    };
})();

$(document).ready(empScript.init);