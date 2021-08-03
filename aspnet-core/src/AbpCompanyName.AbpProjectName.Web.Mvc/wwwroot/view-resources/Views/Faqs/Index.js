(function ($) {
    var _faqsService = abp.services.app.faqs,
        l = abp.localization.getSource('AbpProjectName'),
        _$modal = $('#FaqCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#FaqsTable');

    var _$faqsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#FaqSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _faqsService.getAll(filter).done(function (result) {
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
                action: () => _$faqsTable.draw(false)
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
                data: 'question',
                sortable: false
            },
            {
                targets: 2,
                data: 'sortOrder',
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
                        `   <button type="button" class="btn btn-sm bg-secondary edit-faq" data-faq-id="${row.id}" data-toggle="modal" data-target="#FaqEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-faq" data-faq-name="${row.question}" data-faq-id="${row.id}">`,
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

        var faq = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);

        _faqsService
            .create(faq)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$faqsTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-faq', function () {
        var faqId = $(this).attr('data-faq-id');
        var faqName = $(this).attr('data-faq-name');

        deleteFaq(faqId, faqName);
    });

    $(document).on('click', '.edit-faq', function (e) {
        var faqId = $(this).attr('data-faq-id');

        abp.ajax({
            url: abp.appPath + 'faqs/EditModal?faqId=' + faqId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#FaqEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    abp.event.on('faq.edited', (data) => {
        _$faqsTable.ajax.reload();
    });

    function deleteFaq(faqId, faqName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                faqName
            ),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _faqsService
                        .delete({
                            id: faqId
                        })
                        .done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            _$faqsTable.ajax.reload();
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
        _$faqsTable.ajax.reload();
    });

    $('.btn-clear').on('click', (e) => {
        $('input[name=Keyword]').val('');
        $('input[name=IsActive][value=""]').prop('checked', true);
        _$faqsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$faqsTable.ajax.reload();
            return false;
        }
    });

})(jQuery);
