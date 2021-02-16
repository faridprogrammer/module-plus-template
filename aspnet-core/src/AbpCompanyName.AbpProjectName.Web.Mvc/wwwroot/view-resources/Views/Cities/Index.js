(function ($) {
    var _citiesService = abp.services.app.cities,
        l = abp.localization.getSource('AbpProjectName'),
        _$modal = $('#CityCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#CitiesTable');

    var _$citiesTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#CitySearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _citiesService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$citiesTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: 'phoneCode',
                sortable: false
            },
            {
                targets: 3,
                data: 'stateProvince.name',
                sortable: false,
                defaultContent: ""
            },
            {
                targets: 4,
                data: 'country.name',
                sortable: false,
                defaultContent: ""
            },
            {
                targets: 5,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-city" data-city-id="${row.id}" data-toggle="modal" data-target="#CityEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-city" data-city-name="${row.name}" data-city-id="${row.id}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').click(function (e) {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var city = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);

        _citiesService
            .create(city)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$citiesTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-city', function () {
        var cityId = $(this).attr('data-city-id');
        var cityName = $(this).attr('data-city-name');

        deleteCity(cityId, cityName);
    });

    $(document).on('click', '.edit-city', function (e) {
        var cityId = $(this).attr('data-city-id');

        abp.ajax({
            url: abp.appPath + 'cities/EditModal?cityId=' + cityId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#CityEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    abp.event.on('city.edited', (data) => {
        _$citiesTable.ajax.reload();
    });

    function deleteCity(cityId, cityName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                cityName
            ),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _citiesService
                        .delete({
                            id: cityId
                        })
                        .done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            _$citiesTable.ajax.reload();
                        });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
        populateProvincesSelect();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$citiesTable.ajax.reload();
    });

    $('.btn-clear').on('click', (e) => {
        $('input[name=Keyword]').val('');
        $('input[name=IsActive][value=""]').prop('checked', true);
        _$citiesTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$citiesTable.ajax.reload();
            return false;
        }
    });

    $('#CountryId').on('change', (e) => {
        populateProvincesSelect();
    });

    function populateProvincesSelect()
    {
        var countryId = $("#CountryId").val();
        var provinceSelect = $("#StateProvinceId");
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
