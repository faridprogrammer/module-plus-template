(function ($) {
    var _countriesService = abp.services.app.countries,
        l = abp.localization.getSource('AbpProjectName'),
        _$modal = $('#CountryCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#CountriesTable');

    var _$countriesTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#CountrySearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _countriesService.getAll(filter).done(function (result) {
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
                action: () => _$countriesTable.draw(false)
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
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-country" data-country-id="${row.id}" data-toggle="modal" data-target="#CountryEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-country" data-country-name="${row.name}" data-country-id="${row.id}">`,
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

        var country = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);

        _countriesService
            .create(country)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$countriesTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-country', function () {
        var countryId = $(this).attr('data-country-id');
        var countryName = $(this).attr('data-country-name');

        deleteCountry(countryId, countryName);
    });

    $(document).on('click', '.edit-country', function (e) {
        var countryId = $(this).attr('data-country-id');

        abp.ajax({
            url: abp.appPath + 'countries/EditModal?countryId=' + countryId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#CountryEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    abp.event.on('country.edited', (data) => {
        _$countriesTable.ajax.reload();
    });

    function deleteCountry(countryId, countryName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                countryName
            ),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _countriesService
                        .delete({
                            id: countryId
                        })
                        .done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            _$countriesTable.ajax.reload();
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
        _$countriesTable.ajax.reload();
    });

    $('.btn-clear').on('click', (e) => {
        $('input[name=Keyword]').val('');
        $('input[name=IsActive][value=""]').prop('checked', true);
        _$countriesTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$countriesTable.ajax.reload();
            return false;
        }
    });

})(jQuery);
