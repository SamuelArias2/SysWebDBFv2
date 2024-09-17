using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysWebDBF.Models;

public partial class Venta
{
    [Key]
    [Column("idVenta")]
    public int IdVenta { get; set; }

    [Column("idCliente")]
    public int IdCliente { get; set; }

    [Column("fecha", TypeName = "date")]
    public DateTime Fecha { get; set; }

    [Column("total", TypeName = "decimal(10, 2)")]
    public decimal? Total { get; set; }

    [InverseProperty("IdVentaNavigation")]
    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

    [ForeignKey("IdCliente")]
    [InverseProperty("Venta")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [InverseProperty("IdVentaNavigation")]
    public virtual ICollection<VentaProducto> VentaProducto { get; set; } = new List<VentaProducto>();
}
