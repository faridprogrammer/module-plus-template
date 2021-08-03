using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Ticketing.Dto;
using System.Linq;
using System.Threading.Tasks;
using AbpCompanyName.AbpProjectName.Authorization;

namespace AbpCompanyName.AbpProjectName.Ticketing
{
    public class TicketRepliesAppService : AsyncCrudAppService<TicketReply, TicketReplyDto, int, GetAllTickeRepliesDto, CreateTicketReplyDto>
    {
        private readonly IRepository<Ticket, int> _ticketRepo;

        public TicketRepliesAppService(IRepository<Ticket, int> ticketRepo, IRepository<TicketReply, int> repository) : base(repository)
        {
            _ticketRepo = ticketRepo;
            UpdatePermissionName = PermissionNames.Pages_Tickets_Update;
            CreatePermissionName = PermissionNames.Pages_Tickets_Create;
            DeletePermissionName = PermissionNames.Pages_Tickets_Delete;
        }

        protected override IQueryable<TicketReply> CreateFilteredQuery(GetAllTickeRepliesDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(input.TicketId != null, ff => ff.TickedId == input.TicketId.Value);
        }

        public override async Task<TicketReplyDto> CreateAsync(CreateTicketReplyDto input)
        {
            var ticket = await _ticketRepo.GetAsync(input.TickedId);
            ticket.State = TicketState.Pending;

            if (input.MarkAsResolved != null && await IsGrantedAsync(PermissionNames.Pages_Tickets_Update))
                ticket.State = TicketState.Resolved;

            await _ticketRepo.UpdateAsync(ticket);

            return await base.CreateAsync(input);
        }
    }
}
