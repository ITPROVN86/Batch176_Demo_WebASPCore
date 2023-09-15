var staff = {
    init: function () {
        staff.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/Staff/ChangeStatus",
                data: { id: id },
                datatype: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text('Nam');
                        btn.removeClass('btn-primary').addClass('btn-warning');
                    }
                    else {
                        btn.text('Nữ');
                        btn.removeClass('btn-warning').addClass('btn-primary');
                        
                    }
                }
            }); 
        });
    }
} 
staff.init(); 