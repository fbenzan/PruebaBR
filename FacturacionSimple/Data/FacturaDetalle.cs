using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturacionSimple.Data;

public class FacturaDetalle
{
    [Key]
    public int IdDetalle { get; set; }
    public int FacturaId { get; set; }
    public int Cantidad { get; set; }
    public string Producto { get; set; } = "";
    public decimal PrecioVenta { get; set; }
    public float PorcentajeDescuento { get; set; }//0-100
    [NotMapped]
    private decimal ValorDescuento => (((decimal)PorcentajeDescuento / 100)* PrecioVenta);
    [NotMapped]
    public decimal Descuento => (ValorDescuento * Cantidad);
    [NotMapped]
    public decimal SubTotal => (Cantidad * PrecioVenta)-Descuento;
    [ForeignKey(nameof(FacturaId))]
    public virtual Factura? Factura { get; set; }
}
