namespace FacturacionSimple.Data;

public class FacturaDetalle
{
    public int Cantidad { get; set; }
    public string Producto { get; set; }
    public decimal PrecioVenta { get; set; }

    public decimal SubTotal => Cantidad * PrecioVenta;
}
