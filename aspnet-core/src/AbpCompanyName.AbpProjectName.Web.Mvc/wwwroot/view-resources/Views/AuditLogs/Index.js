(function ($) {
    var _logService = abp.services.app.auditLogs,
        l = abp.localization.getSource('AbpProjectName'),
        _$table = $('#LogsTable');

    var _$logsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#LogsSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _logService.getAll(filter).done(function (result) {
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
                action: () => _$logsTable.draw(false)
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
                data: 'id',
                sortable: true
            },
            {
                targets: 2,
                data: 'tenantId',
                sortable: true
            },
            {
                targets: 3,
                data: 'userId',
                sortable: false
            },
            {
                targets: 4,
                data: 'serviceName',
                sortable: false
            },
            {
                targets: 5,
                data: 'methodName',
                sortable: false
            },
            {
                targets: 6,
                data: 'clientIpAddress',
                sortable: false
            },
            {
                targets: 7,
                data: 'parameters',
                sortable: false
            },
            {
                targets: 8,
                data: 'returnValue',
                sortable: false
            },
            {
                targets: 9,
                data: 'executionTime',
                sortable: false
            },
            {
                targets: 10,
                data: 'executionDuration',
                sortable: false
            },
            {
                targets: 11,
                data: 'browserInfo',
                sortable: false
            },
            {
                targets: 12,
                data: 'exception',
                sortable: false
            }
        ]
    });

    $('.btn-search').on('click', (e) => {
        _$logsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$logsTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
