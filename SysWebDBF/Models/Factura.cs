using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysWebDBF.Models;

public partial class Factura
{
    [Key]
    [Column("idFactura")]
    public int IdFactura { get; set; }

    [Column("idVenta")]
    public int IdVenta { get; set; }

    [Column("fecha", TypeName = "date")]
    public DateTime Fecha { get; set; }

    [Column("total", TypeName = "decimal(10, 2)")]
    public decimal Total { get; set; }

    [Column("detallesFactura")]
    [StringLength(255)]
    [Unicode(false)]
    public string? DetallesFactura { get; set; }

    [ForeignKey("IdVenta")]
    [InverseProperty("Factura")]
    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
