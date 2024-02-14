namespace FacturacionSimple.Data;

public class Factura
{
    public int Numero { get; set; }
    public string Cliente { get; set; } = "";
    public DateTime Fecha { get; set; }
    public List<FacturaDetalle> Detalles { get; set; }
    = new();

    public int Unidades =>
        (Detalles != null && Detalles.Any()) ? 
        Detalles.Sum(d => d.Cantidad) : 0;
    public decimal Descuento =>
        (Detalles != null && Detalles.Any()) ?
        Detalles.Sum(d => d.Descuento) : 0;
    public decimal Total =>
        (Detalles != null && Detalles.Any()) ?
        Detalles.Sum(d => d.SubTotal) : 0;
}
