/**
 * Created by ChrisXiong on 2/9/17.
 */
$(document).ready(function () {

    var quantity = 0;


    $('.quantity-right-plus1').click(function(e){
        e.preventDefault ();
        var quantity = parseInt($('#quantity1').val());
        $('#quantity1').val(quantity + 1);
    });

    $('.quantity-left-minus1').click(function(e){
        e.preventDefault();
        var quantity = parseInt($('#quantity1').val());
        if(quantity>0){
            $('#quantity1').val(quantity - 1);
        }
    });


    $('.quantity-right-plus2').click(function(e){
        e.preventDefault ();
        var quantity = parseInt($('#quantity2').val());
        $('#quantity2').val(quantity + 1);
    });

    $('.quantity-left-minus2').click(function(e){
        e.preventDefault();
        var quantity = parseInt($('#quantity2').val());
        if(quantity>0){
            $('#quantity2').val(quantity - 1);
        }
    });

    $('.quantity-right-plus3').click(function(e){
        e.preventDefault ();
        var quantity = parseInt($('#quantity3').val());
        $('#quantity3').val(quantity + 1);
    });

    $('.quantity-left-minus3').click(function(e){
        e.preventDefault();
        var quantity = parseInt($('#quantity3').val());
        if(quantity>0){
            $('#quantity3').val(quantity - 1);
        }
    });

    $('.quantity-right-plus4').click(function(e){
        e.preventDefault ();
        var quantity = parseInt($('#quantity4').val());
        $('#quantity4').val(quantity + 1);
    });

    $('.quantity-left-minus4').click(function(e){
        e.preventDefault();
        var quantity = parseInt($('#quantity4').val());
        if(quantity>0){
            $('#quantity4').val(quantity - 1);
        }
    });

    $('.quantity-right-plus5').click(function(e){
        e.preventDefault ();
        var quantity = parseInt($('#quantity5').val());
        $('#quantity5').val(quantity + 1);
    });

    $('.quantity-left-minus5').click(function(e){
        e.preventDefault();
        var quantity = parseInt($('#quantity5').val());
        if(quantity>0){
            $('#quantity5').val(quantity - 1);
        }
    });
});