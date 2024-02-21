using FacturacionSimple.Data;
using Microsoft.EntityFrameworkCore;

namespace FacturacionSimple.Contexto
{
    public interface IFSDbContext
    {
        DbSet<Factura> Facturas { get; set; }
        DbSet<FacturaDetalle> FacturasDetalle { get; set; }

        int SaveChanges();
    }
}