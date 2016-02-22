/*=============================================================
    Authour URL: www.designbootstrap.com
    
    http://www.designbootstrap.com/

    License: MIT

    http://opensource.org/licenses/MIT

    100% Free To use For Personal And Commercial Use.

    IN EXCHANGE JUST TELL PEOPLE ABOUT THIS WEBSITE
   
========================================================  */

$(document).ready(function () {

    /*====================================
           METIS MENU 
     ======================================*/

    $('#main-menu').metisMenu();

    /*======================================
    LOAD APPROPRIATE MENU BAR ON SIZE SCREEN
    ========================================*/

    $(window).bind("load resize", function () {
        if ($(this).width() < 768) {
            $('div.sidebar-collapse').addClass('collapse')
        } else {
            $('div.sidebar-collapse').removeClass('collapse')
        }
    });
    /*======================================
   WRITE YOUR SCRIPTS BELOW
   ========================================*/


    $.material.init();
});

$(document).on('keyup', 'input[data-val-required]', function () {
    var $this = $(this);
    $formGroup = $this.parent('.form-group');

    if ($formGroup != 'undefined') {
        if ($this.val() == '') {
            $formGroup.first().addClass('has-error');
        } else {
            $formGroup.removeClass('has-error');
        }
    }

});

$(document).on('change', 'select[data-val-required]', function () {
    var $this = $(this);
    $formGroup = $this.closest('.form-group');

    if ($formGroup != 'undefined') {
        if ($this.val() == '') {
            $formGroup.addClass('has-error');
        } else {
            $formGroup.removeClass('has-error');
        }
    }
});

//$(document).on('submit', 'form', function (e) {
//    var $this = $(this);
    
//    $this.find('select').trigger('change');
//    $this.find('input').trigger('keyup');
    
//    if ($('.has-error').length > 0) {
//        e.preventDefault();
//    }

//});