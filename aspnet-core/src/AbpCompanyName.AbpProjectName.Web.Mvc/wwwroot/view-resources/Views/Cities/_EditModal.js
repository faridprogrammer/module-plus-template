(function ($) {
    var _citiesService = abp.services.app.cities,
        l = abp.localization.getSource('AbpProjectName'),
        _$modal = $('#CityEditModal'),
        _$form = _$modal.find('form');

    debugger;
    _$form.find('#CountryId').val(window.city.countryId);
    populateProvincesSelect();
    _$form.find('#StateProvinceId').val(window.city.stateProvinceId);

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var city = _$form.serializeFormToObject();

        abp.ui.setBusy(_$form);
        _citiesService.update(city).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('city.edited', city);
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

    _$form.find('#CountryId').on('change', (e) => {
        debugger;
        populateProvincesSelect();
    });

    function populateProvincesSelect()
    {
        var countryId = _$form.find('#CountryId').val();
        var provinceSelect = _$form.find("#StateProvinceId");
        provinceSelect
            .find('option')
            .remove()
            .end();

        var defaultOption = new Option("", "");
        provinceSelect.append(defaultOption);

        for (var i = 0; i < window.provinces.length; i++) {
            var item = window.provinces[i];
            if (countryId != item.countryId)
                continue;
            var option = new Option(item.name, item.id);
            provinceSelect.append(option);
        }
    }
})(jQuery);
