﻿(function ($) {
    function tblInformingOrgan() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-informingorgan").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new tblInformingOrgan();
        self.init();
    })
}(jQuery))
