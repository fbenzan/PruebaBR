namespace FacturacionSimple.Data;

public class Factura
{
    public int Numero { get; set; }
    public string Cliente { get; set; }
    public DateTime Fecha { get; set; }
    public List<FacturaDetalle> Detalles { get; set; }
}
