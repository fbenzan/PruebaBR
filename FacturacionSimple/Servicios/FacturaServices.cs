using FacturacionSimple.Data;

namespace FacturacionSimple.Servicios;

public class FacturaServices : IFacturaServices
{
    //Metodo para consultar las facturas..
    public List<Factura> Get(string filtro) => Memoria
        .Facturas.Where(f => f.Cliente.Contains(filtro)).ToList();
    //Metodo para guardar la factura...
    public bool Create(Factura data)
    {
        try
        {
            var numero = (Memoria.Facturas != null && Memoria.Facturas.Any()) ?
            Memoria.Facturas.Max(f => f.Numero) + 1 : 1;
            data.Numero = numero;
            data.Fecha = DateTime.Now;
            Memoria.Facturas?.Add(data);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
