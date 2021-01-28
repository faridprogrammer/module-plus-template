using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AbpCompanyName.AbpProjectName.Accounting;
using AbpCompanyName.AbpProjectName.Addresses;
using AbpCompanyName.AbpProjectName.Authorization.Roles;
using AbpCompanyName.AbpProjectName.Authorization.Users;
using AbpCompanyName.AbpProjectName.Invoices;
using AbpCompanyName.AbpProjectName.Locations;
using AbpCompanyName.AbpProjectName.MultiTenancy;
using AbpCompanyName.AbpProjectName.Payments;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore
{
    public class AbpProjectNameDbContext : AbpZeroDbContext<Tenant, Role, User, AbpProjectNameDbContext>
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<StateProvince> StateProvinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Logs.Log> Logs
        {
            get;
            set;
        }

        public AbpProjectNameDbContext(DbContextOptions<AbpProjectNameDbContext> options)
            : base(options)
        {
        }
    }
}
