var mainselected, subselected, transmission, startdate, enddate;

if (getCookie('carManufacturer') != undefined)
    mainselected = getCookie('carManufacturer');


if (getCookie('carModel') != undefined)
    subselected = getCookie('carModel');

if (getCookie('transmission') != undefined) 
    transmission = getCookie('transmission');
   
if (getCookie('startdate') != undefined)
    startdate = getCookie('startdate');

if (getCookie('enddate') != undefined)
    enddate = getCookie('enddate');


  






$(document).ready(function () {

    $("#transmission").val(transmission);
    $("#startdate").val(startdate);
    $("#enddate").val(enddate);
    

    
    
    SearchController.datepicker('.startdate').datepicker('.enddate')
        .getCarManufacturerWithModel('#carManufacturer', '#carModel', mainselected, subselected);

    $("form").submit(function () {
            setCookie("carManufacturer", $("#carManufacturer").val());
            setCookie("carModel", $("#carModel").val());
            setCookie("transmission", $("#transmission").val());
            setCookie("startdate", $("#startdate").val());
            setCookie("enddate", $("#enddate").val());
  

        var $startdate = $("#startdate");
            var $enddate = $("#enddate");
        var $sdate = $("#sdate");
            var $edate = $("#edate");

        if ($startdate.val() == "")
        {
            $sdate.text("Required field");
            return false;
        }

        if ($enddate.val() == "") {
            $edate.text("Required field");
            return false;
        }
       

        var dsatart = new Date($startdate.val());
        var dend = new Date($enddate.val());

        if (dend < dsatart )
        {
            $edate.text("Required field");
            return false;
        }

        return true;
    }

);

   

    
 

    function replaceAll(str, find, replace) {
        return str.replace(new RegExp(find, 'g'), replace);
    }


});