using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysWebDBF.Models;

[PrimaryKey("IdVenta", "IdProducto")]
public partial class VentaProducto
{
    [Key]
    [Column("idVenta")]
    public int IdVenta { get; set; }

    [Key]
    [Column("idProducto")]
    public int IdProducto { get; set; }

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("VentaProducto")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;

    [ForeignKey("IdVenta")]
    [InverseProperty("VentaProducto")]
    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
