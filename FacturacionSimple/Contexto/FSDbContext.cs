using FacturacionSimple.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace FacturacionSimple.Contexto;

public class FSDbContext : DbContext, IFSDbContext
{
    #region Tablas de mi base de datos
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<FacturaDetalle> FacturasDetalle { get; set; }
    #endregion
    #region La configuracion de conexion a mi DB.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "FSDbContext.db" };
        var databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, connectionStringBuilder.DataSource);
        connectionStringBuilder.DataSource = databasePath;

        optionsBuilder.UseSqlite(connectionStringBuilder.ToString());
    }
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
    #endregion
}
