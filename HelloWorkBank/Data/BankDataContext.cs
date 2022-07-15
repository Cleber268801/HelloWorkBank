using HelloWorkBank.Model;
using HelloWorkBank.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorkBank.Data
{
    public class BankDataContext : DbContext
    {

        public DbSet<ContaModel> Conta { get; set; }

        public DbSet<ClienteModel> Clientes { get; set; }

        public DbSet<GerenteModel> Gerentes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }

}
