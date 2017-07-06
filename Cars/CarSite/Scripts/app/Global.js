
var SearchController = (function () {

    var _carManufacturerWithModel = [];
    var _mainselector;
    var _subselector;
    var _mainselected;
    var _subselected;


    var getCarManufacturerWithModel = function (mainselector, subselector, mainselected, subselected) {

        _mainselector = mainselector;
        _subselector = subselector;
        _mainselected = mainselected;
        _subselected = subselected;

        getcarManufacturerData();
        $(_mainselector).change(getcarModelData);
        return this;


    };




    var getcarManufacturerData = function () {

        $.ajax({
            type: "GET",
            url: "/api/search",
            success: function (data) {

                _carManufacturerWithModel = data;




                $(_mainselector).empty();
                $(_mainselector).append('<option value="">Select</option>');
                $(data).each(function (i, e) {
                    $(_mainselector).append('<option value="' + e.Id + '">' + e.Name + '</option>');

                }
                );




                if (_mainselected != undefined) {
                    var _mainselectorvalue = $(_mainselector).val(_mainselected).change();

                }





            }
        });


    };


    var getcarModelData = function getcarModelData(e) {


        $(_subselector).empty();
        $(_subselector).append('<option value="">Select</option>');

        var index = $(_mainselector + ' option:selected').index();



  
        if (index <= 0) {
            return;
        }

        try {
            var carModel = _carManufacturerWithModel[index - 1].Model;
            $(carModel).each(function (i, e) {

                $(_subselector).append('<option value="' + e.Id + '">' + e.Model + '</option>');



            });

        } catch (e) {
            

        }

    

        if (_subselected != undefined) {
            $(_subselector).val(_subselected).change();
        }


    };

    var getBranchesData = function (selector, selected) {
        $.ajax({
            type: "GET",
            url: "/api/branch",
            success: function (data) {
                var s = $(selector);
                s.empty();
                s.append('<option value="">Select</option>');


                for (var i = 0; i < data.length; i++) {

                    s.append('<option value="' + data[i].Id + '">' + data[i].Name + '</option>');
                }

                if (selected != undefined)
                    $(s).val(selected).change();

            }
        });

        return this;
    };

    datepicker = function (selector) {
        $(selector).datepicker({
            format: 'dd/mm/yyyy',
            startDate: '-3d'
          
           
           
        });



  
        return this;
    };

    return {
        getCarManufacturerWithModel: getCarManufacturerWithModel,
        getBranchesData: getBranchesData,
        datepicker: datepicker


    };
})();

var DeletehController = (function () {

    var _target, _url;


    var init = function (url) {
        _url = url
        $('.postdelete').click(DeleteFromList)

    };

    var DeleteFromList = function (event) {
        event.preventDefault();
        _target =$( event.target);

   


        var r = bootbox.confirm(_target.attr('data-message'), function (result) {
            if (result) {
                DeleteData();

            };
        });

    };

    var DeleteData=function () {
        $.ajax({
            type: "DELETE",
            url: _url + "/" + _target.attr('data-delete-id'),
            success: function () {

                $('#tr' + _target.attr('data-delete-id')).hide();



            }
        });

    }
    return {
        init: init
    

    };

})();


function getCookie(name) {
    var nameEquals = name + "=";
    if (document.cookie.split(nameEquals)[1] == undefined)
        return;



    var whole_cookie = document.cookie.split(nameEquals)[1].split(";")[0];


    return whole_cookie;
};


function setCookie(name, value) {
   
    document.cookie = name + "=" + value + "; path=/";
   
};


function datepicker(selector) {
        $(selector).datepicker({
            format: 'dd/mm/yyyy',
            startDate: '-3d'
        });
        $(selector).change(function () {
           
            var d = $(selector).val();

            $(selector).val(new Date(d).today());
        });

        $(selector).mousedown(function () {

            var d2 = $(selector).val();

            $(selector).val("");


        });
        
};

Date.prototype.today = function () {
    return ((this.getDate() < 10) ? "0" : "") + this.getDate() + "/" + (((this.getMonth() + 1) < 10) ? "0" : "") + (this.getMonth() + 1) + "/" + this.getFullYear();
}




// For the time now
Date.prototype.timeNow = function () {
    return ((this.getHours() < 10) ? "0" : "") + this.getHours() + ":" + ((this.getMinutes() < 10) ? "0" : "") + this.getMinutes() + ":" + ((this.getSeconds() < 10) ? "0" : "") + this.getSeconds();
}


