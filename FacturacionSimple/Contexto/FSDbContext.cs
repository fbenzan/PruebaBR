using FacturacionSimple.Data;
using Microsoft.EntityFrameworkCore;

namespace FacturacionSimple.Contexto;

public class FSDbContext : DbContext
{
    #region Tablas de mi base de datos
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<FacturaDetalle> FacturasDetalle { get; set; }
    #endregion
    #region La configuracion de conexion a mi DB.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=FSDbContext.db");
    }
    #endregion
}
