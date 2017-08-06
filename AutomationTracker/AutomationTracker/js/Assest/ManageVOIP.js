//Validation 
var sprytextfield1 = new Spry.Widget.ValidationTextField("spryAssestNo");
var sprytextfield2 = new Spry.Widget.ValidationTextField("sprySerialNo");
var sprytextfield3 = new Spry.Widget.ValidationTextField("spryENEI1");
var sprytextfield4 = new Spry.Widget.ValidationTextField("spryHDD");
var spryselect5 = new Spry.Widget.ValidationSelect("spryCompany");
var spryselect2 = new Spry.Widget.ValidationSelect("spryModel");
var spryselect3 = new Spry.Widget.ValidationSelect("spryOS");
var spryselect4 = new Spry.Widget.ValidationSelect("spryOffice");
var spryselect5 = new Spry.Widget.ValidationSelect("spryUnitType");

//Show Hide Dispose Remark
function ShowHideDiv(checkbox) {
    var dvDisposeRemark = document.getElementById("divDisposeRemark");
    dvDisposeRemark.style.display = checkbox.checked ? "none" : "block";
}

// BindData to Dropdown
$(function () {
    $("#dropUnitType").change(function () {
        debugger;
        var unitID = $('#dropUnitType').val();
        if (unitID == 5) {
            $.ajax({
                type: 'GET',
                url: "http://localhost:15707/Asset/GetModels?UnitTypeID=" + unitID,
                data: JSON.stringify({ "UnitTypeID": 1 }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    var r = result;
                    if (result != null) {
                        var dropModel = $("[id*=dropModel]");
                        dropModel.empty().append('<option selected="selected" value="0">Please select</option>');

                        $.each(result, function () {
                            dropModel.append($("<option></option>").val(this['id']).html(this['name']));
                        });

                    } else {
                        alert("fail");
                    }
                }
            });
        }
    });
});

var dropCompanyVal = $('#voips_Company').val();
$.ajax({
    type: 'GET',
    url: "http://localhost:15707/Asset/GetCompany",
    data: JSON.stringify({ "UnitTypeID": 1 }),
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (result) {
        var r = result;
        if (result != null) {
            var dropCompany = $("[id*=dropCompany]");
            dropCompany.empty().append('<option selected="selected" value="0">Please select Company</option>');

            $.each(result, function () {
                if (dropCompanyVal == this['id']) {
                    dropCompany.append($("<option selected></option>").val(this['id']).html(this['name']));
                }
                else {
                    dropCompany.append($("<option></option>").val(this['id']).html(this['name']));
                }
            });
        } else {
            alert("fail");
        }
    }
});