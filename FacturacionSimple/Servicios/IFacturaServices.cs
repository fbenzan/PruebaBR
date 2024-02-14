using FacturacionSimple.Data;

namespace FacturacionSimple.Servicios
{
    public interface IFacturaServices
    {
        bool Create(Factura data);
        List<Factura> Get(string filtro);
    }
}