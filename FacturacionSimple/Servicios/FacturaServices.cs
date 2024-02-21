using FacturacionSimple.Contexto;
using FacturacionSimple.Data;

namespace FacturacionSimple.Servicios;

public class FacturaServices : IFacturaServices
{
    private readonly IFSDbContext dbContext;

    public FacturaServices(IFSDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    //Metodo para consultar las facturas..
    public List<Factura> Get(string filtro) => 
        dbContext.Facturas.Where(f => f.Cliente.Contains(filtro)).ToList();
    //Memoria.Facturas.Where(f => f.Cliente.Contains(filtro)).ToList();
    //Metodo para guardar la factura...
    public bool Create(Factura data)
    {
        try
        {
            var numero = (dbContext.Facturas.Any()) ?
            dbContext.Facturas.Max(f => f.Numero) + 1 : 1;
            data.Numero = numero;
            data.Fecha = DateTime.Now;
            dbContext.Facturas.Add(data);
            dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
