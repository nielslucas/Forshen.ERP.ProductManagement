using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Forshen.ERP.ProductManagement.Infrastructure;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        //optionsBuilder.UseSqlServer("Server= localhost; User Id = sa; Password = troef23@sycon2008; Database = Forshen.ERP.ProductManagement; Trusted_Connection=True; TrustServerCertificate=True");
        optionsBuilder.UseSqlServer("Server=localhost;Database=Forshen.ERP.ProductManagement;Trusted_Connection=True;TrustServerCertificate=True");

        return new AppDbContext(optionsBuilder.Options);
    }
}