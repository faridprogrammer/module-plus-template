using Abp.Application.Services;
using Abp.Domain.Repositories;
using AbpCompanyName.AbpProjectName.Authorization.Users;
using AbpCompanyName.AbpProjectName.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpCompanyName.AbpProjectName.Users
{
    public class InternalUserAppService : AbpProjectNameAppServiceBase
    {
        private readonly UserManager userManager;

        public InternalUserAppService(UserManager userManager)
        {
            this.userManager = userManager;
        }

        [RemoteService(false)]
        public async Task<UserDto> GetUser(string id)
        {
            var found = await userManager.FindByIdAsync(id);
        
            return ObjectMapper.Map<UserDto>(found);
        }
    }
}
