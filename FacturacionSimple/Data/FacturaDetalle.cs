namespace FacturacionSimple.Data;

public class FacturaDetalle
{
    public int Cantidad { get; set; }
    public string Producto { get; set; } = "";
    public decimal PrecioVenta { get; set; }
    public float PorcentajeDescuento { get; set; }//0-100
    private decimal ValorDescuento => (((decimal)PorcentajeDescuento / 100)* PrecioVenta);
    public decimal Descuento => (ValorDescuento * Cantidad);
    public decimal SubTotal => (Cantidad * PrecioVenta)-Descuento;
}
