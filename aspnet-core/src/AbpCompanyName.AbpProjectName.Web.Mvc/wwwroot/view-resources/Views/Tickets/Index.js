(function ($) {
    var _ticketsService = abp.services.app.tickets,
        l = abp.localization.getSource('AbpProjectName'),
        _$table = $('#TicketsTable');

    var _$ticketsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#TicketSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _ticketsService.getAll(filter).done(function (result) {
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
                action: () => _$ticketsTable.draw(false)
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
                data: 'title',
                sortable: false
            },
            {
                targets: 2,
                data: 'stateTitle',
                sortable: false
            },
            {
                targets: 3,
                data: 'creator',
                sortable: false
            },
            {
                targets: 4,
                data: 'creationTime',
                sortable: false
            },
            {
                targets: 5,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-ticket" data-ticket-id="${row.id}" data-toggle="modal" data-target="#TicketEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });


    $(document).on('click', '.delete-ticket', function () {
        var ticketId = $(this).attr('data-ticket-id');
        var ticketName = $(this).attr('data-ticket-name');

        deleteticket(ticketId, ticketName);
    });

    $(document).on('click', '.edit-ticket', function (e) {
        var ticketId = $(this).attr('data-ticket-id');

        abp.ajax({
            url: abp.appPath + 'tickets/EditModal?ticketId=' + ticketId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#TicketEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    abp.event.on('ticket.edited', (data) => {
        _$ticketsTable.ajax.reload();
    });

    $('.btn-search').on('click', (e) => {
        _$ticketsTable.ajax.reload();
    });

    $('.btn-clear').on('click', (e) => {
        $('input[name=Keyword]').val('');
        $('input[name=IsActive][value=""]').prop('checked', true);
        _$ticketsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$ticketsTable.ajax.reload();
            return false;
        }
    });

})(jQuery);
