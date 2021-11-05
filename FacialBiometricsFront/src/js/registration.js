import $ from "jquery";

let next = $(document).ready(function() {
    var current_fs, next_fs, previous_fs; //fieldsets
    var opacity;
    var current = 1;
    var steps = $("fieldset").length;

    $(".next").click(function() {
        console.log($(this));

        current_fs = $(this).parent();
        next_fs = $(this).parent().next();

        $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

        next_fs.show();

        current_fs.animate({opacity: 0}, {
            step: function(now) {
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative',
                });

                next_fs.css({'opacity': opacity});
            },

            duration: 500
        });
    });

    $(".previous").click(function(){
        current_fs = $(this).parent();
        previous_fs = $(this).parent().prev();

        $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

        previous_fs.show();

        current_fs.animate({opacity: 0}, {
            step: function(now) {
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                
                previous_fs.css({'opacity': opacity});
            },
            
            duration: 500
        });
    });
});

export default next;