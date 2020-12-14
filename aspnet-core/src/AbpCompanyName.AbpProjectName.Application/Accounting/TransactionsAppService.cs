using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AbpCompanyName.AbpProjectName.Accounting.Dto;

namespace AbpCompanyName.AbpProjectName.Accounting
{
    [AbpAuthorize]
    public class TransactionsAppService : CrudAppService<Transaction, TransactionDto, int, GetAllTransactionsDto>
    {
        public TransactionsAppService(IRepository<Transaction, int> repository) : base(repository)
        {
        }

        protected override IQueryable<Transaction> CreateFilteredQuery(GetAllTransactionsDto input)
        {
            return base.CreateFilteredQuery(input)
                    .WhereIf(input.OwnerId != null, transaction => transaction.OwnerId == input.OwnerId)
                    .WhereIf(input.Reason != null, transaction => transaction.Reason == input.Reason)
                    .WhereIf(!input.ReferenceEntityId.IsNullOrEmpty(), transaction => transaction.ReferenceEntityId == input.ReferenceEntityId); }

        public BalanceDto GetCurrentUserBalance()
        {
            var userid = AbpSession.UserId.Value;

            var baseQuery = Repository.GetAll().Where(tr => tr.OwnerId == userid);

            return new BalanceDto()
            {
                TotalDebit = baseQuery.Sum(tr => tr.DebitAmount),
                TotalCredit = baseQuery.Sum(tr => tr.CreditAmount)
            };
        }
    }
}
