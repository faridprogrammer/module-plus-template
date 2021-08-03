using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Authorization.Users;
using AbpCompanyName.AbpProjectName.Ticketing.Dto;

namespace AbpCompanyName.AbpProjectName.Ticketing
{
    public class TicketsAppService : AsyncCrudAppService<Ticket, TicketDto, int, GetAllTicketsDto>
    {
        private readonly UserManager _userManager;

        public TicketsAppService(UserManager userManager, IRepository<Ticket, int> repository) : base(repository)
        {
            this._userManager = userManager;
        }
        protected override TicketDto MapToEntityDto(Ticket entity)
        {
            var dto = base.MapToEntityDto(entity);
            if (dto.CreatorUserId != null)
                dto.Creator = _userManager.GetUserById(dto.CreatorUserId.Value).FullName;
            return dto;
        }

        protected override IQueryable<Ticket> CreateFilteredQuery(GetAllTicketsDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(!input.Body.IsNullOrEmpty(), ticket => ticket.Body.Contains(input.Body))
                .WhereIf(!input.Title.IsNullOrEmpty(), ticket => ticket.Title.Contains(input.Title))
                .WhereIf(input.State != null, ticket => ticket.State == input.State);
        }

        public override Task<TicketDto> CreateAsync(TicketDto input)
        {
            input.State = TicketState.Created;
            return base.CreateAsync(input);
        }
    }
}
