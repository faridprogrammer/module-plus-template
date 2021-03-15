(function ($) {
    var _stateProvincesService = abp.services.app.stateProvinces,
        l = abp.localization.getSource('AbpProjectName'),
        _$modal = $('#StateProvinceCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#StateProvincesTable');

    var _$stateProvincesTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#StateProvinceSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _stateProvincesService.getAll(filter).done(function (result) {
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
                action: () => _$stateProvincesTable.draw(false)
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
                data: 'country.name',
                sortable: false,
                defaultContent: ""
            },
            {
                targets: 4,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-stateProvince" data-stateProvince-id="${row.id}" data-toggle="modal" data-target="#StateProvinceEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-stateProvince" data-stateProvince-name="${row.name}" data-stateProvince-id="${row.id}">`,
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

        var stateProvince = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);

        _stateProvincesService
            .create(stateProvince)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$stateProvincesTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-stateProvince', function () {
        var stateProvinceId = $(this).attr('data-stateProvince-id');
        var stateProvinceName = $(this).attr('data-stateProvince-name');

        deleteStateProvince(stateProvinceId, stateProvinceName);
    });

    $(document).on('click', '.edit-stateProvince', function (e) {
        var stateProvinceId = $(this).attr('data-stateProvince-id');

        abp.ajax({
            url: abp.appPath + 'stateProvinces/EditModal?stateProvinceId=' + stateProvinceId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#StateProvinceEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    abp.event.on('stateProvince.edited', (data) => {
        _$stateProvincesTable.ajax.reload();
    });

    function deleteStateProvince(stateProvinceId, stateProvinceName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                stateProvinceName
            ),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _stateProvincesService
                        .delete({
                            id: stateProvinceId
                        })
                        .done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            _$stateProvincesTable.ajax.reload();
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
        _$stateProvincesTable.ajax.reload();
    });

    $('.btn-clear').on('click', (e) => {
        $('input[name=Keyword]').val('');
        $('input[name=IsActive][value=""]').prop('checked', true);
        _$stateProvincesTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$stateProvincesTable.ajax.reload();
            return false;
        }
    });

})(jQuery);
