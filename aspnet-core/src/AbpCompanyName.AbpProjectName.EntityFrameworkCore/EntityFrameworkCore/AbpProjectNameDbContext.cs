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
        /* Define a DbSet for each entity of the application
           Or uncomment an existing DbSet to use an already existing entity.*/

        //public DbSet<Transaction> MpTransactions { get; set; }
        //public DbSet<Invoice> MpInvoices { get; set; }
        //public DbSet<InvoiceItem> MpInvoiceItems { get; set; }
        //public DbSet<Country> MpCountries { get; set; }
        //public DbSet<StateProvince> MpStateProvinces { get; set; }
        //public DbSet<City> MpCities { get; set; }
        //public DbSet<Address> MpAddresses { get; set; }
        //public DbSet<Payment> MpPayments { get; set; }


        public AbpProjectNameDbContext(DbContextOptions<AbpProjectNameDbContext> options)
            : base(options)
        {
        }
    }
}
