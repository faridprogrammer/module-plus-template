(function ($) {
    var _stateProvincesService = abp.services.app.stateProvinces,
        l = abp.localization.getSource('AbpProjectName'),
        _$modal = $('#StateProvincesEditModal'),
        _$form = _$modal.find('form');

    _$form.find('#CountryId').val(window.stateProvince.countryId);

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var stateProvince = _$form.serializeFormToObject();

        abp.ui.setBusy(_$form);
        _stateProvincesService.update(stateProvince).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('stateProvince.edited', stateProvince);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });


})(jQuery);
