//Validation
var sprytextfield1 = new Spry.Widget.ValidationTextField("spryFullName");
var sprytextfield2 = new Spry.Widget.ValidationTextField("spryNIC");
var sprytextfield3 = new Spry.Widget.ValidationTextField("sprySAPNo");
var spryselect1 = new Spry.Widget.ValidationSelect("spryTitle");
var spryselect2 = new Spry.Widget.ValidationSelect("spryCompany");
var spryselect3 = new Spry.Widget.ValidationSelect("spryMarket");


$("#dropCompany").change(function () {
    var CompanyID = $('#dropCompany').val();
        $.ajax({
            type: 'GET',
            url: "http://localhost:15707/Account/GetMarkets?CompanyID=" + CompanyID,
            data: JSON.stringify({ "UnitTypeID": 1 }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                var r = result;
                if (result != null) {
                    var dropMarket = $("[id*=dropMarket]");
                    dropMarket.empty().append('<option selected="selected" value="0">Please select</option>');

                    $.each(result, function () {
                        dropMarket.append($("<option></option>").val(this['id']).html(this['name']));
                    });

                } else {
                    alert("fail");
                }
            }
        });
});


var UserID = $('#user_UserID').val();
$(document).ready(function () {
    var ckbox = $('#checkbox3');
    $('input').on('click', function () {
        if (ckbox.is(':checked')) {
            $('#btnSubmit').prop("disabled", false);
        } else {
            $.ajax({
                type: 'GET',
                url: "http://localhost:15707/Account/CheckUserAssest?UserID=" + UserID,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    var r = result;
                    if (result == 1) {
                        alertify.set('notifier', 'delay', 15);
                        alertify.set('notifier', 'position', 'top-center');
                        alertify.error('Assest are already Assign to This User. Please Trasnfer all Assest To IT Pool before Inactive User');
                        $('#btnSubmit').prop("disabled", true);
                    } else {

                    }
                }
            });

        }
    });
});