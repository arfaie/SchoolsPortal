function Delete(controller, action) {
    $(document).on("click", "#Delete", function () {
        var Row = $(this);
        var id = $(this).attr('value');

        swal({
            title: "آیا از حذف این آیتم مطمئن هستید؟",
            text: "بعد از حذف، امکان بازیابی اطلاعات وجود ندارد!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
            buttons: ['انصراف', 'حذف']
        })
            .then((willDelete) => {
                if (willDelete) {
                    $.post('/Admin/' + controller + '/' + action + '/', { id: id },
                        function (result) {
                            if (result.status === 'OK') {
                                window.location.replace("/Admin" + '/' + controller);
                            }
                            else {
                                swal("خطایی در انجام عملیات رخ داد . دوباره تلاش کنید.", {
                                    icon: "error",
                                    button: "تایید"
                                });

                            }
                        });

                }
                //else {
                //    swal("Your user is safe!");
                //}
            });
    });
}