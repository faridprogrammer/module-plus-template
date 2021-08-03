(function ($) {
    var ticketRepliesService = abp.services.app.ticketReplies,
        l = abp.localization.getSource('AbpProjectName'),
        $modal = $('#TicketEditModal'),
        $form = $modal.find('form');

    function save() {
        if (!$form.valid()) {
            return;
        }
        debugger;
        var ticket = $form.serializeFormToObject();
        var ticketReply = {
            body: ticket.NewAnswer,
            tickedId : ticket.Id,
            markAsResolved: ticket.MarkAsResolved == 'checked'
        };
        abp.ui.setBusy($form);
        ticketRepliesService.create(ticketReply).done(function () {
            $modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('ticket.edited', ticket);
        }).always(function () {
            abp.ui.clearBusy($form);
        });
    }

    $form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    $form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $modal.on('shown.bs.modal', function () {
        $form.find('input[type=text]:first').focus();
    });

})(jQuery);
