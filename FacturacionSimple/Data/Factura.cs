using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturacionSimple.Data;

public class Factura
{

    [Key]
    public int Id { get; set; }
    public int Numero { get; set; }
    public string Cliente { get; set; } = "";
    public DateTime Fecha { get; set; }
    public ICollection<FacturaDetalle> Detalles { get; set; } = new HashSet<FacturaDetalle>();

    [NotMapped]
    public int Unidades =>
        (Detalles != null && Detalles.Any()) ? 
        Detalles.Sum(d => d.Cantidad) : 0;

    [NotMapped]
    public decimal Descuento =>
        (Detalles != null && Detalles.Any()) ?
        Detalles.Sum(d => d.Descuento) : 0;

    [NotMapped]
    public decimal Total =>
        (Detalles != null && Detalles.Any()) ?
        Detalles.Sum(d => d.SubTotal) : 0;
}
